using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.PetMatch)]
    public class C2PetMatch_RankListHandler : MessageHandler<Scene, C2PetMatch_RankListRequest, PetMatch2C_RankListResponse>
    {
        protected override async ETTask Run(Scene scene, C2PetMatch_RankListRequest request, PetMatch2C_RankListResponse response)
        {
            PetMatchSceneComponent soloSceneComponent = scene.GetComponent<PetMatchSceneComponent>();

            List<PetMatchPlayerInfo> petMatchPlayerInfos =  soloSceneComponent.GetSoloResult();
            response.PetMatchPlayerInfoList .AddRange( petMatchPlayerInfos );

            if (response.PetMatchPlayerInfoList.Count == 0)
            {
                PetMatchPlayerInfo petMatchPlayerInfo = PetMatchPlayerInfo.Create();
                petMatchPlayerInfo.UnitId = 1;
                petMatchPlayerInfo.Name = "XX";
                petMatchPlayerInfo.Occ = 2;
                petMatchPlayerInfo.Score = 100;
                petMatchPlayerInfo.RankId = 3;
            }

            await ETTask.CompletedTask;
        }
    }
}
