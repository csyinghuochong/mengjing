﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ET
{
    [ActorMessageHandler]
    public class C2M_ExpToGoldHandler : AMActorLocationRpcHandler<Unit, C2M_ExpToGoldRequest, M2C_ExpToGoldResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ExpToGoldRequest request, M2C_ExpToGoldResponse response, Action reply)
        {
            UserInfoComponent userInfoComponent = unit.GetComponent<UserInfoComponent>();
            UserInfo userInfo = userInfoComponent.UserInfo;
            ServerInfo serverInfo = unit.DomainScene().GetComponent<ServerInfoComponent>().ServerInfo;
            if (userInfo.Lv < serverInfo.WorldLv)
            {
                response.Error = ErrorCode.ERR_LevelNoEnough;
                reply();
                return;
            }

            //背包已满
            if (unit.GetComponent<BagComponent>().IsBagFull()) {
                response.Error = ErrorCode.ERR_BagIsFull;
                reply();
                return;
            }

            //满级经验兑换效验等级
            GlobalValueConfig globalCof = GlobalValueConfigCategory.Instance.Get(41);
            if (request.OperateType == 2) {
                if (userInfo.Lv < globalCof.Value2) {
                    response.Error = ErrorCode.ERR_ExpNoEnough;
                    reply();
                    return;
                }
            }

            //低于20%经验无法兑换
            float costPro = 0.2f;
            if (request.OperateType == 2) {
                costPro = 0.3f;
            }
            ExpConfig expCof = ExpConfigCategory.Instance.Get(userInfo.Lv);
            int costExp = (int)(expCof.UpExp * costPro);
            if (userInfo.Exp < costExp||costExp <= 0)
            {
                response.Error = ErrorCode.ERR_ExpNoEnough;
                reply();
                return;
            }

            switch (request.OperateType)
            {
                case 3:
                     int sendGold = (int)(10000 + expCof.RoseGoldPro * 10);
                     sendGold = (int)(10000 + expCof.RoseGoldPro * 10);
                     userInfoComponent.UpdateRoleMoneyAdd(UserDataType.Gold, sendGold.ToString(), true, 32);
                     Log.Debug($"Gold:  {userInfoComponent.Id} {sendGold} excharge");
                    break;
                case 2:
                    string[] droplist = GlobalValueConfigCategory.Instance.Get(81).Value.Split(';');
                    int dropid = int.Parse(droplist[0]);
                    List<RewardItem> rewardItems = new List<RewardItem>();
                    DropHelper.DropIDToDropItem_2(dropid, rewardItems);
                    unit.GetComponent<BagComponent>().OnAddItemData(rewardItems, String.Empty, $"{ItemGetWay.DuiHuan}_{TimeHelper.ServerNow()}");
                    break;
                case 0:
                    List<int> weights = ListComponent<int>.Create();
                    for (int i = 0; i < ConfigHelper.ExpToItemList.Count; i++)
                    {
                        weights.Add(ConfigHelper.ExpToItemList[i].KeyId);
                    }
                    int index = RandomHelper.RandomByWeight(weights);
                    unit.GetComponent<BagComponent>().OnAddItemData(ConfigHelper.ExpToItemList[index].Value,  $"{ItemGetWay.DuiHuan}_{TimeHelper.ServerNow()}");
                    break;
                default:
                    break;
            }
            userInfoComponent.UpdateRoleData(UserDataType.Exp, (costExp * -1).ToString());
            unit.GetComponent<NumericComponent>().ApplyChange(null, NumericType.ExpToGoldTimes, 1, 0);
            reply();
            await ETTask.CompletedTask;
        }
    }
}
