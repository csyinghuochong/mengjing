using System.Collections.Generic;

namespace ET
{
    public partial class ShouJiItemConfigCategory
    {
        public Dictionary<int, List<int>> TreasureList = new();
        private List<ItemStarInfo> ItemStarInfos = new List<ItemStarInfo>();

        public override void EndInit()
        {
            foreach (ShouJiItemConfig shoujiConfig in this.GetAll().Values)
            {
                if (shoujiConfig.StartType != 2)
                {
                    continue;
                }

                List<int> treasures = null;
                TreasureList.TryGetValue(shoujiConfig.Chap, out treasures);
                if (treasures == null)
                {
                    treasures = new List<int>();
                    TreasureList.Add(shoujiConfig.Chap, treasures);
                }

                treasures.Add(shoujiConfig.Id);
            }
        }
    }
}