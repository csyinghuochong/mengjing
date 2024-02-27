namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemSplitHandler: MessageLocationHandler<Unit, C2M_ItemSplitRequest, M2C_ItemSplitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemSplitRequest request, M2C_ItemSplitResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
}