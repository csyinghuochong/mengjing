using System;

namespace ET.Server
{
    
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_RolePetFormationSetHandler : MessageLocationHandler<Unit, C2M_RolePetFormationSet, M2C_RolePetFormationSet>
    {
        protected override async ETTask Run(Unit unit, C2M_RolePetFormationSet request, M2C_RolePetFormationSet response)
        {
            PetComponent petComponent = unit.GetComponent<PetComponent>();
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
            }
            DBHelper.SaveComponent( unit.DomainZone(), unit.Id, petComponent).Coroutine();
            reply();
            await ETTask.CompletedTask;
        }
    }
}
