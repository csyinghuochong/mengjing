namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentS))]
    public class C2M_TaskHuoYueRewardHandler : MessageLocationHandler<Unit, C2M_TaskHuoYueRewardRequest, M2C_TaskHuoYueRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TaskHuoYueRewardRequest request, M2C_TaskHuoYueRewardResponse response)
        {
            TaskComponentS taskComponent = unit.GetComponent<TaskComponentS>();
            if (taskComponent.ReceiveHuoYueIds.Contains(request.HuoYueId))
            {
                response.Error = ErrorCode.ERR_AlreadyReceived;
                return;
            }
            if (!HuoYueRewardConfigCategory.Instance.Contain(request.HuoYueId))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            HuoYueRewardConfig huoYueRewardConfig = HuoYueRewardConfigCategory.Instance.Get(request.HuoYueId);
            long haveHuoyue = unit.GetComponent<TaskComponentS>().GetHuoYueDu();
            if (haveHuoyue < huoYueRewardConfig.NeedPoint)
            {
                response.Error = ErrorCode.ERR_HouBiNotEnough;
                return;
            }

            taskComponent.ReceiveHuoYueIds.Add(request.HuoYueId);
            unit.GetComponent<BagComponentS>().OnAddItemData(huoYueRewardConfig.RewardItems, $"{ItemGetWay.TaskCountry}_{TimeHelper.ServerNow()}");

            if (huoYueRewardConfig.NeedPoint >= 100)
            {
                unit.GetComponent<ChengJiuComponentS>().TriggerEvent(ChengJiuTargetEnum.HuoYue100Reward_221, 0, 1);
            }
            await ETTask.CompletedTask;
        }
    }
}
