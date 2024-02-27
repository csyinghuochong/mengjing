namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemTreasureOpenHandler: MessageLocationHandler<Unit, C2M_ItemTreasureOpenRequest, M2C_ItemTreasureOpenResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemTreasureOpenRequest request, M2C_ItemTreasureOpenResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}