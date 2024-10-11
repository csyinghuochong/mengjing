using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_CreateUnitsHandler : MessageHandler<Scene, M2C_CreateUnits>
    {
        protected override async ETTask Run(Scene root, M2C_CreateUnits message)
        {
            Scene currentScene = root.CurrentScene();
            using ListComponent<long> allunitids = ListComponent<long>.Create();
            UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();

            foreach (UnitInfo unitInfo in message.Units)
            {
                allunitids.Add(unitInfo.UnitId);

                if (CheckUnitExist(unitComponent, unitInfo.UnitId, unitInfo.Position.x, unitInfo.Position.y, unitInfo.Position.z))
                {
                    continue;
                }

                if (unitInfo.Type == UnitType.Monster && !SettingData.ShowMonster)
                {
                    continue;
                }

                if (unitInfo.Type == UnitType.DropItem)
                {
                    UnitFactory.CreateDropItem(currentScene, unitInfo);
                }
                else if (unitInfo.Type == UnitType.CellTransfers)
                {
                    UnitFactory.CreateTransferItem(currentScene, unitInfo);
                }
                else
                {
                    UnitFactory.CreateUnit(currentScene, unitInfo);
                }
            }

            if (message.UpdateAll == 1)
            {
                //移除不存在的unit. 只检测玩家 。怪物和掉落
                List<EntityRef<Unit>> allunits = unitComponent.GetAll();
                for (int i = allunits.Count - 1; i >= 0; i--)
                {
                    Unit unit = allunits[i];
                    int unitType = unit.Type;
                    if (unitType != UnitType.Player && unitType != UnitType.Monster && unitType != UnitType.DropItem)
                    {
                        continue;
                    }

                    if (unit.MainHero)
                    {
                        continue;
                    }

                    if (!allunitids.Contains(unit.Id))
                    {
                        unitComponent.Remove(unit.Id);
                        continue;
                    }
                }
            }

            await ETTask.CompletedTask;
        }

        private bool CheckUnitExist(UnitComponent unitComponent, long unitid, float x, float y, float z)
        {
            if (unitComponent.Get(unitid) != null)
            {
                unitComponent.Get(unitid).Position = new float3(x, y, z);
                return true;
            }

            return false;
        }
    }
}