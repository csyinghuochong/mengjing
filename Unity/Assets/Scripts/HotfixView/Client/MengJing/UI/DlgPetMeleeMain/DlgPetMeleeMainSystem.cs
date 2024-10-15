using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgPetMeleeMain))]
    public static class DlgPetMeleeMainSystem
    {
        public static void RegisterUIEvent(this DlgPetMeleeMain self)
        {
            self.View.E_PetMeleeItemsLoopHorizontalScrollRect.AddItemRefreshListener(self.OnPetMeleeItemsRefresh);
            self.View.E_CancelButton.AddListener(self.OnCancel);
        }

        public static void ShowWindow(this DlgPetMeleeMain self, Entity contextData = null)
        {
            self.View.E_CancelButton.gameObject.SetActive(false);
            self.RefreshItems();
        }

        public static void RefreshItems(this DlgPetMeleeMain self)
        {
            List<RolePetInfo> rolePetInfos = self.Root().GetComponent<PetComponentC>().RolePetInfos;
            self.ShowRolePetInfos.Clear();
            for (int i = 0; i < rolePetInfos.Count; i++)
            {
                if (rolePetInfos[i].PetStatus == 0)
                {
                    self.ShowRolePetInfos.Add(rolePetInfos[i]);
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemPetMeleeItems, self.ShowRolePetInfos.Count);
            self.View.E_PetMeleeItemsLoopHorizontalScrollRect.SetVisible(true, self.ShowRolePetInfos.Count);
        }

        private static void OnPetMeleeItemsRefresh(this DlgPetMeleeMain self, Transform transform, int index)
        {
            Scroll_Item_PetMeleeItem scrollItemPetMeleeItem = self.ScrollItemPetMeleeItems[index].BindTrans(transform);
            scrollItemPetMeleeItem.Refresh(self.ShowRolePetInfos[index]);
        }

        public static void OnClickItem(this DlgPetMeleeMain self, RolePetInfo rolePetInfo)
        {
            FlyTipComponent.Instance.ShowFlyTip($"选中宠物{rolePetInfo.Id}");
            self.View.E_CancelButton.gameObject.SetActive(true);
        }

        private static void OnCancel(this DlgPetMeleeMain self)
        {
            self.View.E_CancelButton.gameObject.SetActive(false);
        }
    }
}