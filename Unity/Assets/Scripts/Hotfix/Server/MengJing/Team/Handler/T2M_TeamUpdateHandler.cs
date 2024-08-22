using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class T2M_TeamUpdateHandler : MessageHandler<Unit, T2M_TeamUpdateRequest>
    {
        protected override async ETTask Run(Unit unit, T2M_TeamUpdateRequest message)
        {
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.TeamId, message.TeamId);

            long rolePetId = unit.GetComponent<PetComponentS>().GetFightPetId();
            Unit unitpet = unit.GetParent<UnitComponent>().Get(rolePetId);
            if (unitpet != null)
            {
                unitpet.GetComponent<NumericComponentS>().ApplyValue(NumericType.TeamId, message.TeamId);
            }

            await ETTask.CompletedTask;
        }
    }
}
