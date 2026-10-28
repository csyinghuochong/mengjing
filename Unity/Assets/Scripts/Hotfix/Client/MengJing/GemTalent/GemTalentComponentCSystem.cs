namespace ET.Client
{
    [EntitySystemOf(typeof(GemTalentComponentC))]
    [FriendOf(typeof(GemTalentComponentC))]
    public static partial class GemTalentComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this GemTalentComponentC self)
        {
        }

        [EntitySystem]
        private static void Destroy(this GemTalentComponentC self)
        {
        }

        /// <summary>
        /// 用服务端下发的数据刷新本地缓存
        /// </summary>
        public static void UpdateGemTalentInfo(this GemTalentComponentC self, GemTalentInfo gemTalentInfo)
        {
            if (gemTalentInfo == null)
            {
                return;
            }

            self.GemTalentList.Clear();
            self.GemTalentList.AddRange(gemTalentInfo.GemTalentList);
            self.GemTalentMaxPoint = gemTalentInfo.GemTalentMaxPoint;
        }

        /// <summary>
        /// 总宝石点数：直接取服务端算好的值，客户端不再自己统计装备上的宝石
        /// </summary>
        public static int GetMaxPoint(this GemTalentComponentC self)
        {
            return self.GemTalentMaxPoint;
        }

        /// <summary>
        /// 已消耗的宝石点数
        /// </summary>
        public static int GetUsedPoint(this GemTalentComponentC self)
        {
            return GemTalentHelper.GetUsedPoint(self.GemTalentList);
        }

        /// <summary>
        /// 可用宝石点数 = 总宝石点数 - 已消耗
        /// </summary>
        public static int GetLeftPoint(this GemTalentComponentC self)
        {
            return GemTalentHelper.GetLeftPoint(self.GemTalentList, self.GemTalentMaxPoint);
        }

        /// <summary>
        /// 该宝石天赋节点是否已激活
        /// </summary>
        public static bool HaveGemTalent(this GemTalentComponentC self, int gemTalentId)
        {
            return self.GemTalentList.Contains(gemTalentId);
        }
    }
}
