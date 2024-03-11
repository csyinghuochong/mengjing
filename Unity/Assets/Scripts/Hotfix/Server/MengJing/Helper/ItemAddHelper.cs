using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{

    /// <summary>
    /// ���ӷ���
    /// </summary>
    public static class ItemAddHelper
    {

        public static void OnItemUpdate(Unit self, BagInfo bagInfo)
        {
            //֪ͨ�ͻ��˱������߷����ı�
            M2C_RoleBagUpdate m2c_bagUpdate = new M2C_RoleBagUpdate();
            m2c_bagUpdate.BagInfoUpdate = new List<BagInfo>();
            m2c_bagUpdate.BagInfoUpdate.Add(bagInfo);
            MapMessageHelper.SendToClient(self, m2c_bagUpdate);
        }

        public static void OnGetItem(this Unit self, int getWay, int itemId, int itemNum)
        {
            self.GetComponent<TaskComponentServer>().OnGetItem_2(itemId);
            self.GetComponent<TaskComponentServer>().OnGetItemNumber(getWay, itemId, itemNum);
            //self.GetComponent<ShoujiComponentServer>().OnGetItem(itemId);
        }

        /// <summary>
        /// ��������2Ҫ���һ�µ�������
        /// </summary>
        /// <param name="self"></param>
        /// <param name="itemId"></param>
        public static void OnCostItem(this Unit self, int itemId)
        {
            self.GetComponent<TaskComponentServer>().OnGetItem_2(itemId);
        }

        /// <summary>
        /// ������������������Ʒ�ʵķ���
        /// </summary>
        /// <param name="bagInf0"></param>
        /// <param name="getType">1����</param>
        public static void JianDingFuItem(BagInfo bagInf0, int shulianValue, int getType)
        {
            if (ItemHelper.IsBuyItem(getType))
            {
                bagInf0.ItemPar = GlobalValueConfigCategory.Instance.JianDingFuQulity.ToString();
                return;
            }

            //���ܼ������̶�Ϊ60
            if (bagInf0.ItemID == 11200000)
            {
                bagInf0.ItemPar = "100";
                return;
            }

            ItemConfig itemCof = ItemConfigCategory.Instance.Get(bagInf0.ItemID);
            float minValuePro = (float)shulianValue / (float)int.Parse(itemCof.ItemUsePar);
            if (minValuePro >= 1)
            {
                minValuePro = 1;
            }
            if (minValuePro <= 0.2f)
            {
                minValuePro = 0.2f;
            }
            int minValue = (int)(minValuePro * 50f);
            int maxValue = (int)(minValuePro * 102f);
            int randValue = RandomHelper.RandomNumber(minValue, maxValue);
            if (randValue > 100)
            {
                randValue = 100;
            }
            bagInf0.ItemPar = randValue.ToString();
        }

        public static void TreasureItem(Unit unit, BagInfo bagInfo)
        {

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            if (itemConfig.ItemSubType != 113 && itemConfig.ItemSubType != 127)
            {
                return;
            }

            List<DungeonConfig> dungeonConfigs = new List<DungeonConfig>();
            List<DungeonConfig> dungeonConfigsAll = DungeonConfigCategory.Instance.GetAll().Values.ToList();

            int roleLv = unit.GetComponent<UserInfoComponentServer>().GetUserLv();

            for (int i = 0; i < dungeonConfigsAll.Count; i++)
            {
                if (DungeonSectionConfigCategory.Instance.MysteryDungeonList.Contains(dungeonConfigsAll[i].Id))
                {
                    continue;
                }
                if (dungeonConfigsAll[i].EnterLv <= roleLv && dungeonConfigsAll[i].Id < ConfigHelper.GMDungeonId())
                {
                    dungeonConfigs.Add(dungeonConfigsAll[i]);
                }
            }

            int dungeonindex = RandomHelper.RandomNumber(0, dungeonConfigs.Count);
            int dungeonid = dungeonConfigs[dungeonindex].Id;

            int dropId = int.Parse(itemConfig.ItemUsePar);
            List<RewardItem> rewardList = new List<RewardItem>();

            //��ȡ���ս���
            if (RandomHelper.RandFloat01() <= 0.7f)
            {
                DropHelper.DropIDToDropItem_2(dropId, rewardList);
            }
            else
            {
                int baotutype = 1;
                if (bagInfo.ItemID == 10010039)
                {
                    baotutype = 1;
                }

                if (bagInfo.ItemID == 10010040)
                {
                    baotutype = 2;
                }
                int dropID2 = ComHelp.TreasureToDropID(dungeonid, roleLv, baotutype);
                DropHelper.DropIDToDropItem_2(dropID2, rewardList);
            }

            bagInfo.ItemPar = $"{dungeonid}@{"TaskMove_6"}@{rewardList[0].ItemID + ";" + rewardList[0].ItemNum}";
            Log.Debug($"���ɲر�ͼ:  {unit.Id} {unit.GetComponent<UserInfoComponentServer>().GetName()} {rewardList[0].ItemID}");
        }


        //��ȡװ���ļ�������
        public static List<HideProList> GetEquipZhuanJingHidePro(int equipID, int itemID, int jianDingPinZhi, Unit unit, bool ifItem)
        {
            //��ȡ���ֵ
            EquipConfig equipCof = EquipConfigCategory.Instance.Get(equipID);
            List<HideProList> hideList = new List<HideProList>();

            //��ȡ��ǰ����ϵ��
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(itemID);

            //������Ʒ�ʴ���װ���ȼ�
            /*
            float JianDingPro = 1f;
            if (jianDingPinZhi >= itemCof.UseLv)
            {
   
            }
            else
            {
                JianDingPro = jianDingPinZhi / itemCof.UseLv * 0.5f;
            }
            */

            //����
            //jianDingPinZhi = 99;

            //���ϵ����20
            int pro = itemCof.UseLv;
            if (pro <= 20)
            {
                pro = 20;
            }

            if (ifItem == true && itemCof.UseLv < 30)
            {
                jianDingPinZhi = jianDingPinZhi + 5;
            }

            //�������͵�ǰװ���ĵȼ���
            float JianDingPro = (float)jianDingPinZhi / (float)pro;
            float addJianDingPro = 0;

            if (JianDingPro >= 1.5f)
            {
                JianDingPro = 1.5f;
                addJianDingPro += 0.2f;
            }
            else if (JianDingPro >= 1f)
            {
                addJianDingPro += 0.2f * (JianDingPro - 0.5f);
            }

            if (JianDingPro <= 0.5f)
            {
                JianDingPro = 0.5f;
            }

            int randomNum = 0;
            float randomFloat = RandomHelper.RandomNumberFloat(addJianDingPro, 1) + addJianDingPro;
            Log.Info("randomFloat == " + randomFloat + "  JianDingPro = " + JianDingPro + "addJianDingPro = " + addJianDingPro);

            randomFloat = randomFloat * JianDingPro;

            if (randomFloat <= 0.25f)
            {
                randomNum = 0;
            }
            else if (randomFloat <= 0.6f)
            {
                randomNum = 1;
            }
            else if (randomFloat <= 1f)
            {
                randomNum = 2;
            }
            else
            {
                randomNum = 3;
            }
            /*
            else if (randomFloat <= 0.9f)
            {
                randomNum = 3;
            }
            */

            //65��װ��Ĭ�����2������
            if (itemCof.UseLv >= 65 && randomNum < 2)
            {
                randomNum = 2;
            }

            if (ifItem)
            {
                if (randomNum >= 2)
                {
                    string noticeContent = $"��ϲ���<color=#B6FF00>{unit.GetComponent<UserInfoComponentServer>().GetName()}</color>ʹ�ü���������װ��ʱ,һ�����װ������<color=#FFA313>{randomNum}����Ʒ����</color>";
                    //ServerMessageHelper.SendBroadMessage(unit.DomainZone(), NoticeType.Notice, noticeContent);
                }
            }

            if (randomNum == 0)
            {
                return null;
            }

            //��ȡ������Ե����ֵ����Сֵ
            JianDingDate jiandingDate = ItemHelper.GetEquipZhuanJingPro(equipID, itemID, jianDingPinZhi, ifItem);

            for (int i = 0; i < randomNum; i++)
            {
                //���ֵ(��Ʒ�ʱ�������)
                /*
                int minNum = 1;
                if (JianDingPro > 1f) {
                    minNum = (int)((float)equipCof.OneProRandomValue * (JianDingPro - 1f) * 0.68f);
                }
                int maxNum = (int)((float)equipCof.OneProRandomValue * JianDingPro * 0.8f);
                if (minNum > maxNum) {
                    maxNum = minNum;
                }
                if (maxNum > equipCof.OneProRandomValue) {
                    maxNum = equipCof.OneProRandomValue;
                }

                int randomValueInt = RandomHelper.RandomNumber(minNum, maxNum + 1);
                */
                int randomValueInt = RandomHelper.RandomNumber(jiandingDate.MinNum, jiandingDate.MaxNum + 1);
                randomValueInt = (int)(randomValueInt * JianDingPro);
                if (randomValueInt > equipCof.OneProRandomValue)
                {
                    randomValueInt = equipCof.OneProRandomValue;
                }
                //���Ʒ�ʷ��㹻��,����Ϊ5
                if (randomValueInt < 5)
                {
                    if (JianDingPro >= 1.5f)
                    {
                        randomValueInt = 5;
                    }
                    else if (JianDingPro >= 1f)
                    {
                        randomValueInt = 3;
                    }
                }

                //����Ϊ1��,��ֹ����0������
                if (randomValueInt < 1)
                {
                    randomValueInt = 1;
                }

                //�����������
                int randomIDInt = RandomHelper.RandomNumber(1, 6);
                //
                int proID = 105101;
                switch (randomIDInt)
                {
                    case 1:
                        proID = 105101;
                        break;
                    case 2:
                        proID = 105201;
                        break;
                    case 3:
                        proID = 105301;
                        break;
                    case 4:
                        proID = 105401;
                        break;
                    case 5:
                        proID = 105501;
                        break;
                }

                HideProList hideProList = new HideProList();
                hideProList.HideID = proID;
                hideProList.HideValue = randomValueInt;
                hideList.Add(hideProList);

            }

            return hideList;

        }
    }
}
