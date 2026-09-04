using System.Collections.Generic;

namespace ET
{
    public partial class EquipXiLianConfigCategory
    {
        public List<EquipXiLianConfig> EquipXiLianLevelList = new List<EquipXiLianConfig>();

        partial void PostInit()
        {
            foreach (EquipXiLianConfig  equipXiLianConfig in this.GetAll().Values)
            {
                if (equipXiLianConfig.XiLianType == 0)
                {
                    EquipXiLianLevelList.Add(equipXiLianConfig);
                }
            }
        }
    }
}