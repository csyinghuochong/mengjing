using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Client
{
    public static class GetTargetHelperc
    {
        //己方位置
        public static Unit GetNearestEnemy(Unit main, float maxdis)
        {
            Unit nearest = null;
            float distance = -1f;
            List<EntityRef<Unit>> units = main.GetParent<UnitComponent>().GetAll();
            for (int i = 0; i < units.Count; i++)
            {
                Unit unit = units[i];
                if (unit.IsDisposed || main.Id == unit.Id)
                {
                    continue;
                }

                float dd = PositionHelper.Distance2D(main.Position, unit.Position);
                if (dd > maxdis || !main.IsCanAttackUnit(unit))
                {
                    continue;
                }

                //找到目标直接跳出来
                if (dd < distance || distance < 0f)
                {
                    distance = dd;
                    nearest = unit;
                }
            }

            return nearest;
        }

    }
}