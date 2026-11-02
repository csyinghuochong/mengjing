using System.Collections.Generic;

namespace ET.Client
{
    [EntitySystemOf(typeof(RuneComponentC))]
    [FriendOf(typeof(RuneComponentC))]
    public static partial class RuneComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this RuneComponentC self)
        {
        }

        [EntitySystem]
        private static void Destroy(this RuneComponentC self)
        {
        }

        /// <summary>
        /// 用服务端下发的数据刷新本地缓存：每次请求的响应里都带全量 RuneInfo
        /// </summary>
        public static void UpdateRuneInfo(this RuneComponentC self, RuneInfo runeInfo)
        {
            if (runeInfo == null)
            {
                return;
            }

            self.Shard = runeInfo.Shard;
            self.TotalRuneLv = runeInfo.TotalRuneLv;

            self.RuneList.Clear();
            self.RuneList.AddRange(runeInfo.RuneList);

            self.SlotList.Clear();
            self.SlotList.AddRange(runeInfo.SlotList);
        }

        /// <summary>
        /// 按符文唯一 id 找符文，背包和已镶嵌的都在 RuneList 里
        /// </summary>
        public static RuneData GetRune(this RuneComponentC self, long runeId)
        {
            for (int i = 0; i < self.RuneList.Count; i++)
            {
                if (self.RuneList[i].Id == runeId)
                {
                    return self.RuneList[i];
                }
            }

            return null;
        }

        /// <summary>
        /// 符文当前等级那一行的配置
        /// </summary>
        public static RuneConfig GetRuneConfig(this RuneComponentC self, RuneData rune)
        {
            if (rune == null)
            {
                return null;
            }

            return RuneConfigCategory.Instance.GetOrDefault(rune.ConfigId);
        }

        /// <summary>
        /// 符文等级，直接取配置上的 Lv（一行一级）
        /// </summary>
        public static int GetRuneLv(this RuneComponentC self, RuneData rune)
        {
            RuneConfig runeConfig = self.GetRuneConfig(rune);
            return runeConfig == null ? 0 : runeConfig.Lv;
        }

        /// <summary>
        /// 槽位状态，服务端全发，正常不会找不到
        /// </summary>
        public static RuneSlotInfo GetSlot(this RuneComponentC self, int slotId)
        {
            for (int i = 0; i < self.SlotList.Count; i++)
            {
                if (self.SlotList[i].SlotId == slotId)
                {
                    return self.SlotList[i];
                }
            }

            return null;
        }

        /// <summary>
        /// 槽位是否已解锁
        /// </summary>
        public static bool IsSlotUnlocked(this RuneComponentC self, int slotId)
        {
            RuneSlotInfo slotInfo = self.GetSlot(slotId);
            return slotInfo != null && slotInfo.Unlocked;
        }

        /// <summary>
        /// 槽位里镶嵌的符文 id，0 表示空槽
        /// </summary>
        public static long GetSlotRuneId(this RuneComponentC self, int slotId)
        {
            RuneSlotInfo slotInfo = self.GetSlot(slotId);
            return slotInfo == null ? 0 : slotInfo.RuneId;
        }

        /// <summary>
        /// 槽位里镶嵌的符文
        /// </summary>
        public static RuneData GetSlotRune(this RuneComponentC self, int slotId)
        {
            return self.GetRune(self.GetSlotRuneId(slotId));
        }

        /// <summary>
        /// 这枚符文是否已经镶在某个槽位里
        /// </summary>
        public static bool IsRuneSocketed(this RuneComponentC self, long runeId)
        {
            for (int i = 0; i < self.SlotList.Count; i++)
            {
                if (self.SlotList[i].RuneId == runeId)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 已镶嵌的符文，按槽位顺序排
        /// </summary>
        public static List<RuneData> GetSocketedRuneList(this RuneComponentC self)
        {
            List<RuneData> runeList = new List<RuneData>();
            for (int i = 0; i < self.SlotList.Count; i++)
            {
                if (self.SlotList[i].RuneId == 0)
                {
                    continue;
                }

                RuneData rune = self.GetRune(self.SlotList[i].RuneId);
                if (rune != null)
                {
                    runeList.Add(rune);
                }
            }

            return runeList;
        }

        /// <summary>
        /// 背包里的符文：没被任何槽位引用的那些
        /// </summary>
        public static List<RuneData> GetBagRuneList(this RuneComponentC self)
        {
            List<RuneData> runeList = new List<RuneData>();
            for (int i = 0; i < self.RuneList.Count; i++)
            {
                if (self.IsRuneSocketed(self.RuneList[i].Id))
                {
                    continue;
                }

                runeList.Add(self.RuneList[i]);
            }

            return runeList;
        }
    }
}
