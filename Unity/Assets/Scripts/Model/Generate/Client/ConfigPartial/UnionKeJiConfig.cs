using System.Collections.Generic;

namespace ET
{
    public partial class UnionKeJiConfigCategory
    {
        public Dictionary<int, List<UnionKeJiConfig>> UnionQiangHuaList = new Dictionary<int, List<UnionKeJiConfig>>();

        public override void EndInit()
        {
            int position = 0;

            foreach (UnionKeJiConfig shoujiConfig in this.GetAll().Values)
            {
                if (!UnionQiangHuaList.ContainsKey(position))
                {
                    UnionQiangHuaList.Add(position, new List<UnionKeJiConfig>());
                }
                UnionQiangHuaList[position].Add(shoujiConfig);
                if (shoujiConfig.NextID == 0)
                {
                    position++;
                }
            }
        }

        public int GetFristId(int position)
        {
            return UnionQiangHuaList[position][0].Id;
        }

        public int GetMaxId(int position)
        {
            return UnionQiangHuaList[position][UnionQiangHuaList[position].Count - 1].Id;
        }

        public bool HavePreId(int preId, List<int> idList)
        {
            if (preId == 0)
            {
                return true;
            }

            foreach (int id in idList)
            {
                if (preId / 100 == id / 100 && preId - id <= 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
