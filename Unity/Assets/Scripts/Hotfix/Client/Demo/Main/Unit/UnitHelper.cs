using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{
    public static partial class UnitHelper
    {
        public static List<Unit> GetUnitList(Scene currentScene, int unitType)
        {
            List<Unit> list = new List<Unit>();
            List<Unit> allunits = currentScene.GetComponent<UnitComponent>().GetAll();
            for (int i = 0; i < allunits.Count; i++)
            {
                if (allunits[i].Type == unitType)
                {
                    list.Add(allunits[i]);
                }
            }

            return list;
        }

        public static Unit GetMyUnitFromClientScene(Scene root)
        {
            PlayerComponent playerComponent = root.GetComponent<PlayerComponent>();
            Scene currentScene = root.GetComponent<CurrentScenesComponent>().Scene;
            return currentScene.GetComponent<UnitComponent>().Get(playerComponent.MyId);
        }
        
        public static Unit GetMyUnitFromCurrentScene(Scene currentScene)
        {
            PlayerComponent playerComponent = currentScene.Root().GetComponent<PlayerComponent>();
            return currentScene.GetComponent<UnitComponent>().Get(playerComponent.MyId);
        }

        public static List<Unit> GetUnitsByType(Scene root, int unitType)
        {
            List<Unit> units = new List<Unit>();
            foreach (Unit unit in root.CurrentScene().GetComponent<UnitComponent>().GetAll())
            {
                if (unit.Type == unitType)
                {
                    units.Add(unit);
                }
            }

            return units;
        }

        public static float3 GetBornPostion(this Unit self)
        {
            NumericComponentC numericComponent = self.GetComponent<NumericComponentC>();
            return new float3(numericComponent.GetAsFloat(NumericType.Born_X),
                numericComponent.GetAsFloat(NumericType.Born_Y),
                numericComponent.GetAsFloat(NumericType.Born_Z));
        }
        
        public static bool IsChest(this Unit self)
        {
            if (self.Type != UnitType.Monster)
            {
                return false;
            }
            int sonType = MonsterConfigCategory.Instance.Get(self.ConfigId).MonsterSonType;
            return sonType == 55 || sonType == 56 || sonType == 57;
        }
    }
}