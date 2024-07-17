using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_TowerExitHandler : MessageLocationHandler<Unit, C2M_TowerExitRequest, M2C_TowerExitResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TowerExitRequest request, M2C_TowerExitResponse response)
        {
            UnitComponent unitComponent = unit.GetParent<UnitComponent>();
            List<EntityRef<Unit>> allunits = unitComponent.GetAll();
            for (int i = allunits.Count - 1; i >= 0; i--)
            {
                Unit uniitem = allunits[i];
                if (uniitem.Type == UnitType.Monster)
                {
                    unitComponent.Remove(uniitem.Id);
                }
            }
            TowerComponent towerComponent = unit.Scene().GetComponent<TowerComponent>();
            if (towerComponent == null)
            {
                Log.Debug($"towerComponent == null:  zone:{ unit.Zone() }  unitid: {unit.Id}");
                return;
            }

            if (towerComponent.TowerId == 0)
            {
                towerComponent.OnEmptyReward();
            }
            else
            {
                towerComponent.OnTowerOver("TowerExit");
            }
            await ETTask.CompletedTask;
        }
    }
}
