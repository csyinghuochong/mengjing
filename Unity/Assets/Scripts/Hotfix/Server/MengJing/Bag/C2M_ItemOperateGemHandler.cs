namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemOperateGemHandler: MessageLocationHandler<Unit, C2M_ItemOperateGemRequest, M2C_ItemOperateGemResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemOperateGemRequest request, M2C_ItemOperateGemResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}