namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemFumoProHandler: MessageLocationHandler<Unit, C2M_ItemFumoProRequest, M2C_ItemFumoProResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemFumoProRequest request, M2C_ItemFumoProResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}