namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentS))]
    public class C2M_TaskGiveUpHandler : MessageLocationHandler<Unit, C2M_TaskGiveUpRequest, M2C_TaskGiveUpResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TaskGiveUpRequest request, M2C_TaskGiveUpResponse response)
        {
            TaskConfig taskConfig = TaskConfigCategory.Instance.Get(request.TaskId);
            if (taskConfig.TaskType == TaskTypeEnum.Ring)
            {
                return;
            }

            TaskComponentS taskComponent = unit.GetComponent<TaskComponentS>();
            taskComponent.OnRecvGiveUpTask(request.TaskId);
            await ETTask.CompletedTask;
        }
    }
}
