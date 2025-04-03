namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_RandomTowerRewardHandler : MessageLocationHandler<Unit, C2M_RandomTowerRewardRequest, M2C_RandomTowerRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_RandomTowerRewardRequest request, M2C_RandomTowerRewardResponse response)
        {
            if (!TowerConfigCategory.Instance.Contain(request.RewardId))
            {
                Log.Error($"C2M_RandomTowerRewardRequest 1");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }


            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            if (userInfoComponent.UserInfo.TowerRewardIds.Contains(request.RewardId))
            {
                response.Error = ErrorCode.ERR_AlreadyReceived;
                return;
            }

            int sceneType = request.SceneType;  

            if (sceneType == MapTypeEnum.TrialDungeon)
            {
                int passId = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.TrialDungeonId);
                if (passId < request.RewardId )
                {
                    Log.Error($"C2M_RandomTowerRewardRequest 2");
                    response.Error = ErrorCode.ERR_ModifyData;
                    return;
                }
            }

            if (sceneType != MapTypeEnum.TrialDungeon)
            {
                Log.Error($"C2M_RandomTowerRewardRequest 3");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            TowerConfig towerRewardConfig = TowerConfigCategory.Instance.Get(request.RewardId);

            string userName = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;
            Log.Warning($"试炼之地领取奖励： 区:{unit.Zone()}   {unit.Id}   {request.RewardId}  {userName}  {unit.GetComponent<UserInfoComponentS>().UserInfo.Lv}");

            if (unit.GetComponent<BagComponentS>().OnAddItemData(towerRewardConfig.DropShow, $"{ItemGetWay.RandomTowerReward}_{TimeHelper.ServerNow()}"))
            {
                userInfoComponent.UserInfo.TowerRewardIds.Add(request.RewardId);
            }
            else
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }
            await ETTask.CompletedTask;
        }
    }
}
