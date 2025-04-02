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
                case SceneTypeEnum.PetDungeon:
                    petComponent.PetFormations = request.PetFormat;
                    break;
                case SceneTypeEnum.PetTianTi:
                    petComponent.TeamPetList = request.PetFormat;
                    break;
                case SceneTypeEnum.PetMing:
                    petComponent.PetMingList = request.PetFormat;
                    petComponent.PetMingPosition = request.PetPosition;   
                    break;
                case SceneTypeEnum.PetMatch:
                    int insertIndex = ConfigData.PetMatchPetLimit * petComponent.PetMatchPlan;
                    CommonHelp.ReplaceList( petComponent.PetMatchFightList, request.PetFormat, insertIndex );
                    break;
                case SceneTypeEnum.MainCityScene:
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
