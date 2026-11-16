using System.Collections.Generic;

namespace ET.Server
{
    /// <summary>
    /// 技能符文数据系统：技能符文背包、每个技能的孔位、获得/镶嵌/卸下。
    /// 孔位数量读 GlobalValueConfig.SkillRuneSlotCount，
    /// 施法时按当前技能的孔位读取生效的符文属性。
    /// </summary>
    [EntitySystemOf(typeof(SkillRuneComponent))]
    [FriendOf(typeof(SkillRuneComponent))]
    public static partial class SkillRuneComponentSystem
    {
        [EntitySystem]
        private static void Awake(this SkillRuneComponent self)
        {
            self.RuneList ??= new List<SkillRuneInfo>();
            self.SlotList ??= new List<SkillRuneSlotInfo>();

            NormalizeSlotList(self);
        }

        [EntitySystem]
        private static void Destroy(this SkillRuneComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this SkillRuneComponent self)
        {
            self.RuneList ??= new List<SkillRuneInfo>();
            self.SlotList ??= new List<SkillRuneSlotInfo>();

            NormalizeSlotList(self);
        }

        /// <summary>
        /// 老数据或手改数据可能缺孔位，按 GlobalValueConfig.SkillRuneSlotCount 补足；
        /// 配置改小后多出来的孔位直接截掉，上面的符文回到背包
        /// </summary>
        private static void NormalizeSlotList(this SkillRuneComponent self)
        {
            int slotCount = GlobalValueConfigCategory.Instance.SkillRuneSlotCount;
            for (int i = 0; i < self.SlotList.Count; i++)
            {
                SkillRuneSlotInfo slotData = self.SlotList[i];
                slotData.RuneIds ??= new List<long>();
                while (slotData.RuneIds.Count < slotCount)
                {
                    slotData.RuneIds.Add(0);
                }

                while (slotData.RuneIds.Count > slotCount)
                {
                    slotData.RuneIds.RemoveAt(slotData.RuneIds.Count - 1);
                }
            }
        }

        #region 技能符文背包

        public static List<SkillRuneInfo> GetRuneList(this SkillRuneComponent self)
        {
            return self.RuneList;
        }

        public static SkillRuneInfo GetRune(this SkillRuneComponent self, long runeId)
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

        /// <summary>
        /// 这枚技能符文当前等级的配置
        /// </summary>
        public static SkillRuneConfig GetRuneConfig(this SkillRuneComponent self, long runeId)
        {
            SkillRuneInfo rune = self.GetRune(runeId);
            if (rune == null)
            {
                return null;
            }

            return SkillRuneConfigCategory.Instance.GetOrDefault(rune.ConfigId);
        }

        public static int GetRuneLevel(this SkillRuneComponent self, long runeId)
        {
            SkillRuneConfig config = self.GetRuneConfig(runeId);
            return config == null ? 0 : config.Level;
        }

        /// <summary>
        /// 获得一枚技能符文，configId 传 SkillRuneConfig 里该符文 1 级那一行的 Id
        /// </summary>
        public static SkillRuneInfo AddRune(this SkillRuneComponent self, int configId)
        {
            SkillRuneConfig config = SkillRuneConfigCategory.Instance.GetOrDefault(configId);
            if (config == null)
            {
                return null;
            }

            SkillRuneInfo rune = new SkillRuneInfo();
            rune.Id = IdGenerater.Instance.GenerateId();
            rune.ConfigId = config.Id;
            self.RuneList.Add(rune);
            return rune;
        }

        /// <summary>
        /// 移除一枚技能符文，镶嵌中的先从孔位里摘掉
        /// </summary>
        public static bool RemoveRune(this SkillRuneComponent self, long runeId)
        {
            SkillRuneInfo rune = self.GetRune(runeId);
            if (rune == null)
            {
                return false;
            }

            self.ClearRuneSlot(runeId);
            self.RuneList.Remove(rune);
            return true;
        }

        /// <summary>
        /// 技能符文背包：没有被任何技能孔位引用的符文
        /// </summary>
        public static List<SkillRuneInfo> GetBagRuneList(this SkillRuneComponent self)
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
        public static List<SkillRuneInfo> GetEquippedRuneList(this SkillRuneComponent self)
        {
            List<SkillRuneInfo> runeList = new List<SkillRuneInfo>();
            HashSet<long> equippedRuneIds = self.GetEquippedRuneIdSet();
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
        public static int GetEquippedSkillId(this SkillRuneComponent self, long runeId)
        {
            if (runeId == 0)
            {
                return 0;
            }

            for (int i = 0; i < self.SlotList.Count; i++)
            {
                List<long> runeIds = self.SlotList[i].RuneIds;
                for (int j = 0; j < runeIds.Count; j++)
                {
                    if (runeIds[j] == runeId)
                    {
                        return self.SlotList[i].SkillId;
                    }
                }
            }

            return 0;
        }

        public static bool IsRuneEquipped(this SkillRuneComponent self, long runeId)
        {
            return self.GetEquippedSkillId(runeId) != 0;
        }

        private static HashSet<long> GetEquippedRuneIdSet(this SkillRuneComponent self)
        {
            HashSet<long> equippedRuneIds = new HashSet<long>();
            for (int i = 0; i < self.SlotList.Count; i++)
            {
                List<long> runeIds = self.SlotList[i].RuneIds;
                for (int j = 0; j < runeIds.Count; j++)
                {
                    if (runeIds[j] != 0)
                    {
                        equippedRuneIds.Add(runeIds[j]);
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
        public static int ToBaseSkillId(this SkillRuneComponent self, int skillId)
        {
            if (!SkillConfigCategory.Instance.Contain(skillId))
            {
                return 0;
            }

            int baseSkillId = SkillConfigCategory.Instance.GetInitSkill(skillId);
            return baseSkillId == 0 ? skillId : baseSkillId;
        }

        public static List<SkillRuneSlotInfo> GetSlotList(this SkillRuneComponent self)
        {
            return self.SlotList;
        }

        /// <summary>
        /// 取某个技能的孔位数据，没有记录返回 null（= 全是空孔）
        /// </summary>
        public static SkillRuneSlotInfo GetSlotData(this SkillRuneComponent self, int skillId)
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
        /// 取某个技能的孔位数据，没有记录就补一条全空孔的数据
        /// </summary>
        public static SkillRuneSlotInfo GetOrCreateSlotData(this SkillRuneComponent self, int skillId)
        {
            int baseSkillId = self.ToBaseSkillId(skillId);
            if (baseSkillId == 0)
            {
                return null;
            }

            SkillRuneSlotInfo slotData = self.GetSlotData(baseSkillId);
            if (slotData != null)
            {
                return slotData;
            }

            slotData = new SkillRuneSlotInfo();
            slotData.SkillId = baseSkillId;
            int slotCount = GlobalValueConfigCategory.Instance.SkillRuneSlotCount;
            while (slotData.RuneIds.Count < slotCount)
            {
                slotData.RuneIds.Add(0);
            }

            self.SlotList.Add(slotData);
            return slotData;
        }

        /// <summary>
        /// 某个技能指定孔位上的符文 id，0 表示空孔或孔位不存在
        /// </summary>
        public static long GetSlotRuneId(this SkillRuneComponent self, int skillId, int slotIndex)
        {
            if (slotIndex < 0 || slotIndex >= GlobalValueConfigCategory.Instance.SkillRuneSlotCount)
            {
                return 0;
            }

            SkillRuneSlotInfo slotData = self.GetSlotData(skillId);
            if (slotData == null || slotIndex >= slotData.RuneIds.Count)
            {
                return 0;
            }

            return slotData.RuneIds[slotIndex];
        }

        /// <summary>
        /// 某个技能的孔位，按 GlobalValueConfig.SkillRuneSlotCount 的个数返回，空孔是 0。给下发消息用
        /// </summary>
        public static List<long> GetSkillRuneIds(this SkillRuneComponent self, int skillId)
        {
            int slotCount = GlobalValueConfigCategory.Instance.SkillRuneSlotCount;
            List<long> runeIds = new List<long>(slotCount);
            SkillRuneSlotInfo slotData = self.GetSlotData(skillId);
            for (int i = 0; i < slotCount; i++)
            {
                long runeId = 0;
                if (slotData != null && i < slotData.RuneIds.Count)
                {
                    runeId = slotData.RuneIds[i];
                }

                runeIds.Add(runeId);
            }

            return runeIds;
        }

        /// <summary>
        /// 某个技能上已经镶嵌的符文，按孔位顺序
        /// </summary>
        public static List<SkillRuneInfo> GetSkillRuneList(this SkillRuneComponent self, int skillId)
        {
            List<SkillRuneInfo> runeList = new List<SkillRuneInfo>();
            SkillRuneSlotInfo slotData = self.GetSlotData(skillId);
            if (slotData == null)
            {
                return runeList;
            }

            for (int i = 0; i < slotData.RuneIds.Count; i++)
            {
                SkillRuneInfo rune = self.GetRune(slotData.RuneIds[i]);
                if (rune != null)
                {
                    runeList.Add(rune);
                }
            }

            return runeList;
        }

        /// <summary>
        /// 某个技能上已经镶嵌的符文配置，按孔位顺序。
        /// </summary>
        public static List<SkillRuneConfig> GetSkillRuneConfigs(this SkillRuneComponent self, int skillId)
        {
            List<SkillRuneConfig> configs = new List<SkillRuneConfig>();
            SkillRuneSlotInfo slotData = self.GetSlotData(skillId);
            if (slotData == null)
            {
                return configs;
            }

            for (int i = 0; i < slotData.RuneIds.Count; i++)
            {
                SkillRuneConfig config = self.GetRuneConfig(slotData.RuneIds[i]);
                if (config != null)
                {
                    configs.Add(config);
                }
            }

            return configs;
        }

        public static IReadOnlyList<SkillRuneEffect> GetSkillRuneEffects(this SkillRuneComponent self, int skillId)
        {
            if (self.SlotList.Count == 0)
            {
                return null;
            }

            SkillRuneSlotInfo slotData = self.GetSlotData(skillId);
            if (slotData == null)
            {
                return null;
            }

            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillId);
            List<SkillRuneEffect> effects = null;
            for (int i = 0; i < slotData.RuneIds.Count && skillConfig.SkillLv >= SkillHelp.GetSkillRuneSlotUnlockLevel(i); i++)
            {
                SkillRuneConfig runeConfig = self.GetRuneConfig(slotData.RuneIds[i]);
                if (runeConfig?.AddPropreList?.Count > 0)
                {
                    effects ??= new List<SkillRuneEffect>();
                    effects.AddRange(runeConfig.AddPropreList);
                }
            }

            return effects;
        }

        public static float GetRuneSkillProperty(this IReadOnlyList<SkillRuneEffect> effects, SkillAttributeEnum attribute, float targetHpRatio = 1f)
        {
            float value = 0f;
            if (effects == null)
            {
                return value;
            }

            for (int i = 0; i < effects.Count; i++)
            {
                if (effects[i] is SkillRunePropertyAdd property && property.Attribute == attribute
                    && (property.TargetHpBelow == 0f || targetHpRatio < property.TargetHpBelow))
                {
                    value += property.Value;
                }
            }

            return value;
        }

        public static float GetRuneBuffProperty(this IReadOnlyList<SkillRuneEffect> effects, SkillRuneBuffTarget target, BuffAttributeEnum attribute)
        {
            float value = 0f;
            if (effects == null || target == SkillRuneBuffTarget.None)
            {
                return value;
            }

            for (int i = 0; i < effects.Count; i++)
            {
                if (effects[i] is SkillRuneBuffPropertyAdd property && property.Target == target && property.Attribute == attribute)
                {
                    value += property.Value;
                }
            }

            return value;
        }

        #endregion

        #region 镶嵌

        /// <summary>
        /// 把符文镶嵌到某个技能的指定孔位。
        /// 孔位上已有符文时直接替换，旧符文回到背包；一枚符文同一时间只能装在一个孔位里
        /// </summary>
        public static int OnEquipRune(this SkillRuneComponent self, int skillId, int slotIndex, long runeId)
        {
            int baseSkillId = self.ToBaseSkillId(skillId);
            if (baseSkillId == 0)
            {
                return ErrorCode.ERR_ModifyData;
            }

            if (slotIndex < 0 || slotIndex >= GlobalValueConfigCategory.Instance.SkillRuneSlotCount)
            {
                return ErrorCode.ERR_RuneSlotNotExist;
            }

            if (self.GetRune(runeId) == null)
            {
                return ErrorCode.ERR_RuneNotExist;
            }

            SkillConfig skillConfig = self.FindLearnedActiveSkillConfig(baseSkillId);
            if (skillConfig == null)
            {
                return ErrorCode.ERR_ModifyData;
            }

            if (skillConfig.SkillLv < SkillHelp.GetSkillRuneSlotUnlockLevel(slotIndex))
            {
                return ErrorCode.ERR_RuneSlotLock;
            }

            //同一枚符文只能装在一个孔里
            int equippedSkillId = self.GetEquippedSkillId(runeId);
            if (equippedSkillId != 0
                && !(equippedSkillId == baseSkillId && self.GetSlotRuneId(baseSkillId, slotIndex) == runeId))
            {
                return ErrorCode.ERR_RuneEquipped;
            }

            SkillRuneSlotInfo slotData = self.GetOrCreateSlotData(baseSkillId);
            slotData.RuneIds[slotIndex] = runeId;
            return ErrorCode.ERR_Success;
        }

        /// <summary>
        /// 卸下某个技能指定孔位上的符文，符文本身留在背包
        /// </summary>
        public static int OnUnequipRune(this SkillRuneComponent self, int skillId, int slotIndex)
        {
            int baseSkillId = self.ToBaseSkillId(skillId);
            if (baseSkillId == 0)
            {
                return ErrorCode.ERR_ModifyData;
            }

            if (slotIndex < 0 || slotIndex >= GlobalValueConfigCategory.Instance.SkillRuneSlotCount)
            {
                return ErrorCode.ERR_RuneSlotNotExist;
            }

            SkillRuneSlotInfo slotData = self.GetSlotData(baseSkillId);
            if (slotData == null || slotIndex >= slotData.RuneIds.Count || slotData.RuneIds[slotIndex] == 0)
            {
                return ErrorCode.ERR_RuneSlotEmpty;
            }

            slotData.RuneIds[slotIndex] = 0;
            self.RemoveSlotIfEmpty(slotData);
            return ErrorCode.ERR_Success;
        }

        /// <summary>
        /// 卸下所有技能符文并同步孔位，保留玩家拥有的符文。
        /// </summary>
        public static void UnequipAllRunes(this SkillRuneComponent self)
        {
            if (self.SlotList.Count == 0)
            {
                return;
            }

            self.SlotList.Clear();
            self.SyncToClient();
        }

        /// <summary>
        /// 技能被移除（装备/天赋/龙印等来源的技能收回）时调用：
        /// 清掉这个技能的孔位，上面的符文自动回到背包
        /// </summary>
        public static bool OnRemoveSkill(this SkillRuneComponent self, int skillId)
        {
            SkillRuneSlotInfo slotData = self.GetSlotData(skillId);
            if (slotData == null)
            {
                return false;
            }

            self.SlotList.Remove(slotData);
            return true;
        }

        /// <summary>
        /// 道具技能不能镶嵌。武器技能按当前装备转换后，再匹配客户端提交的技能所属等级链。
        /// </summary>
        private static SkillConfig FindLearnedActiveSkillConfig(this SkillRuneComponent self, int baseSkillId)
        {
            Unit unit = self.GetParent<Unit>();
            SkillSetComponentS skillSetComponent = unit.GetComponent<SkillSetComponentS>();
            if (skillSetComponent == null)
            {
                return null;
            }

            List<SkillPro> skillList = skillSetComponent.GetSkillList();
            int weaponType = unit.GetEquipType();
            SkillConfigCategory skillConfigs = SkillConfigCategory.Instance;
            SkillConfig matchingConfig = null;
            foreach (SkillPro skill in skillList)
            {
                SkillConfig skillConfig = skillConfigs.GetOrDefault(skill.SkillID);
                if (skill.SkillSetType == SkillSetEnum.Item || skillConfig == null)
                {
                    continue;
                }

                int weaponSkillId = SkillHelp.GetWeaponSkill(skill.SkillID, weaponType, skillList);
                SkillConfig weaponSkillConfig = skillConfigs.GetOrDefault(weaponSkillId);
                if (self.IsMatchingActiveSkill(weaponSkillConfig, baseSkillId))
                {
                    skillConfig = weaponSkillConfig;
                }
                else if (!self.IsMatchingActiveSkill(skillConfig, baseSkillId))
                {
                    continue;
                }

                if (matchingConfig == null || skillConfig.SkillLv > matchingConfig.SkillLv)
                {
                    matchingConfig = skillConfig;
                }
            }

            return matchingConfig;
        }

        private static bool IsMatchingActiveSkill(this SkillRuneComponent self, SkillConfig skillConfig, int baseSkillId)
        {
            return skillConfig?.SkillType == (int)SkillTypeEnum.ActiveSkill && self.ToBaseSkillId(skillConfig.Id) == baseSkillId;
        }

        /// <summary>
        /// 从所有孔位里清掉这枚符文的引用
        /// </summary>
        private static void ClearRuneSlot(this SkillRuneComponent self, long runeId)
        {
            for (int i = self.SlotList.Count - 1; i >= 0; i--)
            {
                SkillRuneSlotInfo slotData = self.SlotList[i];
                bool changed = false;
                for (int j = 0; j < slotData.RuneIds.Count; j++)
                {
                    if (slotData.RuneIds[j] != runeId)
                    {
                        continue;
                    }

                    slotData.RuneIds[j] = 0;
                    changed = true;
                }

                if (changed)
                {
                    self.RemoveSlotIfEmpty(slotData);
                }
            }
        }

        private static bool IsSlotEmpty(SkillRuneSlotInfo slotData)
        {
            for (int i = 0; i < slotData.RuneIds.Count; i++)
            {
                if (slotData.RuneIds[i] != 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 孔位全空了就把这条技能孔位记录删掉，避免存档里堆积空记录
        /// </summary>
        private static void RemoveSlotIfEmpty(this SkillRuneComponent self, SkillRuneSlotInfo slotData)
        {
            if (IsSlotEmpty(slotData))
            {
                self.SlotList.Remove(slotData);
            }
        }

        #endregion

        #region 存档/协议转换

        /// <summary>
        /// 存档结构转协议结构：把全部符文实例和孔位记录填到协议列表里
        /// </summary>
        public static void ToMessage(this SkillRuneComponent self, List<SkillRuneInfoProto> runeList, List<SkillRuneSlotInfoProto> slotList)
        {
            runeList.Clear();
            for (int i = 0; i < self.RuneList.Count; i++)
            {
                runeList.Add(self.RuneList[i].ToMessage());
            }

            slotList.Clear();
            for (int i = 0; i < self.SlotList.Count; i++)
            {
                slotList.Add(self.SlotList[i].ToMessage());
            }
        }

        /// <summary>
        /// 协议结构整体覆盖存档：清掉现有数据再按协议重建，谨慎使用
        /// </summary>
        public static void FromMessage(this SkillRuneComponent self, List<SkillRuneInfoProto> runeList, List<SkillRuneSlotInfoProto> slotList)
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

            NormalizeSlotList(self);
        }

        /// <summary>
        /// 主动把最新技能符文数据下发给客户端：GM 加符文这类不是客户端发起的变化
        /// </summary>
        public static void SyncToClient(this SkillRuneComponent self)
        {
            M2C_SkillRuneInfoMessage message = M2C_SkillRuneInfoMessage.Create();
            self.ToMessage(message.RuneList, message.SlotList);
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), message);
        }

        #endregion
    }
}
