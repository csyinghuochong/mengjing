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
        /// 已激活宝石天赋提供的效果（宝石天赋没有等级，AddPropreList 本身就是一维的效果列表）
        /// </summary>
        public static List<PropEffect> GetEffects(this GemTalentComponent self)
        {
            List<PropEffect> effects = new List<PropEffect>();
            for (int i = 0; i < self.GemTalentList.Count; i++)
            {
                GemTalentConfig gemTalentConfig = GemTalentConfigCategory.Instance.GetOrDefault(self.GemTalentList[i]);
                if (gemTalentConfig == null)
                {
                    continue;
                }

                effects.AddRange(gemTalentConfig.AddPropreList);
            }

            return effects;
        }

        /// <summary>
        /// 宝石天赋的效果变化，add为true时生效，false时移除。
        /// 技能属性、buff属性等只在释放技能时通过SkillSetComponentS读取，这里只处理需要进技能列表的SkillIdAdd
        /// </summary>
        public static void AddGemTalentAttribute(this GemTalentComponent self, int gemTalentId, bool add)
        {
            GemTalentConfig gemTalentConfig = GemTalentConfigCategory.Instance.GetOrDefault(gemTalentId);
            if (gemTalentConfig == null)
            {
                return;
            }

            List<PropEffect> effects = gemTalentConfig.AddPropreList;
            for (int k = 0; k < effects.Count; k++)
            {
                if (effects[k] is SkillIdAdd effect)
                {
                    self.OnGemTalentSkillIdAdd(effect.SkillId, add);
                }
            }
        }

        /// <summary>
        /// 宝石天赋附加的技能，激活时加进技能列表，重置时移除
        /// </summary>
        private static void OnGemTalentSkillIdAdd(this GemTalentComponent self, int skillId, bool add)
        {
            if (skillId == 0)
            {
                return;
            }

            SkillSetComponentS skillSetComponent = self.GetParent<Unit>().GetComponent<SkillSetComponentS>();
            if (skillSetComponent == null)
            {
                return;
            }

            if (add)
            {
                skillSetComponent.OnAddkillId(skillId, 0, SkillSetEnum.Skill, SkillSourceEnum.GemTalent, false);
                return;
            }

            skillSetComponent.OnRemoveSkillId(skillId, SkillSourceEnum.GemTalent, false);
        }

        /// <summary>
        /// 宝石天赋变化后刷新属性、被动技能和技能列表：附加技能变化时客户端要重新收到技能列表
        /// </summary>
        private static void RefreshGemTalentEffect(this GemTalentComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            Function_Fight.UnitUpdateProperty_Base(unit, true, true);
            unit.GetComponent<SkillPassiveComponent>()?.UpdatePassiveSkill();
            unit.GetComponent<SkillSetComponentS>()?.UpdateSkillSet();
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

            //AddPropreList 里可能配了附加技能，激活时一并生效
            self.AddGemTalentAttribute(gemTalentId, true);
            self.RefreshGemTalentEffect();
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

            //先移除附加技能，再清空激活列表，避免重置后技能残留在技能列表里
            for (int i = 0; i < self.GemTalentList.Count; i++)
            {
                self.AddGemTalentAttribute(self.GemTalentList[i], false);
            }

            self.GemTalentList.Clear();

            self.RefreshGemTalentEffect();
            return ErrorCode.ERR_Success;
        }

        /// <summary>
        /// 宝石天赋提供的角色属性，供 Function_Fight 计算属性时使用
        /// </summary>
        public static List<PropertyValue> GetRoleProLists(this GemTalentComponent self)
        {
            return PropEffectHelper.CollectRoleProperties(self.GetEffects());
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
