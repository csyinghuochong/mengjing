using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_CommonItem))]
    [FriendOf(typeof (DlgSeasonJingHeZhuru))]
    public static class DlgSeasonJingHeZhuruSystem
    {
        public static void RegisterUIEvent(this DlgSeasonJingHeZhuru self)
        {
            self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.View.E_ZhuRuBtnButton.AddListenerAsync(self.OnZhuRuBtn);
            self.View.E_CloseBtnButton.AddListener(
                () => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SeasonJingHeZhuru); });
        }

        public static void ShowWindow(this DlgSeasonJingHeZhuru self, Entity contextData = null)
        {
        }

        public static async ETTask OnZhuRuBtn(this DlgSeasonJingHeZhuru self)
        {
            if (self.CostIds.Count <= 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("未选择道具！");
                return;
            }

            await BagClientNetHelper.JingHeZhuru(self.Root(), self.MainBagInfo.BagInfoID, self.CostIds);

            self.MainBagInfo = self.Root().GetComponent<BagComponentC>().GetBagInfo(self.MainBagInfo.BagInfoID);
            self.View.E_AddQualityTextText.text = "";
            self.MinAdd = 0;
            self.MaxAdd = 0;
            self.CostIds.Clear();
            self.UpdateItemList();
            self.View.E_NowQualityTextText.text = $"当前品质:{self.MainBagInfo.ItemPar}";
        }

        public static void InitInfo(this DlgSeasonJingHeZhuru self, BagInfo bagInfo)
        {
            self.MainBagInfo = bagInfo;
            self.View.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            self.View.E_ItemNameTextText.text = itemConfig.ItemName;
            self.View.E_NowQualityTextText.text = $"当前品质:{bagInfo.ItemPar}";
            self.View.E_AddQualityTextText.text = "";

            self.UpdateItemList();
        }

        private static void OnBagItemsRefresh(this DlgSeasonJingHeZhuru self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(index < self.ShowBagInfos.Count? self.ShowBagInfos[index] : null, ItemOperateEnum.None, self.OnSelect);
        }

        public static void UpdateItemList(this DlgSeasonJingHeZhuru self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();

            self.ShowBagInfos.Clear();
            List<BagInfo> bagInfos = bagComponent.GetItemsByLoc(ItemLocType.ItemLocBag);
            for (int i = 0; i < bagInfos.Count; i++)
            {
                if (bagInfos[i].BagInfoID == self.MainBagInfo.BagInfoID)
                {
                    continue;
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.ItemType == ItemTypeEnum.Equipment && itemConfig.EquipType == 201)
                {
                    self.ShowBagInfos.Add(bagInfos[i]);
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.View.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }

        public static void OnSelect(this DlgSeasonJingHeZhuru self, BagInfo bagInfo)
        {
            bool selected = false;

            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == null)
                {
                    continue;
                }

                if (item.ES_CommonItem.Baginfo != null && item.ES_CommonItem.Baginfo.BagInfoID == bagInfo.BagInfoID)
                {
                    selected = !item.ES_CommonItem.E_XuanZhongImage.gameObject.activeSelf;
                    item.ES_CommonItem.E_XuanZhongImage.gameObject.SetActive(selected);

                    List<int> valuerange = ItemHelper.GetJingHeAddQulity(new List<int>() { int.Parse(bagInfo.ItemPar) });
                    if (selected)
                    {
                        if (!self.CostIds.Contains(bagInfo.BagInfoID))
                        {
                            self.CostIds.Add(bagInfo.BagInfoID);
                        }

                        self.MinAdd += valuerange[0];
                        self.MaxAdd += valuerange[1];
                    }
                    else
                    {
                        self.CostIds.Remove(bagInfo.BagInfoID);
                        self.MinAdd -= valuerange[0];
                        self.MaxAdd -= valuerange[1];
                    }

                    break;
                }
            }

            self.View.E_AddQualityTextText.text = $"{self.MinAdd}~{self.MaxAdd}";
        }
    }
}