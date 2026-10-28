using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(GemTalentComponent))]
    [FriendOf(typeof(GemTalentComponent))]
    public static partial class GemTalentComponentSystem
    {
        [EntitySystem]
        private static void Awake(this GemTalentComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this GemTalentComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this GemTalentComponent self)
        {
        }

        /// <summary>
        /// 当前宝石点数：主副两套装备上已镶嵌宝石的等级之和
        /// </summary>
        public static int GetTotalPoint(this GemTalentComponent self)
        {
            BagComponentS bagComponent = self.GetParent<Unit>().GetComponent<BagComponentS>();
            if (bagComponent == null)
            {
                return 0;
            }

            int totalPoint = GemTalentHelper.GetTotalPoint(bagComponent.GetItemByLoc(ItemLocType.ItemLocEquip));
            // totalPoint += GemTalentHelper.GetTotalPoint(bagComponent.GetItemByLoc(ItemLocType.ItemLocEquip_2));
            return totalPoint;
        }

        /// <summary>
        /// 记录历史最大的宝石点数：区域解锁按这个值判断，卸下宝石后已经解锁的区域不会再锁回去
        /// </summary>
        public static void UpdateMaxPoint(this GemTalentComponent self)
        {
            int totalPoint = self.GetTotalPoint();
            if (totalPoint > self.GemTalentMaxPoint)
            {
                self.GemTalentMaxPoint = totalPoint;
            }
        }

        /// <summary>
        /// 主动把最新的宝石天赋数据下发给客户端
        /// </summary>
        public static void SyncToClient(this GemTalentComponent self)
        {
            M2C_GemTalentMessage message = M2C_GemTalentMessage.Create();
            message.Info = self.GetInfo();
            MapMessageHelper.SendToClient(self.GetParent<Unit>(), message);
        }

        /// <summary>
        /// 穿脱装备、镶嵌或卸下宝石之后调用：刷新历史最大宝石点数，点数变大时主动下发给客户端。
        /// 只在会改变宝石点数的操作里调用，不要放到属性重算这类高频流程里
        /// </summary>
        public static void UpdateMaxPointAndSync(this GemTalentComponent self)
        {
            int oldMaxPoint = self.GemTalentMaxPoint;
            self.UpdateMaxPoint();
            if (oldMaxPoint == self.GemTalentMaxPoint)
            {
                return;
            }

            self.SyncToClient();
        }

        /// <summary>
        /// 已消耗的宝石点数：已激活节点的消耗之和
        /// </summary>
        public static int GetUsedPoint(this GemTalentComponent self)
        {
            return GemTalentHelper.GetUsedPoint(self.GemTalentList);
        }

        /// <summary>
        /// 可用宝石点数 = 总宝石点数 - 已消耗
        /// </summary>
        public static int GetLeftPoint(this GemTalentComponent self)
        {
            return GemTalentHelper.GetLeftPoint(self.GemTalentList, self.GemTalentMaxPoint);
        }

        /// <summary>
        /// 该宝石天赋节点是否已激活
        /// </summary>
        public static bool HaveGemTalent(this GemTalentComponent self, int gemTalentId)
        {
            return self.GemTalentList.Contains(gemTalentId);
        }

        /// <summary>
        /// 激活宝石天赋节点：校验区域解锁与可用点数，激活后永久生效
        /// </summary>
        public static int OnActiveGemTalent(this GemTalentComponent self, int gemTalentId)
        {
            GemTalentConfig gemTalentConfig = GemTalentConfigCategory.Instance.GetOrDefault(gemTalentId);
            if (gemTalentConfig == null)
            {
                return ErrorCode.ERR_GemTalentNotExist;
            }

            if (self.GemTalentList.Contains(gemTalentId))
            {
                return ErrorCode.ERR_GemTalentActivated;
            }
            
            if (!GemTalentHelper.IsAreaUnlocked(gemTalentConfig.Area, self.GemTalentMaxPoint))
            {
                return ErrorCode.ERR_GemTalentAreaLock;
            }

            if (self.GetLeftPoint() < gemTalentConfig.CostPoint)
            {
                return ErrorCode.ERR_GemTalentPointNotEnough;
            }

            self.GemTalentList.Add(gemTalentId);

            Function_Fight.UnitUpdateProperty_Base(self.GetParent<Unit>(), true, true);
            return ErrorCode.ERR_Success;
        }

        /// <summary>
        /// 重置宝石天赋：消耗钻石清空所有已激活节点。
        /// 宝石点数由装备上的宝石换算，清空节点即等同于全部返还，不需要额外退还
        /// </summary>
        public static int OnResetGemTalent(this GemTalentComponent self)
        {
            if (self.GemTalentList.Count == 0)
            {
                return ErrorCode.ERR_GemTalentNoneActivated;
            }

            Unit unit = self.GetParent<Unit>();
            BagComponentS bagComponent = unit.GetComponent<BagComponentS>();
            if (bagComponent == null)
            {
                return ErrorCode.ERR_ModifyData;
            }

            List<RewardItem> costItems = new List<RewardItem>();
            costItems.Add(new RewardItem() { ItemID = UserDataType.Diamond, ItemNum = GlobalValueConfigCategory.Instance.GemTalentResetCostDiamond });
            if (!bagComponent.OnCostItemData(costItems))
            {
                return ErrorCode.ERR_DiamondNotEnoughError;
            }

            self.GemTalentList.Clear();

            Function_Fight.UnitUpdateProperty_Base(unit, true, true);
            return ErrorCode.ERR_Success;
        }

        /// <summary>
        /// 宝石天赋提供的角色属性，供 Function_Fight 计算属性时使用
        /// </summary>
        public static List<PropertyValue> GetRoleProLists(this GemTalentComponent self)
        {
            List<PropertyValue> proList = new List<PropertyValue>();
            for (int i = 0; i < self.GemTalentList.Count; i++)
            {
                GemTalentConfig gemTalentConfig = GemTalentConfigCategory.Instance.GetOrDefault(self.GemTalentList[i]);
                if (gemTalentConfig == null || string.IsNullOrEmpty(gemTalentConfig.AddPropreListStr))
                {
                    continue;
                }

                // AddPropreListStr 形如 RolePropertyAdd;100402;0.01，宝石天赋没有等级，只取第一段
                string[] properInfo = gemTalentConfig.AddPropreListStr.Split('#')[0].Split(';');
                if (properInfo.Length < 3)
                {
                    continue;
                }

                if (!properInfo[0].Equals(TianFuProEnum.RolePropertyAdd))
                {
                    continue;
                }

                if (!int.TryParse(properInfo[1], out int numericKey))
                {
                    continue;
                }

                if (NumericHelp.GetNumericValueType(numericKey) == 1)
                {
                    proList.Add(new PropertyValue() { HideID = numericKey, HideValue = long.Parse(properInfo[2]) });
                }
                else
                {
                    proList.Add(new PropertyValue() { HideID = numericKey, HideValue = (int)(float.Parse(properInfo[2]) * 10000) });
                }
            }

            return proList;
        }

        /// <summary>
        /// 下发给客户端的宝石天赋数据
        /// </summary>
        public static GemTalentInfo GetInfo(this GemTalentComponent self)
        {
            GemTalentInfo gemTalentInfo = GemTalentInfo.Create();
            gemTalentInfo.GemTalentList.AddRange(self.GemTalentList);
            gemTalentInfo.GemTalentMaxPoint = self.GemTalentMaxPoint;
            return gemTalentInfo;
        }
    }
}
