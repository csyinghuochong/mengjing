using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetMeleePlaceHandler : MessageLocationHandler<Unit, C2M_PetMeleePlace, M2C_PetMeleePlace>
    {
        protected override async ETTask Run(Unit unit, C2M_PetMeleePlace request, M2C_PetMeleePlace response)
        {
            PetComponentS petComponent = unit.GetComponent<PetComponentS>();
            RolePetInfo rolePetInfo = petComponent.GetPetInfo(request.PetId);
            if (rolePetInfo == null)
            {
                response.Error = ErrorCode.ERR_Pet_NoExist;
                return;
            }

            if (unit.GetParent<UnitComponent>().Get(request.PetId) != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                return;
            }

            UnitFactory.CreateTianTiPet(unit.Scene(), unit.Id, CampEnum.CampPlayer_1, rolePetInfo, request.Position, 180, -1);

            await ETTask.CompletedTask;
        }
    }
}