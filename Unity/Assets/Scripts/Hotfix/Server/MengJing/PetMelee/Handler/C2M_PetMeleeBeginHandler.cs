using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PetMeleeBeginHandler : MessageLocationHandler<Unit, C2M_PetMeleeBegin, M2C_PetMeleeBegin>
    {
        protected override async ETTask Run(Unit unit, C2M_PetMeleeBegin request, M2C_PetMeleeBegin response)
        {
            // List<Unit> allpet = UnitHelper.GetUnitList(unit.Scene(), UnitType.Pet);
            // for (int i = 0; i < allpet.Count; i++)
            // {
            //     allpet[i].GetComponent<AIComponent>().Begin();
            // }

            unit.Scene().GetComponent<PetMeleeDungeonComponent>().GenerateFuben();

            await ETTask.CompletedTask;
        }
    }
}