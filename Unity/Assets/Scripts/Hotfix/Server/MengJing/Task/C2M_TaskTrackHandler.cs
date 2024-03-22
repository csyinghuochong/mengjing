using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponent_S))]
    public class C2M_TaskTrackHandler : MessageLocationHandler<Unit, C2M_TaskTrackRequest, M2C_TaskTrackResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TaskTrackRequest request, M2C_TaskTrackResponse response)
        {
            unit.GetComponent<TaskComponent_S>().TaskTrack(request);
            await ETTask.CompletedTask;
        }
    }
}
