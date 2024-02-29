using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (UserInfoComponentClient))]
    [FriendOf(typeof (DlgRoleProperty))]
    public static class DlgRolePropertySystem
    {
        public static void RegisterUIEvent(this DlgRoleProperty self)
        {
            self.View.E_RolePropertyBaseItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRolePropertyBaseItemsRefresh);
            self.View.E_RolePropertyTeShuItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRolePropertyTeShuItemsRefresh);
        }

        public static void ShowWindow(this DlgRoleProperty self, Entity contextData = null)
        {
            self.InitShowPropertyList();
            self.RefreshRoleProperty();
        }

        private static void OnRolePropertyBaseItemsRefresh(this DlgRoleProperty self, Transform transform, int index)
        {
            Scroll_Item_RolePropertyBaseItem scrollItemRolePropertyBaseItem = self.ScrollItemRolePropertyBaseItems[index].BindTrans(transform);
            scrollItemRolePropertyBaseItem.Refresh(self.ShowPropertyList_Base[index]);
        }

        private static void OnRolePropertyTeShuItemsRefresh(this DlgRoleProperty self, Transform transform, int index)
        {
            Scroll_Item_RolePropertyTeShuItem scrollItemRolePropertyTeShuItem = self.ScrollItemRolePropertyTeShuItems[index].BindTrans(transform);
            scrollItemRolePropertyTeShuItem.Refresh(self.ShowPropertyList_TeShu[index]);
        }

        private static ShowPropertyList AddShowProperList(this DlgRoleProperty self, int numericType, string name, string iconID, int type)
        {
            ShowPropertyList showList = new();
            showList.NumericType = numericType;
            showList.Name = name;
            showList.IconID = iconID;
            showList.Type = type;
            return showList;
        }

        private static void InitShowPropertyList(this DlgRoleProperty self)
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

        private static void RefreshRoleProperty(this DlgRoleProperty self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentClient numericComponentClient = unit.GetComponent<NumericComponentClient>();
            UserInfoComponentClient userInfoComponentClient = self.Root().GetComponent<UserInfoComponentClient>();

            int maxPiLao = int.Parse(GlobalValueConfigCategory.Instance
                    .Get(numericComponentClient.GetAsInt(NumericType.YueKaRemainTimes) > 0? 26 : 10).Value);
            self.View.E_PiLaoImgImage.fillAmount = (float)userInfoComponentClient.UserInfo.PiLao / maxPiLao;
            self.View.E_PiLaoTextText.text = userInfoComponentClient.UserInfo.PiLao + "/" + maxPiLao;
            self.View.E_BaoShiDuImgImage.fillAmount = (float)userInfoComponentClient.UserInfo.BaoShiDu / ComHelp.GetMaxBaoShiDu();
            self.View.E_BaoShiDuTextText.text = userInfoComponentClient.UserInfo.BaoShiDu + "/" + ComHelp.GetMaxBaoShiDu();

            self.AddUIScrollItems(ref self.ScrollItemRolePropertyBaseItems, self.ShowPropertyList_Base.Count);
            self.View.E_RolePropertyBaseItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPropertyList_Base.Count);

            self.AddUIScrollItems(ref self.ScrollItemRolePropertyTeShuItems, self.ShowPropertyList_TeShu.Count);
            self.View.E_RolePropertyTeShuItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPropertyList_TeShu.Count);
        }
    }
}