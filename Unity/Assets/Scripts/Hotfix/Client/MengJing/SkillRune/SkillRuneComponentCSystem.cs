using System.Collections.Generic;

namespace ET.Client
{
    [EntitySystemOf(typeof(SkillRuneComponentC))]
    [FriendOf(typeof(SkillRuneComponentC))]
    public static partial class SkillRuneComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this SkillRuneComponentC self)
        {
        }

        [EntitySystem]
        private static void Destroy(this SkillRuneComponentC self)
        {
        }

        /// <summary>
        /// 用服务端下发的全量数据刷新本地缓存：响应/推送里直接带 RuneList 和 SlotList
        /// </summary>
        public static void UpdateInfo(this SkillRuneComponentC self, List<SkillRuneInfoProto> runeList, List<SkillRuneSlotInfoProto> slotList)
        {
            self.RuneList.Clear();
            if (runeList != null)
            {
                for (int i = 0; i < runeList.Count; i++)
                {
                    SkillRuneInfo rune = new SkillRuneInfo();
                    rune.FromMessage(runeList[i]);
                    self.RuneList.Add(rune);
                }
            }

            self.SlotList.Clear();
            if (slotList != null)
            {
                for (int i = 0; i < slotList.Count; i++)
                {
                    SkillRuneSlotInfo slotInfo = new SkillRuneSlotInfo();
                    slotInfo.FromMessage(slotList[i]);
                    self.SlotList.Add(slotInfo);
                }
            }
        }

        #region 技能符文背包

        public static List<SkillRuneInfo> GetRuneList(this SkillRuneComponentC self)
        {
            return self.RuneList;
        }

        public static SkillRuneInfo GetRune(this SkillRuneComponentC self, long runeId)
        {
            if (runeId == 0)
            {
                return null;
            }

            for (int i = 0; i < self.RuneList.Count; i++)
            {
                if (self.RuneList[i].Id == runeId)
                {
                    return self.RuneList[i];
                }
            }

            return null;
        }

        public static SkillRuneConfig GetRuneConfig(this SkillRuneComponentC self, SkillRuneInfo rune)
        {
            if (rune == null)
            {
                return null;
            }

            return SkillRuneConfigCategory.Instance.GetOrDefault(rune.ConfigId);
        }

        public static int GetRuneLevel(this SkillRuneComponentC self, SkillRuneInfo rune)
        {
            SkillRuneConfig config = self.GetRuneConfig(rune);
            return config == null ? 0 : config.Level;
        }

        /// <summary>
        /// 技能符文背包：没有被任何技能孔位引用的符文
        /// </summary>
        public static List<SkillRuneInfo> GetBagRuneList(this SkillRuneComponentC self)
        {
            HashSet<long> equippedRuneIds = self.GetEquippedRuneIdSet();

            List<SkillRuneInfo> bagRuneList = new List<SkillRuneInfo>();
            for (int i = 0; i < self.RuneList.Count; i++)
            {
                if (!equippedRuneIds.Contains(self.RuneList[i].Id))
                {
                    bagRuneList.Add(self.RuneList[i]);
                }
            }

            return bagRuneList;
        }

        /// <summary>
        /// 已经镶嵌在技能孔位上的符文
        /// </summary>
        public static List<SkillRuneInfo> GetEquippedRuneList(this SkillRuneComponentC self)
        {
            HashSet<long> equippedRuneIds = self.GetEquippedRuneIdSet();

            List<SkillRuneInfo> runeList = new List<SkillRuneInfo>();
            for (int i = 0; i < self.RuneList.Count; i++)
            {
                if (equippedRuneIds.Contains(self.RuneList[i].Id))
                {
                    runeList.Add(self.RuneList[i]);
                }
            }

            return runeList;
        }

        /// <summary>
        /// 这枚符文镶在哪个技能上，返回基础技能 id，0 表示在背包里
        /// </summary>
        public static int GetEquippedSkillId(this SkillRuneComponentC self, long runeId)
        {
            if (runeId == 0)
            {
                return 0;
            }

            for (int i = 0; i < self.SlotList.Count; i++)
            {
                SkillRuneSlotInfo slotInfo = self.SlotList[i];
                for (int j = 0; j < slotInfo.RuneIds.Count; j++)
                {
                    if (slotInfo.RuneIds[j] == runeId)
                    {
                        return slotInfo.SkillId;
                    }
                }
            }

            return 0;
        }

        public static bool IsRuneEquipped(this SkillRuneComponentC self, long runeId)
        {
            return self.GetEquippedSkillId(runeId) != 0;
        }

        private static HashSet<long> GetEquippedRuneIdSet(this SkillRuneComponentC self)
        {
            HashSet<long> equippedRuneIds = new HashSet<long>();
            for (int i = 0; i < self.SlotList.Count; i++)
            {
                SkillRuneSlotInfo slotInfo = self.SlotList[i];
                for (int j = 0; j < slotInfo.RuneIds.Count; j++)
                {
                    if (slotInfo.RuneIds[j] != 0)
                    {
                        equippedRuneIds.Add(slotInfo.RuneIds[j]);
                    }
                }
            }

            return equippedRuneIds;
        }

        #endregion

        #region 技能孔位

        /// <summary>
        /// 把技能 id（可能是升级后的某一级）换算成基础技能 id；配置不存在返回 0
        /// </summary>
        public static int ToBaseSkillId(this SkillRuneComponentC self, int skillId)
        {
            if (!SkillConfigCategory.Instance.Contain(skillId))
            {
                return 0;
            }

            int baseSkillId = SkillConfigCategory.Instance.GetInitSkill(skillId);
            return baseSkillId == 0 ? skillId : baseSkillId;
        }

        /// <summary>
        /// 取某个技能的孔位数据，没有记录返回 null（= 全是空孔）
        /// </summary>
        public static SkillRuneSlotInfo GetSlot(this SkillRuneComponentC self, int skillId)
        {
            int baseSkillId = self.ToBaseSkillId(skillId);
            if (baseSkillId == 0)
            {
                return null;
            }

            for (int i = 0; i < self.SlotList.Count; i++)
            {
                if (self.SlotList[i].SkillId == baseSkillId)
                {
                    return self.SlotList[i];
                }
            }

            return null;
        }

        /// <summary>
        /// 某个技能指定孔位上的符文 id，0 表示空孔或孔位不存在
        /// </summary>
        public static long GetSlotRuneId(this SkillRuneComponentC self, int skillId, int slotIndex)
        {
            if (slotIndex < 0 || slotIndex >= GlobalValueConfigCategory.Instance.SkillRuneSlotCount)
            {
                return 0;
            }

            SkillRuneSlotInfo slotInfo = self.GetSlot(skillId);
            if (slotInfo == null || slotIndex >= slotInfo.RuneIds.Count)
            {
                return 0;
            }

            return slotInfo.RuneIds[slotIndex];
        }

        /// <summary>
        /// 某个技能的孔位，按 GlobalValueConfig.SkillRuneSlotCount 的个数返回，空孔是 0
        /// </summary>
        public static List<long> GetSkillRuneIds(this SkillRuneComponentC self, int skillId)
        {
            int slotCount = GlobalValueConfigCategory.Instance.SkillRuneSlotCount;
            List<long> runeIds = new List<long>(slotCount);
            SkillRuneSlotInfo slotInfo = self.GetSlot(skillId);
            for (int i = 0; i < slotCount; i++)
            {
                long runeId = 0;
                if (slotInfo != null && i < slotInfo.RuneIds.Count)
                {
                    runeId = slotInfo.RuneIds[i];
                }

                runeIds.Add(runeId);
            }

            return runeIds;
        }

        /// <summary>
        /// 某个技能上已经镶嵌的符文，按孔位顺序
        /// </summary>
        public static List<SkillRuneInfo> GetSkillRuneList(this SkillRuneComponentC self, int skillId)
        {
            List<SkillRuneInfo> runeList = new List<SkillRuneInfo>();
            SkillRuneSlotInfo slotInfo = self.GetSlot(skillId);
            if (slotInfo == null)
            {
                return runeList;
            }

            for (int i = 0; i < slotInfo.RuneIds.Count; i++)
            {
                SkillRuneInfo rune = self.GetRune(slotInfo.RuneIds[i]);
                if (rune != null)
                {
                    runeList.Add(rune);
                }
            }

            return runeList;
        }

        /// <summary>
        /// 某个技能上已经镶嵌的符文配置，按孔位顺序，给界面显示用
        /// </summary>
        public static List<SkillRuneConfig> GetSkillRuneConfigs(this SkillRuneComponentC self, int skillId)
        {
            List<SkillRuneConfig> configs = new List<SkillRuneConfig>();
            SkillRuneSlotInfo slotInfo = self.GetSlot(skillId);
            if (slotInfo == null)
            {
                return configs;
            }

            for (int i = 0; i < slotInfo.RuneIds.Count; i++)
            {
                SkillRuneConfig config = self.GetRuneConfig(self.GetRune(slotInfo.RuneIds[i]));
                if (config != null)
                {
                    configs.Add(config);
                }
            }

            return configs;
        }

        #endregion
    }
}
