using System;

namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RolePetSkinSetHandler : MessageLocationHandler<Unit, C2M_RolePetSkinSet, M2C_RolePetSkinSet>
    {
        protected override async ETTask Run(Unit unit, C2M_RolePetSkinSet request, M2C_RolePetSkinSet response)
        {
            PetComponent_S petComponent = unit.GetComponent<PetComponent_S>();
            RolePetInfo rolePetInfo = petComponent.GetPetInfo(request.PetInfoId);
            rolePetInfo.SkinId = request.SkinId;

            petComponent.UpdatePetAttribute(rolePetInfo, true);
            Unit unitPet = unit.GetParent<UnitComponent>().Get(request.PetInfoId);
            if (unitPet != null)
            {
                unitPet.GetComponent<NumericComponent_S>().SetEvent(NumericType.PetSkin, rolePetInfo.SkinId, true);
            }

            await ETTask.CompletedTask;
        }
    }
}
