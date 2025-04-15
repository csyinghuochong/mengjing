using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (DlgRoleXiLianTenViewComponent))]
    [FriendOf(typeof (DlgRoleXiLianTen))]
    public static class DlgRoleXiLianTenSystem
    {
        public static void RegisterUIEvent(this DlgRoleXiLianTen self)
        {
            ReferenceCollector rc = self.View.uiTransform.GetComponent<ReferenceCollector>();
            self.UIRoleXiLianTenItem = rc.Get<GameObject>("UIRoleXiLianTenItem");

            self.View.E_ImageButtonCloseButton.AddListener(self.OnImageButtonCloseButton);
        }

        public static void ShowWindow(this DlgRoleXiLianTen self, Entity contextData = null)
        {
            self.UIRoleXiLianTenItem.SetActive(false);
        }

        public static void OnInitUI(this DlgRoleXiLianTen self, ItemInfo bagInfo, List<ItemXiLianResult> itemXiLians)
        {
            for (int i = 0; i < itemXiLians.Count; i++)
            {
                ItemInfo bagInfoTemp = CommonHelp.DeepCopy(bagInfo);
                bagInfoTemp.XiLianHideTeShuProLists = itemXiLians[i].XiLianHideTeShuProLists;
                bagInfoTemp.XiLianHideProLists = itemXiLians[i].XiLianHideProLists;
                bagInfoTemp.HideSkillLists = itemXiLians[i].HideSkillLists;

                GameObject itemGo = UnityEngine.Object.Instantiate(self.UIRoleXiLianTenItem);
                CommonViewHelper.SetParent(itemGo, self.View.EG_ItemListNodeRectTransform.gameObject);
                itemGo.SetActive(true);
                self.AddChild<UIRoleXiLianTenItem, GameObject>(itemGo).OnInitUI(bagInfo, bagInfoTemp, itemXiLians[i]);
            }
        }

        private static void OnImageButtonCloseButton(this DlgRoleXiLianTen self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RoleXiLianTen);
        }
    }
}
