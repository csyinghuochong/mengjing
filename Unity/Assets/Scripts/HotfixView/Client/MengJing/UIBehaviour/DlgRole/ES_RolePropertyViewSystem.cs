using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_RolePropertyBaseItem))]
    [FriendOf(typeof(Scroll_Item_RolePropertyTeShuItem))]
    [FriendOf(typeof(UserInfoComponentC))]
    [EntitySystemOf(typeof(ES_RoleProperty))]
    [FriendOfAttribute(typeof(ES_RoleProperty))]
    public static partial class ES_RolePropertySystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleProperty self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_RolePropertyTeShuItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRolePropertyTeShuItemsRefresh);
            self.E_RolePropertyBaseItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRolePropertyBaseItemsRefresh);
            self.E_AddPointButton.AddListener(self.OnAddPointButton);

            self.E_Add_LiLiangEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_AddNum(0).Coroutine(); });
            self.E_Add_LiLiangEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(); });
            self.E_Cost_LiLiangEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_CostNum(0).Coroutine(); });
            self.E_Cost_LiLiangEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(); });

            self.E_Add_ZhiLiEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_AddNum(1).Coroutine(); });
            self.E_Add_ZhiLiEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(); });
            self.E_Cost_ZhiLiEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_CostNum(1).Coroutine(); });
            self.E_Cost_ZhiLiEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(); });

            self.E_Add_TiZhiEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_AddNum(2).Coroutine(); });
            self.E_Add_TiZhiEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(); });
            self.E_Cost_TiZhiEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_CostNum(2).Coroutine(); });
            self.E_Cost_TiZhiEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(); });

            self.E_Add_NaiLiEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_AddNum(3).Coroutine(); });
            self.E_Add_NaiLiEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(); });
            self.E_Cost_NaiLiEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_CostNum(3).Coroutine(); });
            self.E_Cost_NaiLiEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(); });

            self.E_Add_MingJieEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_AddNum(4).Coroutine(); });
            self.E_Add_MingJieEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(); });
            self.E_Cost_MingJieEventTrigger.RegisterEvent(EventTriggerType.PointerDown, (pdata) => { self.PointerDown_CostNum(4).Coroutine(); });
            self.E_Cost_MingJieEventTrigger.RegisterEvent(EventTriggerType.PointerUp, (pdata) => { self.PointerUp(); });

            self.E_LuckExplainButton.AddListener(self.OnLuckExplainButton);
            self.E_CloseAddPointButton.AddListener(self.OnCloseAddPointButton);
            self.E_AddPointConfirmButton.AddListenerAsync(self.OnAddPointConfirmButton);
            self.E_RecommendAddPointButton.AddListener(self.OnRecommendAddPointButton);

            self.EG_AttributeNodeRectTransform.gameObject.SetActive(true);
            self.EG_RoleAddPointRectTransform.gameObject.SetActive(false);

            self.InitShowPropertyList();
            self.InitAddProperty();

            self.E_BtnItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_BtnItemTypeSetToggleGroup.OnSelectIndex(0);

            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.RegisterReddot(ReddotType.RolePoint, self.Reddot_RolePoint);
            
            self.ShowGuide().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleProperty self)
        {
            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent?.UnRegisterReddot(ReddotType.RolePoint, self.Reddot_RolePoint);

            self.DestroyWidget();
        }

        public static async ETTask ShowGuide(this ES_RoleProperty self)
        {
            long instanceid = self.InstanceId;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(10);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            self.Root().GetComponent<GuideComponent>().OnTrigger(GuideTriggerType.OpenUI, "UIRoleProperty");
        }
        
        public static void Reddot_RolePoint(this ES_RoleProperty self, int num)
        {
            self.E_AddPointButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        # region 人物属性

        private static void OnItemTypeSet(this ES_RoleProperty self, int index)
        {
            if (index == 0)
            {
                self.ShowPropertyLists = self.ShowPropertyList_Base;
            }
            else if (index == 1)
            {
                self.ShowPropertyLists = self.ShowPropertyList_TeShu;
            }
            else
            {
                self.ShowPropertyLists = self.ShowPropertyList_KangXing;
            }

            self.PropertyType = index;

            self.RefreshRoleProperty();
        }

        private static void OnAddPointButton(this ES_RoleProperty self)
        {
            self.EG_AttributeNodeRectTransform.gameObject.SetActive(false);
            self.EG_RoleAddPointRectTransform.gameObject.SetActive(true);
            self.InitAddProperty();
        }

        private static void OnRolePropertyTeShuItemsRefresh(this ES_RoleProperty self, Transform transform, int index)
        {
            foreach (Scroll_Item_RolePropertyTeShuItem item in self.ScrollItemRolePropertyTeShuItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_RolePropertyTeShuItem scrollItemRolePropertyTeShuItem = self.ScrollItemRolePropertyTeShuItems[index].BindTrans(transform);
            scrollItemRolePropertyTeShuItem.Refresh(self.ShowPropertyLists[index], index);
        }

        private static void OnRolePropertyBaseItemsRefresh(this ES_RoleProperty self, Transform transform, int index)
        {
            foreach (Scroll_Item_RolePropertyBaseItem item in self.ScrollItemRolePropertyBaseItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_RolePropertyBaseItem scrollItemRolePropertyBaseItem = self.ScrollItemRolePropertyBaseItems[index].BindTrans(transform);
            scrollItemRolePropertyBaseItem.Refresh(self.ShowPropertyLists[index]);
        }

        private static ShowPropertyList AddShowProperList(this ES_RoleProperty self, int numericType, string name, string iconID, int type)
        {
            ShowPropertyList showList = new();
            showList.NumericType = numericType;
            showList.Name = name;
            showList.IconID = ItemViewHelp.GetAttributeIcon(numericType);
            showList.Type = type;
            return showList;
        }

        private static void InitShowPropertyList(this ES_RoleProperty self)
        {
            //添加基础属性
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_MaxHp, "生命", "", 1));
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_MaxAct, "攻击", "", 1));
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_MaxDef, "防御", "", 1));
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_MaxAdf, "魔御", "", 1));
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_Mage, "技能伤害", "", 1));
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_Power, "力量", "", 1));
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_Intellect, "智力", "", 1));
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_Constitution, "体质", "", 1));
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_Stamina, "耐力", "", 1));
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_Agility, "敏捷", "", 1));

            //特殊属性
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_Cri, "暴击概率", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_Res, "韧性概率", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_Hit, "命中概率", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_Dodge, "闪避概率", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_DamgeAddPro, "伤害加成", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_DamgeSubPro, "伤害减免", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_Speed, "移动速度", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_CriLv, "暴击等级", "", 1));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_ResLv, "韧性等级", "", 1));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_HitLv, "命中等级", "", 1));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_DodgeLv, "闪避等级", "", 1));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_ActDamgeAddPro, "物伤加成", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_MageDamgeAddPro, "魔伤加成", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_ActDamgeSubPro, "物伤减免", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_MageDamgeSubPro, "魔伤减免", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_ZhongJiPro, "重击概率", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_ZhongJi, "重击附加伤害", "", 1));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_HuShiActPro, "攻击穿透", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_HuShiMagePro, "魔法穿透", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_HuShiDef, "忽视防御", "", 1));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_HuShiAdf, "忽视魔御", "", 1));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_SkillCDTimeCostPro, "技能冷却", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_MageDodgePro, "魔法闪避", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_ActDodgePro, "物理闪避", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_GeDang, "格挡值", "", 1));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_ZhenShi, "真实伤害", "", 1));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_ActSpeedPro, "攻速加成", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_ShenNongPro, "额外恢复", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_HuiXue, "战斗恢复", "", 1));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_SkillDodgePro, "技能闪避", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_PuGongAddPro, "普攻加成", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_ActBossPro, "物攻领主加成", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_MageBossPro, "魔攻领主加成", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_ActBossSubPro, "领主物攻减免", "", 2));
            self.ShowPropertyList_TeShu.Add(self.AddShowProperList(NumericType.Now_MageBossSubPro, "领主魔攻减免", "", 2));

            // 抗性属性
            self.ShowPropertyList_KangXing.Add(self.AddShowProperList(NumericType.Now_Resistance_Shadow_Pro, "暗影抗性", "", 2));
            self.ShowPropertyList_KangXing.Add(self.AddShowProperList(NumericType.Now_ResistIcece_Ice_Pro, "冰霜抗性", "", 2));
            self.ShowPropertyList_KangXing.Add(self.AddShowProperList(NumericType.Now_ResistFirece_Fire_Pro, "火焰抗性", "", 2));
            self.ShowPropertyList_KangXing.Add(self.AddShowProperList(NumericType.Now_ResistThunderce_Thunder_Pro, "闪电抗性", "", 2));
        }

        public static void RefreshRoleProperty(this ES_RoleProperty self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();
            UserInfoComponentC userInfoComponentC = self.Root().GetComponent<UserInfoComponentC>();

            int maxPiLao = numericComponentC.GetAsInt(NumericType.YueKaRemainTimes) > 0 ? GlobalValueConfigCategory.Instance.MaxPiLaoYuKaUser : GlobalValueConfigCategory.Instance.MaxPiLao;
            self.E_PiLaoImgImage.fillAmount = (float)userInfoComponentC.UserInfo.PiLao / maxPiLao;
            using (zstring.Block())
            {
                self.E_PiLaoTextText.text = zstring.Format("{0}/{1}", userInfoComponentC.UserInfo.PiLao, maxPiLao);
            }
            
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            int skillNumber = 1 + numericComponent.GetAsInt(NumericType.MakeType_2) > 0 ? 1 : 0;
            
            self.E_BaoShiDuImgImage.fillAmount = (float)userInfoComponentC.UserInfo.Vitality / unit.GetMaxHuoLi(skillNumber);
            using (zstring.Block())
            {
                self.E_BaoShiDuTextText.text = zstring.Format("{0}/{1}", userInfoComponentC.UserInfo.Vitality, unit.GetMaxHuoLi(skillNumber));
            }

            if (self.PropertyType == 0)
            {
                self.E_RolePropertyBaseItemsLoopVerticalScrollRect.gameObject.SetActive(true);
                self.E_RolePropertyTeShuItemsLoopVerticalScrollRect.gameObject.SetActive(false);

                self.AddUIScrollItems(ref self.ScrollItemRolePropertyBaseItems, self.ShowPropertyLists.Count);
                self.E_RolePropertyBaseItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPropertyLists.Count, true);
            }
            else
            {
                self.E_RolePropertyBaseItemsLoopVerticalScrollRect.gameObject.SetActive(false);
                self.E_RolePropertyTeShuItemsLoopVerticalScrollRect.gameObject.SetActive(true);

                self.AddUIScrollItems(ref self.ScrollItemRolePropertyTeShuItems, self.ShowPropertyLists.Count);
                self.E_RolePropertyTeShuItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPropertyLists.Count, true);
            }
        }

        #endregion

        #region 角色加点

        private static async ETTask PointerDown_AddNum(this ES_RoleProperty self, int addType)
        {
            self.IsHoldDown = true;
            self.ChangeValue(addType, 1);
            int interval = 0;
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (self.IsHoldDown)
            {
                interval++;
                if (interval > 60)
                {
                    self.ChangeValue(addType, 1);
                }

                await timerComponent.WaitFrameAsync();
            }
        }

        private static async ETTask PointerDown_CostNum(this ES_RoleProperty self, int addType)
        {
            self.IsHoldDown = true;
            self.ChangeValue(addType, -1);
            int interval = 0;
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (self.IsHoldDown)
            {
                interval++;
                if (interval > 60)
                {
                    self.ChangeValue(addType, -1);
                }

                await timerComponent.WaitFrameAsync();
            }
        }

        private static void PointerUp(this ES_RoleProperty self)
        {
            self.IsHoldDown = false;
        }

        private static void ChangeValue(this ES_RoleProperty self, int addType, int value)
        {
            if (self.PointRemain <= 0 && value > 0)
            {
                return;
            }

            if (self.PointList[addType] <= self.PointInit[addType] && value < 0)
            {
                return;
            }

            self.PointRemain += (value * -1);
            self.PointList[addType] += value;
            self.RefreshAddProperty();
        }

        private static void InitAddProperty(this ES_RoleProperty self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponentC = unit.GetComponent<NumericComponentC>();

            self.PointList.Clear();
            self.PointList.Add(numericComponentC.GetAsInt(NumericType.PointLiLiang));
            self.PointList.Add(numericComponentC.GetAsInt(NumericType.PointZhiLi));
            self.PointList.Add(numericComponentC.GetAsInt(NumericType.PointTiZhi));
            self.PointList.Add(numericComponentC.GetAsInt(NumericType.PointNaiLi));
            self.PointList.Add(numericComponentC.GetAsInt(NumericType.PointMinJie));

            self.PointInit.Clear();
            self.PointInit.AddRange(self.PointList);

            self.PointRemain = numericComponentC.GetAsInt(NumericType.PointRemain);

            self.RefreshAddProperty();
        }

        private static void RefreshAddProperty(this ES_RoleProperty self)
        {
            UserInfoComponentC userInfoComponentC = self.Root().GetComponent<UserInfoComponentC>();
            int lv = userInfoComponentC.UserInfo.Lv;

            self.E_Value_LiLiangText.text = (self.PointList[0] + lv * 2).ToString();
            self.E_Value_ZhiLiText.text = (self.PointList[1] + lv * 2).ToString();
            self.E_Value_TiZhiText.text = (self.PointList[2] + lv * 2).ToString();
            self.E_Value_NaiLiText.text = (self.PointList[3] + lv * 2).ToString();
            self.E_Value_MingJieText.text = (self.PointList[4] + lv * 2).ToString();

            self.E_ShengYuNumText.text = self.PointRemain.ToString();
        }

        private static void OnLuckExplainButton(this ES_RoleProperty self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ProLucklyExplain).Coroutine();
        }
        
        private static void OnCloseAddPointButton(this ES_RoleProperty self)
        {
            self.EG_AttributeNodeRectTransform.gameObject.SetActive(true);
            self.EG_RoleAddPointRectTransform.gameObject.SetActive(false);
        }

        private static async ETTask OnAddPointConfirmButton(this ES_RoleProperty self)
        {
            long instanceId = self.InstanceId;
            await BagClientNetHelper.RoleAddPoint(self.Root(), self.PointList);
            if (instanceId != self.InstanceId)
            {
                return;
            }

            self.InitAddProperty();
        }

        private static void OnRecommendAddPointButton(this ES_RoleProperty self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            int occ = userInfoComponent.UserInfo.Occ;
            int occTwo = userInfoComponent.UserInfo.OccTwo;

            // 按比例推荐加点 可以在OccupationConfig和OccupationTwoConfig加个这样的字段
            string recommendAddPoint = string.Empty;
            if (ConfigData.RecommendAddPoint.ContainsKey(occTwo))
            {
                recommendAddPoint = ConfigData.RecommendAddPoint[occTwo];
            }
            else if (ConfigData.RecommendAddPoint.ContainsKey(occ))
            {
                recommendAddPoint = ConfigData.RecommendAddPoint[occ];
            }
            else
            {
                return;
            }

            string[] str = recommendAddPoint.Split('@');
            int all = 0;
            List<int> points = new List<int>();
            foreach (string s in str)
            {
                all += int.Parse(s);
                points.Add(int.Parse(s));
            }

            int red = 0;
            for (int i = 0; i < 5; i++)
            {
                int add = self.PointRemain / all * points[i];
                red += add;
                self.PointList[i] += add;
            }

            self.PointRemain -= red;
            self.RefreshAddProperty();
        }

        #endregion
    }
}