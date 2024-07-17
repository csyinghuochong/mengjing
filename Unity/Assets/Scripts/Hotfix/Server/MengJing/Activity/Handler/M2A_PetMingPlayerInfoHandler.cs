using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Activity)]
    [FriendOf(typeof(ActivitySceneComponent))]
    public class M2A_PetMingPlayerInfoHandler : MessageHandler<Scene, M2A_PetMingPlayerInfoRequest, A2M_PetMingPlayerInfoResponse>
    {

        protected override async ETTask Run(Scene scene, M2A_PetMingPlayerInfoRequest request, A2M_PetMingPlayerInfoResponse response)
        {
            List<PetMingPlayerInfo> petMingPlayerInfos = scene.GetComponent<ActivitySceneComponent>().DBDayActivityInfo.PetMingList;
            for (int i = 0; i < petMingPlayerInfos.Count; i++)
            {
                if (petMingPlayerInfos[i].MineType == request.MingType
                 && petMingPlayerInfos[i].Postion == request.Postion)
                { 
                    response.PetMingPlayerInfo = petMingPlayerInfos[i]; 
                }
            }

            await ETTask.CompletedTask;
        }
    }
}
