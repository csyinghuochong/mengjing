namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemHuiShouHandler: MessageLocationHandler<Unit, C2M_ItemHuiShouRequest, M2C_ItemHuiShouResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemHuiShouRequest request, M2C_ItemHuiShouResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}