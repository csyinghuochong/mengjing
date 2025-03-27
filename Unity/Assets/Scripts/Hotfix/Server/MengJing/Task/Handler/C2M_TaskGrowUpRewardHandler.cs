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
          
            int skillid = ConfigData.TaskGrowUpRewardConfig[request.GrowUpRewardId];
            unit.GetComponent<SkillSetComponentS>().OnAddkillId(skillid, 0, SkillSetEnum.Skill, SkillSourceEnum.Task, true);
            taskComponent.ReceiveGrowUpRewardIds.Add(request.GrowUpRewardId);
            await ETTask.CompletedTask;
        }
    }
}
