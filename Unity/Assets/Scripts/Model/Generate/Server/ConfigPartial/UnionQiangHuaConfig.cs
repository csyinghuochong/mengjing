﻿using System.Collections.Generic;

namespace ET
{
    public partial class UnionQiangHuaConfigCategory
    {
        public Dictionary<int, List<UnionQiangHuaConfig>> UnionQiangHuaList = new Dictionary<int, List<UnionQiangHuaConfig>>();

        public override void EndInit()
        {
            int position = 0;

            foreach (UnionQiangHuaConfig shoujiConfig in this.GetAll().Values)
            {
                if (!UnionQiangHuaList.ContainsKey(position))
                {
                    UnionQiangHuaList.Add(position, new List<UnionQiangHuaConfig>());
                }
                UnionQiangHuaList[position].Add(shoujiConfig);
                if (shoujiConfig.NextID == 0)
                {
                    position++;
                }
            }
        }

        public int GetMaxId(int position)
        {
            return UnionQiangHuaList[position][UnionQiangHuaList[position].Count - 1].Id;
        }

    }
}
