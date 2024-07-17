namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RolePetSkinSetHandler : MessageLocationHandler<Unit, C2M_RolePetSkinSet, M2C_RolePetSkinSet>
    {
        protected override async ETTask Run(Unit unit, C2M_RolePetSkinSet request, M2C_RolePetSkinSet response)
        {
            PetComponentS petComponent = unit.GetComponent<PetComponentS>();
            RolePetInfo rolePetInfo = petComponent.GetPetInfo(request.PetInfoId);
            rolePetInfo.SkinId = request.SkinId;

            petComponent.UpdatePetAttribute(rolePetInfo, true);
            Unit unitPet = unit.GetParent<UnitComponent>().Get(request.PetInfoId);
            if (unitPet != null)
            {
                unitPet.GetComponent<NumericComponentS>().ApplyValue(NumericType.PetSkin, rolePetInfo.SkinId, true);
            }

            await ETTask.CompletedTask;
        }
    }
}
