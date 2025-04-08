namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_SingleRechargeRewardHandler: MessageLocationHandler<Unit, C2M_SingleRechargeRewardRequest, M2C_SingleRechargeRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_SingleRechargeRewardRequest request, M2C_SingleRechargeRewardResponse response
         )
        {
            UserInfo userInfo = unit.GetComponent<UserInfoComponentS>().UserInfo;
            if (request.RewardId == 0)
            {
                response.RewardIds = userInfo.SingleRechargeIds;
                return;
            }

            if (!ActivityConfigCategory.Instance.Contain(request.RewardId))
            {
                Log.Error($"C2M_SingleRechargeRewardRequest 1");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (!userInfo.SingleRechargeIds.Contains(request.RewardId))
            {
                response.Error = ErrorCode.Pre_Condition_Error;
                return;
            }

            if (userInfo.SingleRewardIds.Contains(request.RewardId))
            {
                response.Error = ErrorCode.ERR_AlreadyReceived;
                return;
            }

            ActivityConfig activityConfig = ActivityConfigCategory.Instance.Get(request.RewardId);
            if (activityConfig.ActivityType != ActivityEnum.Type_35)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            string[] rewarditemlist   =   activityConfig.Par_2.Split('@');
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < rewarditemlist.Length)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            
            bool ret = unit.GetComponent<BagComponentS>().OnAddItemData(activityConfig.Par_2,
                $"{ItemGetWay.ActivityChouKa}_{TimeHelper.ServerNow()}");

            if (ret)
            {
                userInfo.SingleRewardIds.Add(request.RewardId);
                response.RewardIds .AddRange(userInfo.SingleRewardIds); 
            }
            else
            {
                Log.Error($"领取失败: {bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag)} {request.RewardId}");
            }
            await ETTask.CompletedTask;
        }
    }
}