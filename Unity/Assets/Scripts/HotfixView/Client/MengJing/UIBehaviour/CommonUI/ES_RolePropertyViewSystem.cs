﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    
    [FriendOf(typeof (UserInfoComponentClient))]
    [EntitySystemOf(typeof (ES_RoleProperty))]
    [FriendOfAttribute(typeof (ES_RoleProperty))]
    public static partial class ES_RolePropertySystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleProperty self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_RolePropertyBaseItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRolePropertyBaseItemsRefresh);
            self.E_RolePropertyTeShuItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRolePropertyTeShuItemsRefresh);
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

            self.E_CloseAddPointButton.AddListener(self.OnCloseAddPointButton);
            self.E_AddPointConfirmButton.AddListener(self.OnAddPointConfirmButton);
            self.E_RecommendAddPointButton.AddListener(self.OnRecommendAddPointButton);

            self.EG_AttributeNodeRectTransform.gameObject.SetActive(true);
            self.EG_RoleAddPointRectTransform.gameObject.SetActive(false);
            self.InitShowPropertyList();
            self.RefreshRoleProperty();
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleProperty self)
        {
            self.DestroyWidget();
        }

        # region 人物属性

        private static void OnAddPointButton(this ES_RoleProperty self)
        {
            self.EG_AttributeNodeRectTransform.gameObject.SetActive(false);
            self.EG_RoleAddPointRectTransform.gameObject.SetActive(true);
            self.InitAddProperty();
        }

        private static void OnRolePropertyBaseItemsRefresh(this ES_RoleProperty self, Transform transform, int index)
        {
            Scroll_Item_RolePropertyBaseItem scrollItemRolePropertyBaseItem = self.ScrollItemRolePropertyBaseItems[index].BindTrans(transform);
            scrollItemRolePropertyBaseItem.Refresh(self.ShowPropertyList_Base[index]);
        }

        private static void OnRolePropertyTeShuItemsRefresh(this ES_RoleProperty self, Transform transform, int index)
        {
            Scroll_Item_RolePropertyTeShuItem scrollItemRolePropertyTeShuItem = self.ScrollItemRolePropertyTeShuItems[index].BindTrans(transform);
            scrollItemRolePropertyTeShuItem.Refresh(self.ShowPropertyList_TeShu[index]);
        }

        private static ShowPropertyList AddShowProperList(this ES_RoleProperty self, int numericType, string name, string iconID, int type)
        {
            ShowPropertyList showList = new();
            showList.NumericType = numericType;
            showList.Name = name;
            showList.IconID = iconID;
            showList.Type = type;
            return showList;
        }

        private static void InitShowPropertyList(this ES_RoleProperty self)
        {
            //添加基础属性
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_MaxHp, "生命", "Pro_4", 1));
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_MaxAct, "攻击", "Pro_5", 1));
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_MaxDef, "防御", "Pro_3", 1));
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_MaxAdf, "魔御", "Pro_9", 1));
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_Mage, "技能伤害", "Pro_2", 1));
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_Power, "力量", "Pro_8", 1));
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_Intellect, "智力", "Pro_2", 1));
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_Constitution, "体质", "Pro_6", 1));
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_Stamina, "耐力", "Pro_7", 1));
            self.ShowPropertyList_Base.Add(self.AddShowProperList(NumericType.Now_Agility, "敏捷", "Pro_9", 1));

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
        }

        private static void RefreshRoleProperty(this ES_RoleProperty self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentClient numericComponentClient = unit.GetComponent<NumericComponentClient>();
            UserInfoComponentClient userInfoComponentClient = self.Root().GetComponent<UserInfoComponentClient>();

            int maxPiLao = int.Parse(GlobalValueConfigCategory.Instance
                    .Get(numericComponentClient.GetAsInt(NumericType.YueKaRemainTimes) > 0? 26 : 10).Value);
            self.E_PiLaoImgImage.fillAmount = (float)userInfoComponentClient.UserInfo.PiLao / maxPiLao;
            self.E_PiLaoTextText.text = userInfoComponentClient.UserInfo.PiLao + "/" + maxPiLao;
            self.E_BaoShiDuImgImage.fillAmount = (float)userInfoComponentClient.UserInfo.BaoShiDu / ComHelp.GetMaxBaoShiDu();
            self.E_BaoShiDuTextText.text = userInfoComponentClient.UserInfo.BaoShiDu + "/" + ComHelp.GetMaxBaoShiDu();

            self.AddUIScrollItems(ref self.ScrollItemRolePropertyBaseItems, self.ShowPropertyList_Base.Count);
            self.E_RolePropertyBaseItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPropertyList_Base.Count);

            self.AddUIScrollItems(ref self.ScrollItemRolePropertyTeShuItems, self.ShowPropertyList_TeShu.Count);
            self.E_RolePropertyTeShuItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPropertyList_TeShu.Count);
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
            NumericComponentClient numericComponentClient = unit.GetComponent<NumericComponentClient>();

            self.PointList.Clear();
            self.PointList.Add(numericComponentClient.GetAsInt(NumericType.PointLiLiang));
            self.PointList.Add(numericComponentClient.GetAsInt(NumericType.PointZhiLi));
            self.PointList.Add(numericComponentClient.GetAsInt(NumericType.PointTiZhi));
            self.PointList.Add(numericComponentClient.GetAsInt(NumericType.PointNaiLi));
            self.PointList.Add(numericComponentClient.GetAsInt(NumericType.PointMinJie));

            self.PointInit.Clear();
            self.PointInit.AddRange(self.PointList);

            self.PointRemain = numericComponentClient.GetAsInt(NumericType.PointRemain);

            self.RefreshAddProperty();
        }

        private static void RefreshAddProperty(this ES_RoleProperty self)
        {
            UserInfoComponentClient userInfoComponentClient = self.Root().GetComponent<UserInfoComponentClient>();
            int lv = userInfoComponentClient.UserInfo.Lv;

            self.E_Value_LiLiangText.text = (self.PointList[0] + lv * 2).ToString();
            self.E_Value_ZhiLiText.text = (self.PointList[1] + lv * 2).ToString();
            self.E_Value_TiZhiText.text = (self.PointList[2] + lv * 2).ToString();
            self.E_Value_NaiLiText.text = (self.PointList[3] + lv * 2).ToString();
            self.E_Value_MingJieText.text = (self.PointList[4] + lv * 2).ToString();

            self.E_ShengYuNumText.text = self.PointRemain.ToString();
        }

        private static void OnCloseAddPointButton(this ES_RoleProperty self)
        {
            self.EG_AttributeNodeRectTransform.gameObject.SetActive(true);
            self.EG_RoleAddPointRectTransform.gameObject.SetActive(false);
        }

        private static void OnAddPointConfirmButton(this ES_RoleProperty self)
        {
            self.Root().GetComponent<FlyTipComponent>().SpawnFlyTipDi("确认加点");
            // long instanceId = self.InstanceId;
            // C2M_RoleAddPointRequest request = new C2M_RoleAddPointRequest() { PointList = self.PointList, };
            // M2C_RoleAddPointResponse response =
            //         (M2C_RoleAddPointResponse)await self.ZoneScene().GetComponent<SessionComponent>().Session.Call(request);
            // if (instanceId != self.InstanceId)
            // {
            //     return;
            // }

            self.InitAddProperty();
        }

        private static void OnRecommendAddPointButton(this ES_RoleProperty self)
        {
            self.Root().GetComponent<FlyTipComponent>().SpawnFlyTipDi("推荐加点");
        }

        #endregion
    }
}