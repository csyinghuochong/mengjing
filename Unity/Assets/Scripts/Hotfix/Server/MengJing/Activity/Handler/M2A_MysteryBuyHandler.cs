namespace ET.Server
{

    [MessageHandler(SceneType.Activity)]
    [FriendOf(typeof(ActivitySceneComponent))]
    public class M2A_MysteryBuyHandler : MessageHandler<Scene, M2A_MysteryBuyRequest, A2M_MysteryBuyResponse>
    {
        protected override async ETTask Run(Scene scene, M2A_MysteryBuyRequest request, A2M_MysteryBuyResponse response)
        {
            response.Error = scene.GetComponent<ActivitySceneComponent>().OnMysteryBuyRequest(request.MysteryItemInfo);
            
            await ETTask.CompletedTask;
        }
    }
}
