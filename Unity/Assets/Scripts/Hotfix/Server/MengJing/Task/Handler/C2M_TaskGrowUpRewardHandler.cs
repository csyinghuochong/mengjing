namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentS))]
    public class C2M_TaskGrowUpRewardHandler : MessageLocationHandler<Unit, C2M_TaskGrowUpRewardRequest, M2C_TaskGrowUpRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TaskGrowUpRewardRequest request, M2C_TaskGrowUpRewardResponse response)
        {
            TaskComponentS taskComponent = unit.GetComponent<TaskComponentS>();
            if (taskComponent.ReceiveGrowUpRewardIds.Contains(request.GrowUpRewardId))
            {
                response.Error = ErrorCode.ERR_AlreadyReceived;
                return;
            }
            if (!ConfigData.TaskGrowUpRewardConfig.ContainsKey(request.GrowUpRewardId))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }
            //
            // HuoYueRewardConfig huoYueRewardConfig = HuoYueRewardConfigCategory.Instance.Get(request.HuoYueId);
            // long haveHuoyue = unit.GetComponent<TaskComponentS>().GetHuoYueDu();
            // if (haveHuoyue < huoYueRewardConfig.NeedPoint)
            // {
            //     response.Error = ErrorCode.ERR_HouBiNotEnough;
            //     return;
            // }
            //
            // 
            // unit.GetComponent<BagComponentS>().OnAddItemData(huoYueRewardConfig.RewardItems, $"{ItemGetWay.TaskCountry}_{TimeHelper.ServerNow()}");
            //
            // if (huoYueRewardConfig.NeedPoint >= 100)
            // {
            //     unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.HuoYue100Reward_221, 0, 1);
            // }
            
            taskComponent.ReceiveGrowUpRewardIds.Add(request.GrowUpRewardId);
            await ETTask.CompletedTask;
        }
    }
}
