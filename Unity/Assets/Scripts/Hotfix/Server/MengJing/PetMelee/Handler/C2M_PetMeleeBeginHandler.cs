using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetMeleeBeginHandler: MessageLocationHandler<Unit, C2M_PetMeleeBegin, M2C_PetMeleeBegin>
    {
        protected override async ETTask Run(Unit unit, C2M_PetMeleeBegin request, M2C_PetMeleeBegin response)
        {
            PetComponentS petComponent = unit.GetComponent<PetComponentS>();

            await ETTask.CompletedTask;
        }
    }
}

