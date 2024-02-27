namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemDestoryHandler: MessageLocationHandler<Unit, C2M_ItemDestoryRequest, M2C_ItemDestoryResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemDestoryRequest request, M2C_ItemDestoryResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
    
}