namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(ChengJiuComponentS))]
    public class C2M_JingLingActiveHandler : MessageLocationHandler<Unit, C2M_JingLingActiveRequest, M2C_JingLingActiveResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_JingLingActiveRequest request, M2C_JingLingActiveResponse response)
        {
            ChengJiuComponentS chengJiuComponent = unit.GetComponent<ChengJiuComponentS>();
            chengJiuComponent.OnActiveJingLing(request.JingLingId);

            await ETTask.CompletedTask;
        }
    }
}