using System.Collections.Generic;

namespace ET
{
    public partial class PetBarConfigCategory
    {
        public Dictionary<int, List<int>> PetBarGroupList { get; set; } = new();

        public override void EndInit()
        {
            int index = 0;
            foreach (PetBarConfig petBarConfig in this.GetAll().Values)
            {
                if (petBarConfig.Level == 1)
                {
                    index++;
                    PetBarGroupList.Add(index, new List<int>());
                }

                PetBarGroupList[index].Add(petBarConfig.Id);
            }
        }
    }
}