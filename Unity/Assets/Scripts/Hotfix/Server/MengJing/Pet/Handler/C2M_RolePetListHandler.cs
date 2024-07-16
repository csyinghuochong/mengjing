using System;

namespace ET.Server
{
    
	[MessageLocationHandler(SceneType.Map)]
	public class C2M_RolePetListHandler : MessageLocationHandler<Unit, C2M_RolePetList, M2C_RolePetList>
	{
		protected override async ETTask Run(Unit unit, C2M_RolePetList request, M2C_RolePetList response)
		{
			PetComponentS petComponent = unit.GetComponent<PetComponentS>();
			
			response.RolePetInfos = petComponent.GetAllPets();
			response.TeamPetList .AddRange( petComponent.TeamPetList);
			response.PetFormations .AddRange( petComponent.PetFormations);
			response.PetShouHuList .AddRange( petComponent.PetShouHuList);
			response.PetMingList .AddRange( petComponent.PetMingList);
			response.PetMingPosition .AddRange( petComponent.PetMingPosition);
			response.PetCangKuOpen .AddRange( petComponent.PetCangKuOpen);
			
			response.RolePetEggs = petComponent.RolePetEggs;
			response.PetFubenInfos = petComponent.PetFubenInfos;
			response.PetFubeRewardId = petComponent.PetFubeRewardId;
			response.PetSkinList = petComponent.PetSkinList;
			response.PetShouHuActive = petComponent.PetShouHuActive;
			response.RolePetBag = petComponent.RolePetBag;
			
			await ETTask.CompletedTask;
		}

	}
}