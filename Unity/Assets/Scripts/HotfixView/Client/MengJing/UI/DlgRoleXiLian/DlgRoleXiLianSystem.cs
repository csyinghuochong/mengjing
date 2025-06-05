using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (ES_RoleXiLianShow))]
    [FriendOf(typeof (ES_RoleXiLianLevel))]
    [FriendOf(typeof (ES_RoleXiLianSkill))]
    [FriendOf(typeof (ES_RoleXiLianTransfer))]
    [FriendOf(typeof (ES_RoleXiLianInherit))]
    [FriendOf(typeof (DlgRoleXiLian))]
    public static class DlgRoleXiLianSystem
    {
        public static void RegisterUIEvent(this DlgRoleXiLian self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
            
            IPHoneHelper.SetPosition(self.View.E_FunctionSetBtnToggleGroup.gameObject, new Vector2(220f, 0f));
        }

        public static void ShowWindow(this DlgRoleXiLian self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgRoleXiLian self, int index)
        {
            CommonViewHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_RoleXiLianShow.uiTransform.gameObject.SetActive(true);
                    self.View.ES_RoleXiLianShow.OnUpdateUI();
                    break;
                case 1:
                    self.View.ES_RoleXiLianLevel.uiTransform.gameObject.SetActive(true);
                    self.View.ES_RoleXiLianLevel.OnUpdateUI();
                    break;
                case 2:
                    self.View.ES_RoleXiLianSkill.uiTransform.gameObject.SetActive(true);
                    self.View.ES_RoleXiLianSkill.OnUpdateUI();
                    break;
                case 3:
                    self.View.ES_RoleXiLianTransfer.uiTransform.gameObject.SetActive(true);
                    self.View.ES_RoleXiLianTransfer.OnUpdateUI();
                    break;
                case 4:
                    self.View.ES_RoleXiLianInherit.uiTransform.gameObject.SetActive(true);
                    self.View.ES_RoleXiLianInherit.OnUpdateUI();
                    break;
            }
        }

        public static void OnXiLianReturn(this DlgRoleXiLian self, ItemInfo oldItemInfo, long changeCombat)
        {
            self.View.ES_RoleXiLianShow.UpdateEquipCombatChange(oldItemInfo, 0);
            self.View.ES_RoleXiLianShow.OnXiLianReturn();
        }
    }
}
