using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponent_S))]
    public class C2M_TaskNoticeRequestHandler : MessageLocationHandler<Unit, C2M_TaskNoticeRequest, M2C_TaskNoticeResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TaskNoticeRequest request, M2C_TaskNoticeResponse response)
        {
            unit.GetComponent<TaskComponent_S>().OnTaskNotice(request);
            await ETTask.CompletedTask;
        }
    }
}