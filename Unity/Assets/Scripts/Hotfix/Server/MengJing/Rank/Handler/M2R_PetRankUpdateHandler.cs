namespace ET.Server
{

    [MessageHandler(SceneType.Rank)]
    public class M2R_PetRankUpdateHandler : MessageHandler<Scene, M2R_PetRankUpdateRequest, R2M_PetRankUpdateResponse>
    {

        protected override async ETTask Run(Scene scene, M2R_PetRankUpdateRequest request, R2M_PetRankUpdateResponse response)
        {
            if (request.Win == CombatResultEnum.Win)
            {
                scene.GetComponent<RankSceneComponent>().OnRecvPetRank(request);
            }
           
            response.SelfRank = scene.GetComponent<RankSceneComponent>().GetPetRank(request.RankPetInfo.UserId);
            await ETTask.CompletedTask;
        }

    }
}
