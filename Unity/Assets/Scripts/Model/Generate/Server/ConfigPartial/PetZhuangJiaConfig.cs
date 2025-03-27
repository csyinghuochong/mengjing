using System.Collections.Generic;

namespace ET
{
    public partial class PetZhuangJiaConfigCategory
    {
        public Dictionary<int, List<PetZhuangJiaConfig>> PetZhuangJiaList = new Dictionary<int, List<PetZhuangJiaConfig>>();

        public override void EndInit()
        {
            int position = 0;

            foreach (PetZhuangJiaConfig petZhuangJiaConfig in this.GetAll().Values)
            {
                if (!PetZhuangJiaList.ContainsKey(position))
                {
                    PetZhuangJiaList.Add(position, new List<PetZhuangJiaConfig>());
                }

                PetZhuangJiaList[position].Add(petZhuangJiaConfig);
                if (petZhuangJiaConfig.NextID == 0)
                {
                    position++;
                }
            }
        }

        public int GetMaxId(int position)
        {
            return PetZhuangJiaList[position][PetZhuangJiaList[position].Count - 1].Id;
        }
    }
}