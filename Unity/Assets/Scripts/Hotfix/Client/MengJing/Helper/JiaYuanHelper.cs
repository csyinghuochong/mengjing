using System.Collections.Generic;

namespace ET.Client
{
    public static partial class JiaYuanHelper
    {
        public static Unit GetUnitByCellIndex(Scene curScene, int cellIndex)
        {
            List<Unit> allunits = UnitHelper.GetUnitList(curScene, UnitType.Plant);
            for (int i = 0; i < allunits.Count; i++)
            {
                if (allunits[i].GetComponent<NumericComponentC>().GetAsInt(NumericType.GatherCellIndex) == cellIndex)
                {
                    return allunits[i];
                }
            }

            return null;
        }
    }
}