namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemQiangHuaHandler: MessageLocationHandler<Unit, C2M_ItemQiangHuaRequest, M2C_ItemQiangHuaResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemQiangHuaRequest request, M2C_ItemQiangHuaResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}