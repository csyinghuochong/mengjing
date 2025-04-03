using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetMeleePlaceHandler : MessageLocationHandler<Unit, C2M_PetMeleePlace, M2C_PetMeleePlace>
    {
        protected override async ETTask Run(Unit unit, C2M_PetMeleePlace request, M2C_PetMeleePlace response)
        {
            switch (request.MapType)
            {
                case MapTypeEnum.PetMelee:
                    PetMeleeDungeonComponent petMeleeDungeonComponent = unit.Scene().GetComponent<PetMeleeDungeonComponent>();
                    if (petMeleeDungeonComponent.IsGameOver())
                    {
                        response.Error = ErrorCode.ERR_Error;
                        return;
                    }

                    response.Error = petMeleeDungeonComponent.UseCard(request.CarId, request.Position, request.TargetUnitId);

                    break;
                case MapTypeEnum.PetMatch:
                    
                    break;
            }
          
            await ETTask.CompletedTask;
        }
    }
}