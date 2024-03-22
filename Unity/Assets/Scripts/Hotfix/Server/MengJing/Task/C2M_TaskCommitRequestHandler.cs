using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponent_S))]
    public class C2M_TaskCommitRequestHandler : MessageLocationHandler<Unit, C2M_TaskCommitRequest, M2C_TaskCommitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TaskCommitRequest request, M2C_TaskCommitResponse response)
        {
            if (!TaskConfigCategory.Instance.Contain(request.TaskId))
            {
                return;
            }

            TaskComponent_S taskComponent = unit.GetComponent<TaskComponent_S>();
            response.Error = taskComponent.OnCommitTask(request);
            response.RoleComoleteTaskList = taskComponent.RoleComoleteTaskList;

            await ETTask.CompletedTask;
        }
    }
}
