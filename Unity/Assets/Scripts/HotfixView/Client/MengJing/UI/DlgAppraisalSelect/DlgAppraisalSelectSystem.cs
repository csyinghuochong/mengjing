using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class BagItemUpdate_RefreshAppraisalSelectItem : AEvent<Scene, BagItemUpdate>
    {
        protected override async ETTask Run(Scene scene, BagItemUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgAppraisalSelect>()?.RefreshCommonItems();
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(ES_CommonItem))]
    [FriendOf(typeof(DlgAppraisalSelect))]
    public static class DlgAppraisalSelectSystem
    {
        public static void RegisterUIEvent(this DlgAppraisalSelect self)
        {
            self.View.E_CommonItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonItemsRefresh);
            self.View.E_CloseButton.AddListener(self.OnCloseButton);
            self.View.E_CoinButton.AddListener(self.OnCoinButton);
            self.View.E_ItemButton.AddListener(self.OnItemButton);
        }

        public static void ShowWindow(this DlgAppraisalSelect self, Entity contextData = null)
        {
            self.View.EG_JianDingSetRectTransform.gameObject.SetActive(false);
        }

        public static void OnInitUI(this DlgAppraisalSelect self, ItemInfo bagInfo)
        {
            self.BagInfo_Equip = bagInfo;
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            EquipConfig equipConfig = EquipConfigCategory.Instance.Get(itemConfig.ItemEquipID);
            self.AppraisalItemConfigId = equipConfig.AppraisalItem;

            self.View.E_CoinNumText.text = ItemHelper.GetJianDingCoin(itemConfig.UseLv).ToString();

            self.View.ES_CommonItem_1.UpdateItem(bagInfo, ItemOperateEnum.None);
            ItemConfig itemConfig_app = ItemConfigCategory.Instance.Get(self.AppraisalItemConfigId);
            self.View.ES_CommonItem_2.uiTransform.gameObject.SetActive(false);
            using (zstring.Block())
            {
                self.View.E_Tip_1Text.text = zstring.Format("需要消耗：{0}", itemConfig_app.ItemName);
                self.View.E_EquipLevelText.text = zstring.Format("{0}级", itemConfig.UseLv);
            }

            self.RefreshCommonItems();
        }

        private static void OnCommonItemsRefresh(this DlgAppraisalSelect self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.None, self.OnSelectItem);
        }

        private static void OnSelectItem(this DlgAppraisalSelect self, ItemInfo bagInfo)
        {
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(self.BagInfo_Equip.ItemID);
            self.BagInfo_Appri = bagInfo;
            self.View.ES_CommonItem_2.UpdateItem(bagInfo, ItemOperateEnum.None);
            self.View.ES_CommonItem_2.uiTransform.gameObject.SetActive(true);
            self.View.ES_CommonItem_2.E_ItemNumText.gameObject.SetActive(false);
            using (zstring.Block())
            {
                self.View.E_JianDingQualityText.text = zstring.Format("品质:{0}", bagInfo.ItemPar);
            }

            string jianDingStr = "大海捞针";
            int chaValue = 0;
            if (!string.IsNullOrEmpty(bagInfo.ItemPar))
            {
                chaValue = int.Parse(bagInfo.ItemPar) - itemCof.UseLv;
            }

            if (chaValue < 0)
            {
                jianDingStr = "大海捞针";
                self.View.E_JianDingShowText.color = new Color(130f / 255f, 130f / 255f, 130f / 255f);
            }

            if (chaValue >= 0 && chaValue < 8)
            {
                jianDingStr = "一击必中";
                self.View.E_JianDingShowText.color = new Color(175f / 255f, 200f / 255f, 20f / 255f);
            }

            if (chaValue >= 8 && chaValue < 16)
            {
                jianDingStr = "十发十中";
                self.View.E_JianDingShowText.color = CommonViewHelper.QualityReturnColor(2);
            }

            if (chaValue >= 16 && chaValue < 24)
            {
                jianDingStr = "百年不遇";
                self.View.E_JianDingShowText.color = CommonViewHelper.QualityReturnColor(3);
            }

            if (chaValue >= 24 && chaValue < 32)
            {
                jianDingStr = "千载难逢";
                self.View.E_JianDingShowText.color = CommonViewHelper.QualityReturnColor(4);
            }

            if (chaValue >= 32 && chaValue < 999)
            {
                jianDingStr = "万里挑一";
                self.View.E_JianDingShowText.color = CommonViewHelper.QualityReturnColor(5);
            }

            self.View.E_JianDingShowText.text = jianDingStr;
            self.View.EG_JianDingSetRectTransform.gameObject.SetActive(true);

            //显示鉴定属性范围
            EquipConfig equipCof = EquipConfigCategory.Instance.Get(itemCof.ItemEquipID);

            int zizhi = 0;
            if (!string.IsNullOrEmpty(bagInfo.ItemPar))
            {
                zizhi = int.Parse(bagInfo.ItemPar);
            }

            JianDingDate jiandingDate = ItemHelper.GetEquipZhuanJingPro(equipCof.Id, bagInfo.ItemID, zizhi, true);
            using (zstring.Block())
            {
                self.View.E_JianDingShowProText.text = zstring.Format("范围:{0}-{1}", jiandingDate.MinNum, jiandingDate.MaxNum);
            }

            self.UpdateSelect(bagInfo);
        }

        public static void RefreshCommonItems(this DlgAppraisalSelect self)
        {
            self.ShowBagInfos.Clear();

            List<ItemInfo> bagInfos = self.Root().GetComponent<BagComponentC>().GetBagList();
            //鉴定符
            for (int i = 0; i < bagInfos.Count; i++)
            {
                if (bagInfos[i].ItemID != self.AppraisalItemConfigId && bagInfos[i].ItemID != 1140000)
                {
                    continue;
                }

                self.ShowBagInfos.Add(bagInfos[i]);
            }

            self.ShowBagInfos.Sort(delegate(EntityRef<ItemInfo> a, EntityRef<ItemInfo> b)
            {
                ItemInfo aItem = a;
                ItemInfo bItem = b;
                ItemConfig itemConfig_a = ItemConfigCategory.Instance.Get(aItem.ItemID);
                ItemConfig itemConfig_b = ItemConfigCategory.Instance.Get(bItem.ItemID);
                int jianDingLva = itemConfig_a.ItemSubType == 121 && !string.IsNullOrEmpty(aItem.ItemPar) ? int.Parse(aItem.ItemPar) : 0;
                int jianDingLvb = itemConfig_b.ItemSubType == 121 && !string.IsNullOrEmpty(bItem.ItemPar) ? int.Parse(bItem.ItemPar) : 0;
                return jianDingLvb - jianDingLva;
            });

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.View.E_CommonItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }

        private static void UpdateSelect(this DlgAppraisalSelect self, ItemInfo bagInfo)
        {
            for (int i = 0; i < self.ScrollItemCommonItems.Keys.Count - 1; i++)
            {
                Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[i];
                // 滚动组件的子物体是动态从对象池里拿的，只引用看的到的
                if (scrollItemCommonItem.uiTransform != null)
                {
                    scrollItemCommonItem.SetSelected(bagInfo);
                }
            }
        }

        private static void OnCloseButton(this DlgAppraisalSelect self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_AppraisalSelect);
        }

        private static void OnCoinButton(this DlgAppraisalSelect self)
        {
            BagClientNetHelper.RequestAppraisalItem(self.Root(), self.BagInfo_Equip).Coroutine();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_AppraisalSelect);
        }

        private static void OnItemButton(this DlgAppraisalSelect self)
        {
            FlyTipComponent flyTipComponent = self.Root().GetComponent<FlyTipComponent>();
            if (self.BagInfo_Appri == null)
            {
                flyTipComponent.ShowFlyTip("请选择鉴定符！");
                return;
            }

            if (self.BagInfo_Equip.BagInfoID == self.BagInfo_Appri.BagInfoID)
            {
                return;
            }

            BagClientNetHelper.RequestAppraisalItem(self.Root(), self.BagInfo_Equip, self.BagInfo_Appri.BagInfoID).Coroutine();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_AppraisalSelect);
            flyTipComponent.ShowFlyTip("恭喜您！道具发挥了作用，鉴定成功!");
        }
    }
}
