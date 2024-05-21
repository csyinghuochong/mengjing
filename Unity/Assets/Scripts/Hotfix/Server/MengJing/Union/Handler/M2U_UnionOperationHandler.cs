﻿using System;


namespace ET
{

    [ActorMessageHandler]
    public class M2U_UnionOperationHandler : AMActorRpcHandler<Scene, M2U_UnionOperationRequest, U2M_UnionOperationResponse>
    {
        protected override async ETTask Run(Scene scene, M2U_UnionOperationRequest request, U2M_UnionOperationResponse response, Action reply)
        {
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.UnionOperate, request.UnionId))
            {
                DBUnionInfo dBUnionInfo = await scene.GetComponent<UnionSceneComponent>().GetDBUnionInfo(request.UnionId);
                if (dBUnionInfo == null)
                {
                    response.Error = ErrorCode.ERR_Union_Not_Exist;
                    reply();
                    return;
                }
               
                switch (request.OperateType)
                {
                    case 1:
                        //Par = $"{playerName}_{getWay}_{dataType}_{dataValue}
                        UnionConfig unionConfig = null;
                        string[] valuePararm = request.Par.Split('_');

                        if (valuePararm[2] == "17") // UserDataType.UnionExp
                        {
                            int addExp = int.Parse(valuePararm[3]);
                            //增加经验
                            if (dBUnionInfo.UnionInfo.Level == 0)
                            {
                                dBUnionInfo.UnionInfo.Level = 1;
                            }
                            int level = dBUnionInfo.UnionInfo.Level;
                            dBUnionInfo.UnionInfo.Exp += addExp;
                            unionConfig = UnionConfigCategory.Instance.Get(level);
                            if (dBUnionInfo.UnionInfo.Exp >= unionConfig.Exp && UnionConfigCategory.Instance.Contain(level + 1))
                            {
                                dBUnionInfo.UnionInfo.Level++;
                                dBUnionInfo.UnionInfo.Exp -= unionConfig.Exp;

                                MailInfo mailInfo = new MailInfo();
                                mailInfo.Title = "家族升级";
                                mailInfo.Context = "恭喜您!您所在得家族等级获得提升,这是家族升级的奖励!";

                                long serverTime = TimeHelper.ServerNow();
                                UnionConfig unionCof = UnionConfigCategory.Instance.Get(dBUnionInfo.UnionInfo.Level);
                                string[] rewardStrList = unionCof.UpAllReward.Split(';');
                                for (int i = 0; i < rewardStrList.Length; i++)
                                {
                                    string[] rewardList = rewardStrList[i].Split(',');
                                    mailInfo.ItemList.Add(new BagInfo() { ItemID = int.Parse(rewardList[0]), ItemNum = int.Parse(rewardList[1]), GetWay = $"{ItemGetWay.UnionUpLv}_{serverTime}" });
                                }

                                for (int i = 0; i < dBUnionInfo.UnionInfo.UnionPlayerList.Count; i++)
                                {
                                    MailHelp.SendUserMail(scene.DomainZone(), dBUnionInfo.UnionInfo.UnionPlayerList[i].UserID, mailInfo).Coroutine();
                                }

                                string noticeContent = $"恭喜 <color=#{ComHelp.QualityReturnColor(5)}>{dBUnionInfo.UnionInfo.UnionName}</color> 家族等级提升至{dBUnionInfo.UnionInfo.Level}级";
                                ServerMessageHelper.SendBroadMessage(scene.DomainZone(), NoticeType.Notice, noticeContent);

                            }
                        }
                        else if (valuePararm[2] == "35") //UserDataType.UnionGold
                        {
                            unionConfig = UnionConfigCategory.Instance.Get(dBUnionInfo.UnionInfo.Level);
                            dBUnionInfo.UnionInfo.UnionGold += int.Parse(valuePararm[3]);
                            if (dBUnionInfo.UnionInfo.UnionGold > unionConfig.UnionGoldLimit)
                            {
                                dBUnionInfo.UnionInfo.UnionGold = unionConfig.UnionGoldLimit;
                            }
                        }
                        else
                        {
                            reply();
                            return;
                        }

                        dBUnionInfo.UnionInfo.ActiveRecord.Add(request.Par);
                        if (dBUnionInfo.UnionInfo.ActiveRecord.Count >= 100)
                        {
                            dBUnionInfo.UnionInfo.ActiveRecord.RemoveAt(0);
                        }

                        DBHelper.SaveComponentCache(scene.DomainZone(), request.UnionId, dBUnionInfo).Coroutine();
                        break;
                    case 2:  //获取等级
                        response.Par = dBUnionInfo.UnionInfo.Level.ToString();
                        break;
                    case 3:  //金币捐献
                        dBUnionInfo.UnionInfo.Level = Math.Max(dBUnionInfo.UnionInfo.Level, 1);
                        response.Par = dBUnionInfo.UnionInfo.Level.ToString();
                        unionConfig = UnionConfigCategory.Instance.Get(dBUnionInfo.UnionInfo.Level);
                        long selfgold = long.Parse(request.Par);
                        if (selfgold < unionConfig.DonateGold)
                        {
                            response.Error = ErrorCode.ERR_GoldNotEnoughError;
                            reply();
                            return;
                        }
                        if (dBUnionInfo.UnionInfo.DonationRecords.Count >= 100)
                        {
                            dBUnionInfo.UnionInfo.DonationRecords.RemoveAt(0);
                        }
                        dBUnionInfo.UnionInfo.DonationRecords.Add( new DonationRecord()
                        { 
                            Gold = unionConfig.DonateGold,
                            Time = TimeHelper.ServerNow(),
                            UnitId = request.UnitId
                        });
                        DBHelper.SaveComponentCache(scene.DomainZone(), request.UnionId, dBUnionInfo).Coroutine();
                        break;
                    case 4: //钻石捐献
                        dBUnionInfo.UnionInfo.Level = Math.Max(dBUnionInfo.UnionInfo.Level, 1);
                        response.Par = dBUnionInfo.UnionInfo.Level.ToString();
                        unionConfig = UnionConfigCategory.Instance.Get(dBUnionInfo.UnionInfo.Level);
                        long selfDiamond = long.Parse(request.Par);
                        if (selfDiamond < unionConfig.DonateDiamond)
                        {
                            response.Error = ErrorCode.ERR_DiamondNotEnoughError;
                            reply();
                            return;
                        }
                        if (dBUnionInfo.UnionInfo.DonationRecords.Count >= 100)
                        {
                            dBUnionInfo.UnionInfo.DonationRecords.RemoveAt(0);
                        }
                        dBUnionInfo.UnionInfo.DonationRecords.Add( new DonationRecord()
                        { 
                            Diamond = unionConfig.DonateDiamond,
                            Time = TimeHelper.ServerNow(),
                            UnitId = request.UnitId
                        });
                        DBHelper.SaveComponentCache(scene.DomainZone(), request.UnionId, dBUnionInfo).Coroutine();
                        break;
                    case 5: //增加金币
                        dBUnionInfo.UnionInfo.UnionGold += int.Parse(request.Par);
                        DBHelper.SaveComponentCache(scene.DomainZone(), request.UnionId, dBUnionInfo).Coroutine();
                        break;
                    default:
                        break;
                }
            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}
