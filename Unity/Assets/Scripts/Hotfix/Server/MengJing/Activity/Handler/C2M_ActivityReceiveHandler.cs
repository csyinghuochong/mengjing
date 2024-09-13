using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_ActivityReceiveHandler : MessageLocationHandler<Unit, C2M_ActivityReceiveRequest, M2C_ActivityReceiveResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_ActivityReceiveRequest request, M2C_ActivityReceiveResponse response)
        {
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Received, unit.Id))
            {
                if (!ActivityConfigCategory.Instance.Contain(request.ActivityId))
                {
                    Log.Error($"C2M_ActivityReceiveRequest.1");
                    response.Error = ErrorCode.ERR_ModifyData;

                    return;
                }

                ActivityComponentS activityComponent = unit.GetComponent<ActivityComponentS>();
                if (!ActivityHelper.HaveReceiveTimes(activityComponent.ActivityReceiveIds, request.ActivityId))
                {
                    response.Error = ErrorCode.ERR_AlreadyReceived;
                    return;
                }
                ServerLogHelper.LogWarning($"C2M_ActivityReceive:  {unit.Id} {request.ActivityId} {request.ReceiveIndex} {TimeHelper.ServerNow().ToString()}", true);
                ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(request.ActivityId);
                if (activityConfig.ActivityType!= request.ActivityType)
                {
                    Log.Error($"C2M_ActivityReceiveRequest.2");
                    response.Error = ErrorCode.ERR_ModifyData;
                    return;
                }

                switch (activityConfig.ActivityType)
                {
                    case 2: //每日特惠
                        string[] needList = activityConfig.Par_3.Split('@');
                        if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < needList.Length)
                        {
                            response.Error = ErrorCode.ERR_BagIsFull;
                            return;
                        }

                        if (!unit.GetComponent<BagComponentS>().OnCostItemData(activityConfig.Par_2))
                        {
                            response.Error = ErrorCode.ERR_DiamondNotEnoughError;
         
                            return;
                        }
                        if (!unit.GetComponent<BagComponentS>().OnAddItemData(activityConfig.Par_3, $"{ItemGetWay.Activity_DayTeHui}_{TimeHelper.ServerNow()}"))
                        {
                            response.Error = ErrorCode.ERR_BagIsFull;
                            return;
                        }

                        activityComponent.ActivityReceiveIds.Add(request.ActivityId);
                        
                        break;
                    case 23:    //签到
                        if (activityComponent.TotalSignNumber == 30)
                        {
                            response.Error = ErrorCode.ERR_AlreadyReceived;
                   
                            return;
                        }
                        long serverNow = TimeHelper.ServerNow();
                        if (CommonHelp.GetDayByTime(serverNow) == CommonHelp.GetDayByTime(activityComponent.LastSignTime))
                        {
                            response.Error = ErrorCode.ERR_AlreadyReceived;
          
                            return;
                        }
                        string[] rewarditems = activityConfig.Par_3.Split('@');
                        if (rewarditems.Length > unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag))
                        {
                            response.Error = ErrorCode.ERR_BagIsFull;
                  
                            return;
                        }

                        activityComponent.TotalSignNumber++;
                        activityComponent.LastSignTime = TimeHelper.ServerNow();
                        activityComponent.ActivityReceiveIds.Add(request.ActivityId);
                        unit.GetComponent<BagComponentS>().OnAddItemData(activityConfig.Par_3, $"{ItemGetWay.Activity}_{TimeHelper.ServerNow()}");
                        break;
                    case 24:    //令牌
                        List<TokenRecvive> zhanQuTokenRecvives = activityComponent.QuTokenRecvive;
                        for (int i = 0; i < zhanQuTokenRecvives.Count; i++)
                        {
                            if (zhanQuTokenRecvives[i].ActivityId == request.ActivityId
                                && zhanQuTokenRecvives[i].ReceiveIndex == (request.ReceiveIndex))
                            {
                                response.Error = ErrorCode.ERR_AlreadyReceived;
                                return;
                            }
                        }
                        UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
                        if (userInfoComponent.UserInfo.Lv < int.Parse(activityConfig.Par_1))
                        {
                            return;
                        }
                        int selfRechage = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.RechargeNumber);
                        if (request.ReceiveIndex == 3 && selfRechage < 298)
                        {
                            return;
                        }
                        if (request.ReceiveIndex == 2 && selfRechage < 98)
                        {
                            return;
                        }

                        activityConfig = ActivityConfigCategory.Instance.Get(request.ActivityId);
                        string rewards = "";
                        if (request.ReceiveIndex == 1) rewards = activityConfig.Par_2;
                        if (request.ReceiveIndex == 2) rewards = activityConfig.Par_3;
                        if (request.ReceiveIndex == 3) rewards = activityConfig.Par_4;

                        rewarditems = rewards.Split('@');
                        if (rewarditems.Length > unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag))
                        {
                            response.Error = ErrorCode.ERR_BagIsFull;
                            return;
                        }

                        TokenRecvive TokenRecvive = TokenRecvive.Create();
                        TokenRecvive.ActivityId = request.ActivityId; 
                        TokenRecvive.ReceiveIndex = request.ReceiveIndex;
                        zhanQuTokenRecvives.Add(TokenRecvive);
                        unit.GetComponent<BagComponentS>().OnAddItemData(rewards, $"{ItemGetWay.Activity}_{TimeHelper.ServerNow()}");
                        break;
                    case 31:    //登录奖励
                        userInfoComponent = unit.GetComponent<UserInfoComponentS>();
                        if (userInfoComponent.UserInfo.Lv < 10)
                        {
                            return;
                        }
                        serverNow = TimeHelper.ServerNow();
                        if (CommonHelp.GetDayByTime(serverNow) == CommonHelp.GetDayByTime(activityComponent.LastLoginTime))
                        {
                            response.Error = ErrorCode.ERR_AlreadyReceived;
                            return;
                        }

                        rewarditems = activityConfig.Par_3.Split('@');
                        if (rewarditems.Length > unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag))
                        {
                            response.Error = ErrorCode.ERR_BagIsFull;
                            return;
                        }

                        activityComponent.LastLoginTime = serverNow;
                        unit.GetComponent<ActivityComponentS>().ActivityReceiveIds.Add(request.ActivityId);
                        unit.GetComponent<BagComponentS>().OnAddItemData(activityConfig.Par_3, $"{ItemGetWay.Activity}_{TimeHelper.ServerNow()}");
                        break;
                    case 32:    //新年集字
                        rewarditems = activityConfig.Par_3.Split('@');
                        if (rewarditems.Length > unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag))
                        {
                            response.Error = ErrorCode.ERR_BagIsFull;
                            return;
                        }
                        if (unit.GetComponent<BagComponentS>().OnCostItemData(activityConfig.Par_2))
                        {
                            unit.GetComponent<ActivityComponentS>().ActivityReceiveIds.Add(request.ActivityId);
                            unit.GetComponent<BagComponentS>().OnAddItemData(activityConfig.Par_3, $"{97}_{TimeHelper.ServerNow()}");
                        }
                        else
                        {
                            response.Error = ErrorCode.ERR_ItemNotEnoughError;
                        }
                        break;
                    case 33://节日活动
                        if (unit.GetComponent<UserInfoComponentS>().TodayOnLine < 30)
                        {
                            response.Error = ErrorCode.Err_OnLineTimeNot;
                            return;
                        }
                        string rewardItemlist = ActivityHelper.GetJieRiReward(unit.GetComponent<UserInfoComponentS>().UserInfo.Lv);
                        if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < rewardItemlist.Split('@').Length)
                        {
                            response.Error = ErrorCode.ERR_BagIsFull;
                            return;
                        }
                        if (!ActivityHelper.IsJieRiActivityId(request.ActivityId))
                        {
                            response.Error = ErrorCode.ERR_AlreadyFinish;
                            return;
                        }

                        if (unit.GetComponent<UserInfoComponentS>().UserInfo.Lv < 20)
                        {
                            response.Error = ErrorCode.ERR_EquipLvLimit;
                            return;
                        }

                        unit.GetComponent<ActivityComponentS>().ActivityReceiveIds.Add(request.ActivityId);
                        unit.GetComponent<BagComponentS>().OnAddItemData(rewardItemlist, $"{ItemGetWay.Activity}_{TimeHelper.ServerNow()}");
                        break;
                    case 34:
                        userInfoComponent = unit.GetComponent<UserInfoComponentS>();
                        if (userInfoComponent.UserInfo.Lv < int.Parse(activityConfig.Par_1))
                        {
                            response.Error = ErrorCode.ERR_EquipLvLimit;
                            return;
                        }

                        rewarditems = activityConfig.Par_3.Split('@');
                        if (rewarditems.Length > unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag))
                        {
                            response.Error = ErrorCode.ERR_BagIsFull;
                            return;
                        }

                        unit.GetComponent<ActivityComponentS>().ActivityReceiveIds.Add(request.ActivityId);
                        unit.GetComponent<BagComponentS>().OnAddItemData(activityConfig.Par_3, $"{ItemGetWay.Serial}_{TimeHelper.ServerNow()}");
                        break;
                    case 101:   //冒险家
                                //需要从dbaccountinfo中获取当前角色重置额度
                        long needrecharge = int.Parse(activityConfig.Par_2);
                        int rechargeNum = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.RechargeNumber);
                        rechargeNum *= 10;
                        rechargeNum += unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.MaoXianExp);
                        if (rechargeNum < needrecharge)
                        {
                            Log.Error($"C2M_ActivityReceiveRequest.3");
                            response.Error = ErrorCode.ERR_ModifyData;
                            return;
                        }
                        rewarditems = activityConfig.Par_3.Split('@');
                        if (rewarditems.Length > unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag))
                        {
                            response.Error = ErrorCode.ERR_BagIsFull;
                            return;
                        }
                        if (!unit.GetComponent<BagComponentS>().OnAddItemData(activityConfig.Par_3, $"{ItemGetWay.Activity_MaoXianJia}_{TimeHelper.ServerNow()}"))
                        {
                            response.Error = ErrorCode.ERR_BagIsFull;
                            return;
                        }
                        unit.GetComponent<ActivityComponentS>().ActivityReceiveIds.Add(request.ActivityId);
                        break;
                    default:
                        bool success = unit.GetComponent<BagComponentS>().OnCostItemData(activityConfig.Par_2);
                        if (success)
                        {
                            unit.GetComponent<ActivityComponentS>().ActivityReceiveIds.Add(request.ActivityId);
                            unit.GetComponent<BagComponentS>().OnAddItemData(activityConfig.Par_3, $"{ItemGetWay.Activity}_{TimeHelper.ServerNow()}");
                        }
                        else
                        {
                            response.Error = ErrorCode.ERR_GoldNotEnoughError;
                        }
                        break;
                }
            }
            ServerLogHelper.LogWarning($"C2M_ActivityReceive[成功]:  {unit.Id} {request.ActivityId} {request.ReceiveIndex} {TimeHelper.ServerNow().ToString()}", true);
            await ETTask.CompletedTask;
        }
    }
}
