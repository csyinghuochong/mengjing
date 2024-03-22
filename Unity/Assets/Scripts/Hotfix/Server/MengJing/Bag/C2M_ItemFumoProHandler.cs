namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(BagComponent_S))]
    public class C2M_ItemFumoProHandler: MessageLocationHandler<Unit, C2M_ItemFumoProRequest, M2C_ItemFumoProResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemFumoProRequest request, M2C_ItemFumoProResponse response)
        {
            BagComponent_S bagComponent = unit.GetComponent<BagComponent_S>();
            if (bagComponent.FuMoItemId == 0)
            {
                return;
            }
            bagComponent.OnEquipFuMo(bagComponent.FuMoItemId, bagComponent.FuMoProList, request.Index);
            await ETTask.CompletedTask;
        }
    }
}