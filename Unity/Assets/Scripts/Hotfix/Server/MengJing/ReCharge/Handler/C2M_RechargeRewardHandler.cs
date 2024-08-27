namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_RechargeRewardHandler : MessageLocationHandler<Unit, C2M_RechargeRewardRequest, M2C_RechargeRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_RechargeRewardRequest request, M2C_RechargeRewardResponse response)
        {
            if (!ConfigData.RechargeReward.ContainsKey(request.RechargeNumber))
            {
                Log.Error($"C2M_RechargeRewardRequest 1");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            if (userInfoComponent.UserInfo.RechargeReward.Contains(request.RechargeNumber))
            {
                response.Error = ErrorCode.ERR_AlreadyReceived;
                return;
            }

            long rechargeTotal = unit.GetComponent<NumericComponentS>().GetAsLong(NumericType.RechargeNumber);
            if (rechargeTotal < request.RechargeNumber)
            {
                response.Error = ErrorCode.Pre_Condition_Error;
                return;
            }

            string rewarditem = ConfigData.RechargeReward[request.RechargeNumber];
            string[] rewardList = rewarditem.Split('@');
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < rewardList.Length)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            unit.GetComponent<BagComponentS>().OnAddItemData(rewarditem, $"{93}_{TimeHelper.ServerNow()}");
            userInfoComponent.UserInfo.RechargeReward.Add(request.RechargeNumber);
            await ETTask.CompletedTask;
        }
    }
}
