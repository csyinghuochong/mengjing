namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(BagComponentServer))]
    public class C2M_ItemFumoProHandler: MessageLocationHandler<Unit, C2M_ItemFumoProRequest, M2C_ItemFumoProResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ItemFumoProRequest request, M2C_ItemFumoProResponse response)
        {
            BagComponentServer bagComponent = unit.GetComponent<BagComponentServer>();
            if (bagComponent.FuMoItemId == 0)
            {
                return;
            }
            bagComponent.OnEquipFuMo(bagComponent.FuMoItemId, bagComponent.FuMoProList, request.Index);
            await ETTask.CompletedTask;
        }
    }
}