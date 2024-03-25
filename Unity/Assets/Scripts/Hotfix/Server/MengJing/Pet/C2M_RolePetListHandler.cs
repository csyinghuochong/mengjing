﻿using System;

namespace ET.Server
{
    
	[MessageLocationHandler(SceneType.Map)]
	public class C2M_RolePetListHandler : MessageLocationHandler<Unit, C2M_RolePetList, M2C_RolePetList>
	{
		protected override async ETTask Run(Unit unit, C2M_RolePetList request, M2C_RolePetList response)
		{
			PetComponentS petComponent = unit.GetComponent<PetComponentS>();
			petComponent.InitPetInfo();
			response.RolePetInfos = petComponent.GetAllPets();
			response.TeamPetList = petComponent.TeamPetList;
			response.RolePetEggs = petComponent.RolePetEggs;
			response.PetFormations = petComponent.PetFormations;
			response.PetFubenInfos = petComponent.PetFubenInfos;
			response.PetFubeRewardId = petComponent.PetFubeRewardId;
			response.PetSkinList = petComponent.PetSkinList;
			response.PetShouHuList = petComponent.PetShouHuList;
			response.PetShouHuActive = petComponent.PetShouHuActive;
            response.PetCangKuOpen = petComponent.PetCangKuOpen;
			response.PetMingList = petComponent.PetMingList;
			response.PetMingPosition = petComponent.PetMingPosition;
			response.RolePetBag = petComponent.RolePetBag;
			
			await ETTask.CompletedTask;
		}

	}
}