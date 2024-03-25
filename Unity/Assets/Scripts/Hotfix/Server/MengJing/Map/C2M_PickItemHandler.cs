namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof (PetComponentS))]
    [FriendOf(typeof (BagComponentS))]
    public class C2M_PickItemHandler: MessageLocationHandler<Unit, C2M_PickItemRequest, M2C_PickItemResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PickItemRequest request, M2C_PickItemResponse response)
        {
            
            await ETTask.CompletedTask;
        }
    }
}