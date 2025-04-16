namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(TaskComponentS))]
    public class C2M_TaskTrackHandler : MessageLocationHandler<Unit, C2M_TaskTrackRequest, M2C_TaskTrackResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TaskTrackRequest request, M2C_TaskTrackResponse response)
        {
            unit.GetComponent<TaskComponentS>().TaskTrack(request);
            await ETTask.CompletedTask;
        }
    }
}
