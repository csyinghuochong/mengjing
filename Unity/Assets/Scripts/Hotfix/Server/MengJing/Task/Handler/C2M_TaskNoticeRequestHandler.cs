using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentS))]
    public class C2M_TaskNoticeRequestHandler : MessageLocationHandler<Unit, C2M_TaskNoticeRequest, M2C_TaskNoticeResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TaskNoticeRequest request, M2C_TaskNoticeResponse response)
        {
            unit.GetComponent<TaskComponentS>().OnTaskNotice(request);
            await ETTask.CompletedTask;
        }
    }
}