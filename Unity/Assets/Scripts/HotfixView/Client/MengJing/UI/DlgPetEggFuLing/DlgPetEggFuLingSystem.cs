using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(DlgPetEggFuLing))]
    public static class DlgPetEggFuLingSystem
    {
        public static void RegisterUIEvent(this DlgPetEggFuLing self)
        {
            self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
            self.View.E_FuLingBtnButton.AddListenerAsync(self.OnFuLingBtnButton);
        }

        public static void ShowWindow(this DlgPetEggFuLing self, Entity contextData = null)
        {
        }

        public static void OnBtn_CloseButton(this DlgPetEggFuLing self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetEggFuLing);
        }

        public static async ETTask OnFuLingBtnButton(this DlgPetEggFuLing self)
        {
            if (self.EggId == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("请选择宠物蛋！");
                return;
            }

            M2C_ItemOperateResponse response = await BagClientNetHelper.RequestUseItem(self.Root(), self.BagInfo, self.EggId.ToString());

            if (response == null ||  response.Error!= ErrorCode.ERR_Success)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetEggFuLing);
        }

        private static void OnBagItemsRefresh(this DlgPetEggFuLing self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.None, self.OnSelect);
        }

        public static void UpdateItemList(this DlgPetEggFuLing self, ItemInfo bagInfo)
        {
            self.BagInfo = bagInfo;

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            List<ItemInfo> bagInfos = bagComponent.GetItemsByLoc(ItemLocType.ItemLocBag);
            self.ShowBagInfos.Clear();
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (bagInfos[i].FuLing == 0 && itemConfig.ItemType == ItemTypeEnum.Consume && itemConfig.ItemSubType == 102)
                {
                    self.ShowBagInfos.Add(bagInfos[i]);
                }

                self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
                self.View.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
            }
        }

        public static void OnSelect(this DlgPetEggFuLing self, ItemInfo bagInfo)
        {
            self.EggId = bagInfo.BagInfoID;
            if (self.ScrollItemCommonItems != null)
            {
                foreach (var value in self.ScrollItemCommonItems.Values)
                {
                    Scroll_Item_CommonItem item = value;
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.SetSelected(bagInfo);
                }
            }
        }
    }
}
