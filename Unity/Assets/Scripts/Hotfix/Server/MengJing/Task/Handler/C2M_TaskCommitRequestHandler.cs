namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentS))]
    public class C2M_TaskCommitRequestHandler : MessageLocationHandler<Unit, C2M_TaskCommitRequest, M2C_TaskCommitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TaskCommitRequest request, M2C_TaskCommitResponse response)
        {
            if (!TaskConfigCategory.Instance.Contain(request.TaskId))
            {
                return;
            }

            TaskComponentS taskComponent = unit.GetComponent<TaskComponentS>();
            response.Error = taskComponent.OnCommitTask(request);
            response.RoleTaskList.AddRange(taskComponent.RoleTaskList); 
            response.RoleComoleteTaskList .AddRange(taskComponent.RoleComoleteTaskList); 
            await ETTask.CompletedTask;
        }
    }
}
