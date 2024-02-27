namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemQuickPutHandler: MessageLocationHandler<Unit, C2M_ItemQuickPutRequest, M2C_ItemQuickPutResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemQuickPutRequest request, M2C_ItemQuickPutResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}