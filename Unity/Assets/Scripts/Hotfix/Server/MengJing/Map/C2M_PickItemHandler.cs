namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof (PetComponent_S))]
    [FriendOf(typeof (BagComponent_S))]
    public class C2M_PickItemHandler: MessageLocationHandler<Unit, C2M_PickItemRequest, M2C_PickItemResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PickItemRequest request, M2C_PickItemResponse response)
        {
            
            await ETTask.CompletedTask;
        }
    }
}