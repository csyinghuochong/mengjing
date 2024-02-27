namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemOperateWearHandler: MessageLocationHandler<Unit, C2M_ItemOperateWearRequest, M2C_ItemOperateWearResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemOperateWearRequest request, M2C_ItemOperateWearResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}