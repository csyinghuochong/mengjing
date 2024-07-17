namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_SeasonLevelRewardHandler : MessageLocationHandler<Unit, C2M_SeasonLevelRewardRequest, M2C_SeasonLevelRewardResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_SeasonLevelRewardRequest request, M2C_SeasonLevelRewardResponse response)
        {
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();   
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            if (numericComponent.GetAsInt( NumericType.SeasonReward ) >= userInfoComponent.UserInfo.SeasonLevel)
            {
                response.Error = ErrorCode.ERR_Parameter;
                return;
            }

            int rewardLevel = request.SeasonLevel;
            if (numericComponent.GetAsInt(NumericType.SeasonReward) >= rewardLevel )
            {
                Log.Error($"C2M_SeasonLevelRewardRequest 2");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }
            if (userInfoComponent.UserInfo.SeasonLevel < rewardLevel)
            {
                Log.Error($"C2M_SeasonLevelRewardRequest 3");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            SeasonLevelConfig seasonLevelConfig = SeasonLevelConfigCategory.Instance.Get(rewardLevel);
            if (!unit.GetComponent<BagComponentS>().OnAddItemData(seasonLevelConfig.Reward, $"{ItemGetWay.Season}_{seasonLevelConfig.Reward}"))
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            numericComponent.ApplyValue(NumericType.SeasonReward, rewardLevel);
            await ETTask.CompletedTask;
        }
    }
}
