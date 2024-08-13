
namespace ET.Server
{ 
    [MessageHandler(SceneType.Activity)]
    [FriendOf(typeof(ActivitySceneComponent))]
    [FriendOf(typeof(DBDayActivityInfo))]
    public class C2A_PetMingChanChuHandler : MessageHandler<Scene, C2A_PetMingChanChuRequest, A2C_PetMingChanChuResponse>
    {
        protected override async ETTask Run(Scene scene, C2A_PetMingChanChuRequest request, A2C_PetMingChanChuResponse response)
        {
            ActivitySceneComponent activitySceneComponent = scene.GetComponent<ActivitySceneComponent>();

            long chanchu = 0;
            if (activitySceneComponent.DBDayActivityInfo.PetMingChanChu.ContainsKey(request.ActorId))
            {
                chanchu = activitySceneComponent.DBDayActivityInfo.PetMingChanChu[request.ActorId];
                activitySceneComponent.DBDayActivityInfo.PetMingChanChu[request.ActorId] = 0;
            }

            A2M_PetMingChanChuRequest a2M_PetMing = A2M_PetMingChanChuRequest.Create();
            a2M_PetMing.UnitID = request.ActorId;
            a2M_PetMing.ChanChu = chanchu;
            
            M2A_PetMingChanChuResponse m2G_RechargeResponse = (M2A_PetMingChanChuResponse)await scene.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Call(request.ActorId, a2M_PetMing);
            if (m2G_RechargeResponse.Error == ErrorCode.ERR_Success)
            {
            }
            await ETTask.CompletedTask;
        }
    }
    
}