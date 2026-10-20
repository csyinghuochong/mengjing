namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentS))]
    public class C2M_StoryEndingRewardHandler : MessageLocationHandler<Unit, C2M_StoryEndingRewardRequest, M2C_StoryEndingRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_StoryEndingRewardRequest request, M2C_StoryEndingRewardResponse response)
        {
            TaskComponentS taskComponent = unit.GetComponent<TaskComponentS>();
            if (taskComponent.StoryEndingRewardId != 0)
            {
                response.Error = ErrorCode.ERR_AlreadyReceived;
                response.StoryEndingId = taskComponent.StoryEndingRewardId;
                return;
            }

            if (!StoryHelper.IsAllStoryChosen(taskComponent.StoryInfoList))
            {
                response.Error = ErrorCode.Pre_Condition_Error;
                return;
            }

            StoryHelper.GetStoryValues(taskComponent.StoryInfoList, out int affinity, out int fun, out int violence);
            StoryEndingConfig endingConfig = StoryHelper.GetStoryEndingConfig(affinity, fun, violence);
            if (endingConfig == null || string.IsNullOrEmpty(endingConfig.Reward))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (!unit.GetComponent<BagComponentS>().OnAddItemData(endingConfig.Reward, $"{ItemGetWay.TaskReward}_{TimeHelper.ServerNow()}"))
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            taskComponent.StoryEndingRewardId = endingConfig.Id;
            response.StoryEndingId = endingConfig.Id;
            await ETTask.CompletedTask;
        }
    }
}
