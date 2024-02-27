namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemFumoUseHandler: MessageLocationHandler<Unit, C2M_ItemFumoUseRequest, M2C_ItemFumoUseResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemFumoUseRequest request, M2C_ItemFumoUseResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}