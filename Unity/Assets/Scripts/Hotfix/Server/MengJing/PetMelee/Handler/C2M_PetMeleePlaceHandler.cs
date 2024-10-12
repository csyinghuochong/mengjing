using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetMeleePlaceHandler: MessageLocationHandler<Unit, C2M_PetMeleePlace, M2C_PetMeleePlace>
    {
        protected override async ETTask Run(Unit unit, C2M_PetMeleePlace request, M2C_PetMeleePlace response)
        {
            PetComponentS petComponent = unit.GetComponent<PetComponentS>();
            
            
            
            await ETTask.CompletedTask;
        }
    }
}

