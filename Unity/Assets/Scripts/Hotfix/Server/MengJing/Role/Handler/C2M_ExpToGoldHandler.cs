using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_ExpToGoldHandler : MessageLocationHandler<Unit, C2M_ExpToGoldRequest, M2C_ExpToGoldResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ExpToGoldRequest request, M2C_ExpToGoldResponse response)
        {
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            UserInfo userInfo = userInfoComponent.UserInfo;
            ServerInfo serverInfo = ConfigData.ServerInfoList[unit.Zone()];
            if (userInfo.Lv < serverInfo.WorldLv)
            {
                response.Error = ErrorCode.ERR_LevelNoEnough;
                return;
            }

            //背包已满
            if (unit.GetComponent<BagComponentS>().IsBagFullByLoc(ItemLocType.ItemLocBag)) {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            //满级经验兑换效验等级
            GlobalValueConfig globalCof = GlobalValueConfigCategory.Instance.Get(41);
            if (request.OperateType == 2) {
                if (userInfo.Lv < int.Parse(globalCof.Value)) {
                    response.Error = ErrorCode.ERR_ExpNoEnough;
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
                    unit.GetComponent<BagComponentS>().OnAddItemData(rewardItems, String.Empty, $"{ItemGetWay.DuiHuan}_{TimeHelper.ServerNow()}");
                    break;
                case 0:
                    List<int> weights = ListComponent<int>.Create();
                    for (int i = 0; i < ConfigData.ExpToItemList.Count; i++)
                    {
                        weights.Add(ConfigData.ExpToItemList[i].KeyId);
                    }
                    int index = RandomHelper.RandomByWeight(weights);
                    unit.GetComponent<BagComponentS>().OnAddItemData(ConfigData.ExpToItemList[index].Value,  $"{ItemGetWay.DuiHuan}_{TimeHelper.ServerNow()}");
                    break;
                default:
                    break;
            }
            userInfoComponent.UpdateRoleData(UserDataType.Exp, (costExp * -1).ToString());
            unit.GetComponent<NumericComponentS>().ApplyChange(NumericType.ExpToGoldTimes, 1);
            await ETTask.CompletedTask;
        }
    }
}
