namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RolePetListHandler : MessageLocationHandler<Unit, C2M_RolePetList, M2C_RolePetList>
    {
        protected override async ETTask Run(Unit unit, C2M_RolePetList request, M2C_RolePetList response)
        {
            PetComponentS petComponent = unit.GetComponent<PetComponentS>();

            response.RolePetInfos.AddRange(petComponent.RolePetInfos);
            response.TeamPetList.AddRange(petComponent.TeamPetList);
            response.PetFormations.AddRange(petComponent.PetFormations);
            response.PetShouHuList.AddRange(petComponent.PetShouHuList);
            response.PetMingList.AddRange(petComponent.PetMingList);
            response.PetMingPosition.AddRange(petComponent.PetMingPosition);
            response.PetCangKuOpen.AddRange(petComponent.PetCangKuOpen);
            response.RolePetEggs.AddRange(petComponent.RolePetEggs);
            response.PetFubenInfos.AddRange(petComponent.PetFubenInfos);
            response.PetSkinList.AddRange(petComponent.PetSkinList);
            response.RolePetBag.AddRange(petComponent.RolePetBag);

            response.PetShouHuActive = petComponent.PetShouHuActive;
            response.PetFubeRewardId = petComponent.PetFubeRewardId;

            response.PetFightPlan = petComponent.PetFightPlan;
            response.PetFightList_1.AddRange(petComponent.PetFightList_1);
            response.PetFightList_2.AddRange(petComponent.PetFightList_2);
            response.PetFightList_3.AddRange(petComponent.PetFightList_3);
            response.PetBarConfigList.AddRange(petComponent.PetBarConfigList);
            
            response.PetMeleePlan = petComponent.PetMeleePlan;
            response.PetMeleeInfoList.AddRange(petComponent.PetMeleeInfoList);
            response.PetMeleeFubenInfos.AddRange(petComponent.PetMeleeFubenInfos);
            response.PetMeleeRewardIds.AddRange(petComponent.PetMeleeRewardIds);
            response.PetMeleeFubeRewardIds.AddRange(petComponent.PetMeleeFubeRewardIds);
            response.PetEchoList.AddRange(petComponent.PetEchoList);
            response.PetZhuangJiaList.AddRange(petComponent.PetZhuangJiaList);

            await ETTask.CompletedTask;
        }
    }
}