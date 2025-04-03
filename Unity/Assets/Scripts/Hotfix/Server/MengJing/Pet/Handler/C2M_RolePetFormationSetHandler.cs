namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RolePetFormationSetHandler : MessageLocationHandler<Unit, C2M_RolePetFormationSet, M2C_RolePetFormationSet>
    {
        protected override async ETTask Run(Unit unit, C2M_RolePetFormationSet request, M2C_RolePetFormationSet response)
        {
            PetComponentS petComponent = unit.GetComponent<PetComponentS>();
            switch (request.SceneType)
            {
                case MapTypeEnum.PetDungeon:
                    petComponent.PetFormations = request.PetFormat;
                    break;
                case MapTypeEnum.PetTianTi:
                    petComponent.TeamPetList = request.PetFormat;
                    break;
                case MapTypeEnum.PetMing:
                    petComponent.PetMingList = request.PetFormat;
                    petComponent.PetMingPosition = request.PetPosition;   
                    break;
                case MapTypeEnum.MainCityScene:
                    // TransferHelper.RemoveFightPetList(unit,request.PetFormat );
                    // petComponent.PetFightList = request.PetFormat; //通过布阵界面设置出战宠物
                    // TransferHelper.CreateFightPetList(unit);
                    break;
            }
            UnitCacheHelper.SaveComponentCache( unit.Root(),  petComponent).Coroutine();

            await ETTask.CompletedTask;
        }
    }
}
