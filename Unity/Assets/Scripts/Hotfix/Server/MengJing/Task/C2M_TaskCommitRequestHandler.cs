using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentServer))]
    public class C2M_TaskCommitRequestHandler : MessageLocationHandler<Unit, C2M_TaskCommitRequest, M2C_TaskCommitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TaskCommitRequest request, M2C_TaskCommitResponse response)
        {
            if (!TaskConfigCategory.Instance.Contain(request.TaskId))
            {
                return;
            }

            TaskComponentServer taskComponent = unit.GetComponent<TaskComponentServer>();
            response.Error = taskComponent.OnCommitTask(request);
            response.RoleComoleteTaskList = taskComponent.RoleComoleteTaskList;

            await ETTask.CompletedTask;
        }
    }
}
