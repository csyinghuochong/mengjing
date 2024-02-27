namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemOneSellHandler: MessageLocationHandler<Unit, C2M_ItemOneSellRequest, M2C_ItemOneSellResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemOneSellRequest request, M2C_ItemOneSellResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}