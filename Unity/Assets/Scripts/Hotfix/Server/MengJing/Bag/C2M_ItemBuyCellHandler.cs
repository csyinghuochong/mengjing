namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_ItemBuyCellHandler: MessageLocationHandler<Unit, C2M_ItemBuyCellRequest, M2C_ItemBuyCellResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemBuyCellRequest request, M2C_ItemBuyCellResponse response)
        {
            await ETTask.CompletedTask;
        }
    }
    
}