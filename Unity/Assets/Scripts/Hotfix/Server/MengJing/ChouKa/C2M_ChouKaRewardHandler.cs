namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_ChouKaRewardHandler : MessageLocationHandler<Unit, C2M_ChouKaRewardRequest, M2C_ChouKaRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ChouKaRewardRequest request, M2C_ChouKaRewardResponse response)
        {
            UserInfoComponentS userInfoComponent= unit.GetComponent<UserInfoComponentS>();
            if (userInfoComponent.UserInfo.ChouKaRewardIds.Contains(request.RewardId))
            {
                response.Error = ErrorCode.ERR_AlreadyReceived;
                return;
            }
            if (!TakeCardRewardConfigCategory.Instance.Contain(request.RewardId))
            {
                Log.Error($"C2M_ChouKaRewardError {unit.Id} {request.RewardId}");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }
            TakeCardRewardConfig rewardConfig = TakeCardRewardConfigCategory.Instance.Get(request.RewardId);
            if (unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.ChouKa) < rewardConfig.RoseLvLimit)
            {
                response.Error = ErrorCode.Pre_Condition_Error;
                return;
            }
            string[] rewarditemlist = rewardConfig.RewardItems.Split('@');
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < rewarditemlist.Length)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            userInfoComponent.UserInfo.ChouKaRewardIds.Add(request.RewardId);
            int randomZuanshi = RandomHelper.RandomNumber(rewardConfig.RewardDiamond[0], rewardConfig.RewardDiamond[1]);
            unit.GetComponent<BagComponentS>().OnAddItemData(rewardConfig.RewardItems, $"{ItemGetWay.ChouKa}_{TimeHelper.ServerNow()}");
            unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneyAdd(  UserDataType.Diamond, randomZuanshi.ToString(),true, ItemGetWay.ChouKa);
            
            await ETTask.CompletedTask;
        }
    }
}
