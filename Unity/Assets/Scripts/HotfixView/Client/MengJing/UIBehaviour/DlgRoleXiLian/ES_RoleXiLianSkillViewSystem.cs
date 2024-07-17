using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_RoleXiLianSkillItem))]
    [EntitySystemOf(typeof (ES_RoleXiLianSkill))]
    [FriendOfAttribute(typeof (ES_RoleXiLianSkill))]
    public static partial class ES_RoleXiLianSkillSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleXiLianSkill self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_RoleXiLianSkillItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnRoleXiLianSkillItemsRefresh);
            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleXiLianSkill self)
        {
            self.DestroyWidget();
        }

        private static void OnRoleXiLianSkillItemsRefresh(this ES_RoleXiLianSkill self, Transform transform, int index)
        {
            Scroll_Item_RoleXiLianSkillItem scrollItemRoleXiLianSkillItem = self.ScrollItemRoleXiLianSkillItems[index].BindTrans(transform);
            scrollItemRoleXiLianSkillItem.OnInitUI(self.ShouJiConfigs[index]);
            scrollItemRoleXiLianSkillItem.OnUpdateUI(self.XilianLevel);
        }

        public static int GetXiLianLevel(this ES_RoleXiLianSkill self, Unit unit)
        {
            int xiliandu = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.ItemXiLianDu);
            int xilianLevel = XiLianHelper.GetXiLianId(xiliandu);
            xilianLevel = xilianLevel != 0? EquipXiLianConfigCategory.Instance.Get(xilianLevel).XiLianLevel : 0;
            return xilianLevel;
        }

        public static void OnInitUI(this ES_RoleXiLianSkill self)
        {
            self.ShouJiConfigs = EquipXiLianConfigCategory.Instance.GetAll().Values.ToList();
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            self.XilianLevel = self.GetXiLianLevel(unit);

            self.AddUIScrollItems(ref self.ScrollItemRoleXiLianSkillItems, self.ShouJiConfigs.Count);
            self.E_RoleXiLianSkillItemsLoopVerticalScrollRect.SetVisible(true, self.ShouJiConfigs.Count);

            self.OnUpdateUI();
        }

        public static void OnUpdateUI(this ES_RoleXiLianSkill self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int xilianLevel = self.GetXiLianLevel(unit);

            if (self.ScrollItemRoleXiLianSkillItems != null)
            {
                foreach (Scroll_Item_RoleXiLianSkillItem item in self.ScrollItemRoleXiLianSkillItems.Values)
                {
                    if (item.uiTransform != null)
                    {
                        item.OnUpdateUI(xilianLevel);
                    }
                }
            }
        }
    }
}