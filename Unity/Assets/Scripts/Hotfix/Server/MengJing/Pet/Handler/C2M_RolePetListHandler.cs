namespace ET.Server
{
    
	[MessageLocationHandler(SceneType.Map)]
	public class C2M_RolePetListHandler : MessageLocationHandler<Unit, C2M_RolePetList, M2C_RolePetList>
	{
		protected override async ETTask Run(Unit unit, C2M_RolePetList request, M2C_RolePetList response)
		{
			PetComponentS petComponent = unit.GetComponent<PetComponentS>();
			
			response.RolePetInfos .AddRange(petComponent.RolePetInfos); 
			response.TeamPetList .AddRange( petComponent.TeamPetList);
			response.PetFormations .AddRange( petComponent.PetFormations);
			response.PetShouHuList .AddRange( petComponent.PetShouHuList);
			response.PetMingList .AddRange( petComponent.PetMingList);
			response.PetMingPosition .AddRange( petComponent.PetMingPosition);
			response.PetCangKuOpen .AddRange( petComponent.PetCangKuOpen);
			response.RolePetEggs  .AddRange(  petComponent.RolePetEggs);
			response.PetFubenInfos  .AddRange(  petComponent.PetFubenInfos);
			response.PetSkinList  .AddRange(  petComponent.PetSkinList);
			response.RolePetBag  .AddRange(  petComponent.RolePetBag);
			
			response.PetShouHuActive = petComponent.PetShouHuActive;
			response.PetFubeRewardId = petComponent.PetFubeRewardId;
			await ETTask.CompletedTask;
		}

	}
}