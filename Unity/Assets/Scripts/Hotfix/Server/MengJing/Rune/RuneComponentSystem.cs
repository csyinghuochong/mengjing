using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(RuneComponent))]
    [FriendOf(typeof(RuneComponent))]
    public static partial class RuneComponentSystem
    {
        [EntitySystem]
        private static void Awake(this RuneComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this RuneComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this RuneComponent self)
        {
        }

        #region 符文碎片

        public static void AddShard(this RuneComponent self, int shard)
        {
            if (shard <= 0)
            {
                return;
            }

            self.Shard += shard;
        }

        /// <summary>
        /// 扣碎片，不够返回 false 且不扣
        /// </summary>
        public static bool CostShard(this RuneComponent self, int shard)
        {
            if (shard <= 0)
            {
                return true;
            }

            if (self.Shard < shard)
            {
                return false;
            }

            self.Shard -= shard;
            return true;
        }

        #endregion

        #region 符文

        public static RuneData GetRune(this RuneComponent self, long runeId)
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
        /// 这枚符文当前等级的配置
        /// </summary>
        public static RuneConfig GetRuneConfig(this RuneComponent self, long runeId)
        {
            RuneData rune = self.GetRune(runeId);
            if (rune == null)
            {
                return null;
            }

            return RuneConfigCategory.Instance.GetOrDefault(rune.ConfigId);
        }

        /// <summary>
        /// 获得一枚符文，configId 传 RuneConfig 里该符文 1 级那一行的 Id
        /// </summary>
        public static RuneData AddRune(this RuneComponent self, int configId)
        {
            RuneConfig config = RuneConfigCategory.Instance.GetOrDefault(configId);
            if (config == null)
            {
                return null;
            }

            RuneData rune = RuneData.Create();
            rune.Id = IdGenerater.Instance.GenerateId();
            rune.ConfigId = config.Id;
            self.RuneList.Add(rune);
            return rune;
        }

        /// <summary>
        /// 移除一枚符文，镶嵌中的先从槽位里摘掉
        /// </summary>
        public static bool RemoveRune(this RuneComponent self, long runeId)
        {
            RuneData rune = self.GetRune(runeId);
            if (rune == null)
            {
                return false;
            }

            RuneSlotData slotData = self.GetSocketedSlot(runeId);
            if (slotData != null)
            {
                slotData.RuneId = 0;
            }

            self.RuneList.Remove(rune);
            return true;
        }

        /// <summary>
        /// 符文总等级：只算已镶嵌在槽位里的符文，等级查配置的 Lv，背包里的不算。
        /// 槽位解锁条件 UnlockRuneTotalLv 按这个值判断
        /// </summary>
        public static int GetTotalRuneLv(this RuneComponent self)
        {
            int totalLv = 0;
            for (int i = 0; i < self.SlotList.Count; i++)
            {
                if (self.SlotList[i].RuneId == 0)
                {
                    continue;
                }

                RuneConfig config = self.GetRuneConfig(self.SlotList[i].RuneId);
                if (config != null)
                {
                    totalLv += config.Lv;
                }
            }

            return totalLv;
        }

        #endregion

        #region 槽位

        /// <summary>
        /// 取槽位状态，没有记录返回 null（=未解锁且空槽）
        /// </summary>
        public static RuneSlotData GetSlotData(this RuneComponent self, int slotId)
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
        /// 解锁槽位时用：没有记录就补一条，默认未解锁、空槽
        /// </summary>
        public static RuneSlotData GetOrCreateSlotData(this RuneComponent self, int slotId)
        {
            RuneSlotData slotData = self.GetSlotData(slotId);
            if (slotData != null)
            {
                return slotData;
            }

            slotData = new RuneSlotData();
            slotData.SlotId = slotId;
            self.SlotList.Add(slotData);
            return slotData;
        }

        public static bool IsSlotUnlocked(this RuneComponent self, int slotId)
        {
            RuneSlotData slotData = self.GetSlotData(slotId);
            return slotData != null && slotData.Unlocked;
        }

        /// <summary>
        /// 槽位里镶嵌的符文 id，0 表示空槽
        /// </summary>
        public static long GetSlotRuneId(this RuneComponent self, int slotId)
        {
            RuneSlotData slotData = self.GetSlotData(slotId);
            return slotData == null ? 0 : slotData.RuneId;
        }

        /// <summary>
        /// 这枚符文镶在哪个槽，null 表示没镶嵌
        /// </summary>
        public static RuneSlotData GetSocketedSlot(this RuneComponent self, long runeId)
        {
            for (int i = 0; i < self.SlotList.Count; i++)
            {
                if (self.SlotList[i].RuneId == runeId)
                {
                    return self.SlotList[i];
                }
            }

            return null;
        }

        #endregion

        #region 解锁

        /// <summary>
        /// 槽位能否解锁，ERR_Success 表示可以（已解锁的也算可以，解锁本身是幂等的）
        /// </summary>
        public static int GetUnlockSlotError(this RuneComponent self, int slotId)
        {
            RuneSlotConfig slotConfig = RuneSlotConfigCategory.Instance.GetOrDefault(slotId);
            if (slotConfig == null)
            {
                return ErrorCode.ERR_RuneSlotNotExist;
            }

            if (self.IsSlotUnlocked(slotId))
            {
                return ErrorCode.ERR_Success;
            }

            Unit unit = self.GetParent<Unit>();
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            if (userInfoComponent == null)
            {
                return ErrorCode.ERR_ModifyData;
            }

            if (userInfoComponent.GetUserLv() < slotConfig.UnlockLv)
            {
                return ErrorCode.ERR_RuneSlotLevel;
            }

            if (self.GetTotalRuneLv() < slotConfig.UnlockRuneTotalLv)
            {
                return ErrorCode.ERR_RuneSlotTotalLv;
            }

            return ErrorCode.ERR_Success;
        }

        /// <summary>
        /// 解锁槽位：玩家等级和符文总等级都够了就永久解锁
        /// </summary>
        public static int OnUnlockSlot(this RuneComponent self, int slotId)
        {
            int error = self.GetUnlockSlotError(slotId);
            if (error != ErrorCode.ERR_Success)
            {
                return error;
            }

            RuneSlotData slotData = self.GetOrCreateSlotData(slotId);
            slotData.Unlocked = true;
            return ErrorCode.ERR_Success;
        }

        #endregion

        #region 镶嵌

        /// <summary>
        /// 镶嵌：槽位已解锁、是空的，且符文类型和槽位类型一致才行。符文镶上后仍留在 RuneList 里，只是被槽位引用
        /// </summary>
        public static int OnSocketRune(this RuneComponent self, int slotId, long runeId)
        {
            RuneSlotConfig slotConfig = RuneSlotConfigCategory.Instance.GetOrDefault(slotId);
            if (slotConfig == null)
            {
                return ErrorCode.ERR_RuneSlotNotExist;
            }

            if (!self.IsSlotUnlocked(slotId))
            {
                return ErrorCode.ERR_RuneSlotLock;
            }

            RuneSlotData slotData = self.GetOrCreateSlotData(slotId);
            if (slotData.RuneId != 0)
            {
                return ErrorCode.ERR_RuneSlotOccupied;
            }

            RuneConfig runeConfig = self.GetRuneConfig(runeId);
            if (runeConfig == null)
            {
                return ErrorCode.ERR_RuneNotExist;
            }

            if (runeConfig.RuneType != slotConfig.RuneType)
            {
                return ErrorCode.ERR_RuneTypeError;
            }

            //同一枚符文只能镶在一个槽里
            if (self.GetSocketedSlot(runeId) != null)
            {
                return ErrorCode.ERR_RuneEquipped;
            }

            slotData.RuneId = runeId;
            return ErrorCode.ERR_Success;
        }

        /// <summary>
        /// 卸下槽位里的符文，符文本身留在背包
        /// </summary>
        public static int OnUnsocketRune(this RuneComponent self, int slotId)
        {
            if (RuneSlotConfigCategory.Instance.GetOrDefault(slotId) == null)
            {
                return ErrorCode.ERR_RuneSlotNotExist;
            }

            RuneSlotData slotData = self.GetSlotData(slotId);
            if (slotData == null || slotData.RuneId == 0)
            {
                return ErrorCode.ERR_RuneSlotEmpty;
            }

            slotData.RuneId = 0;
            return ErrorCode.ERR_Success;
        }

        #endregion

        #region 升级分解

        /// <summary>
        /// 升级：消耗当前等级那一行的 UpgradeCost 碎片，配置换成 NextId，NextId 为 0 表示满级。
        /// 镶嵌中的符文也能升，槽位引用的是 id，不受影响
        /// </summary>
        public static int OnUpgradeRune(this RuneComponent self, long runeId)
        {
            RuneData rune = self.GetRune(runeId);
            if (rune == null)
            {
                return ErrorCode.ERR_RuneNotExist;
            }

            RuneConfig config = RuneConfigCategory.Instance.GetOrDefault(rune.ConfigId);
            if (config == null)
            {
                return ErrorCode.ERR_RuneNotExist;
            }

            if (config.NextId == 0)
            {
                return ErrorCode.ERR_RuneMaxLv;
            }

            RuneConfig nextConfig = RuneConfigCategory.Instance.GetOrDefault(config.NextId);
            if (nextConfig == null)
            {
                return ErrorCode.ERR_RuneMaxLv;
            }

            if (!self.CostShard(config.UpgradeCost))
            {
                return ErrorCode.ERR_RuneShardNotEnough;
            }

            rune.ConfigId = nextConfig.Id;
            return ErrorCode.ERR_Success;
        }

        /// <summary>
        /// 分解：按当前等级那一行的 DecomposeShard 返还碎片。镶嵌中的要先卸下
        /// </summary>
        public static int OnDecomposeRune(this RuneComponent self, long runeId)
        {
            RuneConfig config = self.GetRuneConfig(runeId);
            if (config == null)
            {
                return ErrorCode.ERR_RuneNotExist;
            }

            if (self.GetSocketedSlot(runeId) != null)
            {
                return ErrorCode.ERR_RuneEquipped;
            }

            self.RemoveRune(runeId);
            self.AddShard(config.DecomposeShard);
            return ErrorCode.ERR_Success;
        }

        #endregion

        #region 下发数据

        /// <summary>
        /// 下发给客户端的符文数据：碎片、拥有的符文、所有槽位、符文总等级
        /// </summary>
        public static RuneInfo GetInfo(this RuneComponent self)
        {
            RuneInfo info = RuneInfo.Create();
            info.Shard = self.Shard;
            info.TotalRuneLv = self.GetTotalRuneLv();

            //符文全发，槽位里引用的是同一个 id，客户端自己区分背包和已镶嵌
            for (int i = 0; i < self.RuneList.Count; i++)
            {
                RuneData runeInfo = RuneData.Create();
                runeInfo.Id = self.RuneList[i].Id;
                runeInfo.ConfigId = self.RuneList[i].ConfigId;
                info.RuneList.Add(runeInfo);
            }

            //槽位按配置顺序全发，客户端不用自己补没记录的槽位
            List<RuneSlotConfig> slotConfigs = RuneSlotConfigCategory.Instance.DataList;
            for (int i = 0; i < slotConfigs.Count; i++)
            {
                RuneSlotData slotData = self.GetSlotData(slotConfigs[i].Id);

                RuneSlotInfo slotInfo = RuneSlotInfo.Create();
                slotInfo.SlotId = slotConfigs[i].Id;
                slotInfo.Unlocked = slotData != null && slotData.Unlocked;
                slotInfo.RuneId = slotData == null ? 0 : slotData.RuneId;
                info.SlotList.Add(slotInfo);
            }

            return info;
        }

        /// <summary>
        /// 主动把最新的符文数据下发给客户端：GM 加符文这类不是客户端发起的变化
        /// </summary>
        public static void SyncToClient(this RuneComponent self)
        {
            M2C_RuneInfoMessage message = M2C_RuneInfoMessage.Create();
            message.Info = self.GetInfo();
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), message);
        }

        #endregion

        #region 属性

        /// <summary>
        /// 已镶嵌符文提供的效果。属性只算镶进槽位的，背包里的不生效。
        /// RuneConfig.AddPropreList 现在还是空的，配了才会有内容
        /// </summary>
        public static List<PropEffect> GetEffects(this RuneComponent self)
        {
            List<PropEffect> effects = new List<PropEffect>();
            for (int i = 0; i < self.SlotList.Count; i++)
            {
                if (self.SlotList[i].RuneId == 0)
                {
                    continue;
                }

                RuneConfig config = self.GetRuneConfig(self.SlotList[i].RuneId);
                if (config == null || config.AddPropreList == null)
                {
                    continue;
                }

                effects.AddRange(config.AddPropreList);
            }

            return effects;
        }

        /// <summary>
        /// 符文提供的角色属性，供 Function_Fight 计算属性时使用（还没接进去）
        /// </summary>
        public static List<PropertyValue> GetRoleProLists(this RuneComponent self)
        {
            return PropEffectHelper.CollectRoleProperties(self.GetEffects());
        }

        #endregion
    }
}
