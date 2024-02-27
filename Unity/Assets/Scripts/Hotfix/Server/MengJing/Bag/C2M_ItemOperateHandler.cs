namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemOperateHandler: MessageLocationHandler<Unit, C2M_ItemOperateRequest, M2C_ItemOperateResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemOperateRequest request, M2C_ItemOperateResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}