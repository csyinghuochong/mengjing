namespace ET.Server
{
    
	[MessageLocationHandler(SceneType.Map)]
	public class C2M_RolePetFightHandler : MessageLocationHandler<Unit, C2M_RolePetFight, M2C_RolePetFight>
	{
		protected override async ETTask Run(Unit unit, C2M_RolePetFight request, M2C_RolePetFight response)
		{
			RolePetInfo petinfo = unit.GetComponent<PetComponentS>().GetPetInfo(request.PetInfoId);
			if (petinfo == null)
			{
                response.Error = ErrorCode.ERR_Pet_NoExist;
				return;
			}
			
            if (petinfo.PetStatus == 2 || petinfo.PetStatus == 3)
            {
	            response.Error = ErrorCode.ERR_Pet_NotFight;
                return;
            }
            
            //最多出战三个
            if (request.PetStatus == 1)
            {
                //出战要清掉之前的
                RolePetInfo fightpet =  unit.GetComponent<PetComponentS>().GetFightPet();
                if (fightpet != null)
                {
                    fightpet.PetStatus = 0;
                    unit.GetParent<UnitComponent>().Remove(fightpet.Id);
                }
                if (unit.GetParent<UnitComponent>().Get(petinfo.Id) == null)
                {
                    unit.GetComponent<PetComponentS>().UpdatePetAttribute(petinfo, false);
                    UnitFactory.CreatePet(unit, petinfo);
                }

                petinfo.PetStatus = request.PetStatus;
            }
            else
            {
                //休息
                petinfo.PetStatus = request.PetStatus;
                unit.GetParent<UnitComponent>().Remove(petinfo.Id);
            }
            
           
			await ETTask.CompletedTask;
		}
	}
}