namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemProtectHandler: MessageLocationHandler<Unit, C2M_ItemProtectRequest, M2C_ItemProtectResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemProtectRequest request, M2C_ItemProtectResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}