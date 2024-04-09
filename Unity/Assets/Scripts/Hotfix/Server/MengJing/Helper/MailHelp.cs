using System.Collections.Generic;

namespace ET.Server
{



    public static class MailHelp
    {
        public static async ETTask SendPaiMaiEmail(Scene root, PaiMaiItemInfo paiMaiItemInfo, int costNum, long unitid)
        {
            MailInfo mailInfo = new MailInfo();
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(paiMaiItemInfo.BagInfo.ItemID);
            mailInfo.Status = 0;
            mailInfo.Context = "你拍卖行出售的道具:" + itemCof.ItemName + ",已经被其他玩家购买" + costNum + "个。";
            mailInfo.Title = "拍卖行邮件";
            mailInfo.MailId = IdGenerater.Instance.GenerateId();
            BagInfo reward = new BagInfo();
            reward.ItemID = 1;
            int sellPrice = (int)(paiMaiItemInfo.Price * 0.95f) * costNum; //5%手续费
            reward.ItemNum = sellPrice;
            reward.GetWay = $"{ItemGetWay.PaiMaiSell}_{TimeHelper.ServerNow()}";
            mailInfo.ItemList.Add(reward);
            mailInfo.ItemSell = paiMaiItemInfo.BagInfo;
            mailInfo.BuyPlayerId = unitid;

            //发送到邮件服
            ActorId mailServerId = UnitCacheHelper.GetMailServerId(root.Zone());
            E2M_EMailSendResponse g_EMailSendResponse = (E2M_EMailSendResponse)await root.GetComponent<MessageSender>().Call(mailServerId,
                new M2E_EMailSendRequest() { Id = paiMaiItemInfo.UserId, MailInfo = mailInfo });
        }

        public static void SendServerMail(Scene root, long userID, ServerMailItem serverMailItem)
        {
            // (M2A_PetMingRecordResponse) await scene.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Call(oldUnitid, a2M_PetMing);
            Mail2M_SendServerMailItem mail2M_SendServer = new Mail2M_SendServerMailItem();
            mail2M_SendServer.ServerMailItem = serverMailItem;
            root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(userID, mail2M_SendServer);
        }

        public static bool CheckSendMail(int MailType, string Title, NumericComponentS numericComponent, UserInfoComponentS userInfoComponent,  BagComponentS bagComponent)
        {
            if (numericComponent == null || userInfoComponent == null || bagComponent == null)
            {
                return false;
            }

            switch (MailType)
            {
                case 2: // 充值>=6元 10011003
                    if (numericComponent.GetAsLong(NumericType.RechargeNumber) < int.Parse(Title))
                    {
                        return false;
                    }

                    break;
                case 5:
                    // 充值>=6<30元 10011003
                    //充值额度某个区间段
                    string[] needrecharge = Title.Split('_');
                    int min_value = int.Parse(needrecharge[0]);
                    int max_value = int.Parse(needrecharge[1]);
                    if (numericComponent.GetAsLong(NumericType.RechargeNumber) < min_value
                        || numericComponent.GetAsLong(NumericType.RechargeNumber) >= max_value)
                    {
                        return false;
                    }

                    break;
                case 3: //20级以上 补
                    if (userInfoComponent.UserInfo.Lv < int.Parse(Title))
                    {
                        return false;
                    }

                    break;
                case 4: //开启第二个仓库并且格子没有开完的
                    if (numericComponent.GetAsInt(NumericType.CangKuNumber) < 2)
                    {
                        return false;
                    }

                    if (bagComponent.WarehouseAddedCell.Count < 10)
                    {
                        return false;
                    }

                    if (bagComponent.WarehouseAddedCell[6] >= 10)
                    {
                        return false;
                    }

                    break;
                default:
                    break;
            }

            //Log.Console($"CheckSendMail.true : {MailType} {Title}");
            return true;
        }

        public static async ETTask ServerMailItem(Scene root, long userID, ServerMailItem serverMailItem)
        {
            //判断条件
            UserInfoComponentS userInfoComponent = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(root, userID);
            NumericComponentS numericComponent =await UnitCacheHelper.GetComponentCache<NumericComponentS>(root, userID);
            BagComponentS bagComponent = await UnitCacheHelper.GetComponentCache<BagComponentS>(root, userID);
            bool cansendMail = MailHelp.CheckSendMail(serverMailItem.MailType, serverMailItem.ParasmNew, numericComponent, userInfoComponent,
                bagComponent);
            if (cansendMail == false)
            {
                return;
            }

            MailInfo mailInfo = new MailInfo();
            mailInfo.Status = 0;
            mailInfo.Title = "奖励";
            mailInfo.Context = "全服补偿邮件";
            mailInfo.ItemList = serverMailItem.ItemList;
            mailInfo.MailId = IdGenerater.Instance.GenerateId();
            await SendUserMail(root, userID, mailInfo);
        }

        //指定玩家发送邮件
        public static async ETTask<int> SendUserMail(Scene root, long userID, MailInfo mailInfo)
        {
            DBMailInfo dBMainInfo = await UnitCacheHelper.GetComponentBD<DBMailInfo>(root, userID);
            if (dBMainInfo == null)
            {
                return ErrorCode.ERR_NotFindAccount;
            }

            List<MailInfo> mailinfolist = dBMainInfo.MailInfoList;
            for (int i = mailinfolist.Count - 1; i >= 0; i--)
            {
                if (mailinfolist[i].ItemList.Count != 1)
                {
                    continue;
                }

                if (mailinfolist[i].ItemList[0].ItemID == 10000151) //之前有一次全服误发精灵龟 /羽毛
                {
                    mailinfolist.RemoveAt(i);
                    continue;
                }

                if (mailinfolist[i].ItemList.Count >= 1 && !ItemConfigCategory.Instance.Contain(mailinfolist[i].ItemList[0].ItemID)) //
                {
                    mailinfolist.RemoveAt(i);
                    continue;
                }

                if (mailinfolist[i].ItemList.Count >= 2 && !ItemConfigCategory.Instance.Contain(mailinfolist[i].ItemList[1].ItemID))
                {
                    mailinfolist.RemoveAt(i);
                    continue;
                }
            }

            //存储邮件
            if (mailinfolist.Count > 100)
            {
                mailinfolist.RemoveAt(0);
            }

            mailinfolist.Add(mailInfo);
            await UnitCacheHelper.SaveComponentDB(root, userID ,dBMainInfo);
            return ErrorCode.ERR_Success;
        }
    }
}