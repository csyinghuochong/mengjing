using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetMeleePlaceHandler : MessageLocationHandler<Unit, C2M_PetMeleePlace, M2C_PetMeleePlace>
    {
        protected override async ETTask Run(Unit unit, C2M_PetMeleePlace request, M2C_PetMeleePlace response)
        {
            PetMeleeDungeonComponent petMeleeDungeonComponent = unit.Scene().GetComponent<PetMeleeDungeonComponent>();
            if (petMeleeDungeonComponent.IsGameOver())
            {
                response.Error = ErrorCode.ERR_Error;
                return;
            }

            PetComponentS petComponent = unit.GetComponent<PetComponentS>();
            RolePetInfo rolePetInfo = petComponent.GetPetInfo(request.CarId);
            if (rolePetInfo == null)
            {
                response.Error = ErrorCode.ERR_Pet_NoExist;
                return;
            }

            List<Unit> allpet = UnitHelper.GetUnitList(unit.Scene(), UnitType.Pet);
            // 防止招太多
            if (allpet.Count > 10)
            {
                response.Error = ErrorCode.ERR_Error;
                return;
            }

            // 单条战线最多几个宠物。。。

            // // 不能存在相同的宠物
            // if (unit.GetParent<UnitComponent>().Get(request.PetId) != null)
            // {
            //     response.Error = ErrorCode.ERR_RequestRepeatedly;
            //     return;
            // }

            // 目前是可以重复放一个宠物
            Unit pet = UnitFactory.CreateTianTiPet(unit.Scene(), unit.Id, CampEnum.CampPlayer_1, rolePetInfo, request.Position, 90, -1,
                IdGenerater.Instance.GenerateId());

            if (petMeleeDungeonComponent.IsGameStart())
            {
                pet.GetComponent<AIComponent>().Begin();
            }

            await ETTask.CompletedTask;
        }
    }
}