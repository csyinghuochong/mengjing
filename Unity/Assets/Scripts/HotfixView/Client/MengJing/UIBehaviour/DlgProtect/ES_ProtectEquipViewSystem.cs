using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof (ES_ProtectEquip))]
    [FriendOfAttribute(typeof (ES_ProtectEquip))]
    public static partial class ES_ProtectEquipSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ProtectEquip self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.E_XiLianButtonButton.AddListener(() => { self.OnXiLianButton(true).Coroutine(); });
            self.E_XiLianButtonButton.gameObject.SetActive(false);
            self.E_ButtonUnLockButton.AddListener(() => { self.OnXiLianButton(false).Coroutine(); });
            self.E_ButtonUnLockButton.gameObject.SetActive(false);
            self.InitSubItemUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_ProtectEquip self)
        {
            self.DestroyWidget();
        }

        private static void OnBagItemsRefresh(this ES_ProtectEquip self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.ItemXiLian, self.OnSelectItem);
        }

        public static void OnUpdateUI(this ES_ProtectEquip self)
        {
            self.XilianBagInfo = null;
            self.OnEquiListUpdate();
        }

        public static void UpdateAttribute(this ES_ProtectEquip self, BagInfo bagInfo)
        {
            CommonViewHelper.DestoryChild(self.EG_EquipBaseSetListRectTransform.gameObject);
            if (!bagInfo.IfJianDing)
            {
                BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
                ItemViewHelp.ShowBaseAttribute(bagComponent.GetEquipList(), bagInfo, self.E_Obj_EquipPropertyTextText.gameObject,
                    self.EG_EquipBaseSetListRectTransform.gameObject);
            }
        }

        public static void OnUpdateXinLian(this ES_ProtectEquip self)
        {
            BagInfo bagInfo = self.XilianBagInfo;
            self.UpdateAttribute(bagInfo);
            self.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            self.E_ButtonUnLockButton.gameObject.SetActive(bagInfo.IsProtect);
            self.E_XiLianButtonButton.gameObject.SetActive(!bagInfo.IsProtect);
        }

        public static void OnXiLianReturn(this ES_ProtectEquip self)
        {
            self.OnUpdateXinLian();
            self.OnEquiListUpdate();
        }

        public static void OnEquiListUpdate(this ES_ProtectEquip self)
        {
            List<BagInfo> equipInfos = self.Root().GetComponent<BagComponentC>().GetItemsByType(ItemTypeEnum.Equipment);

            self.ShowBagInfos.Clear();
            for (int i = 0; i < equipInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equipInfos[i].ItemID);
                if (itemConfig.EquipType == 101)
                {
                    continue;
                }

                self.ShowBagInfos.Add(equipInfos[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);

            if (self.XilianBagInfo != null)
            {
                self.OnSelectItem(self.XilianBagInfo);
            }
            else if (self.ShowBagInfos.Count > 0)
            {
                if (self.ScrollItemCommonItems != null && self.ScrollItemCommonItems.Count > 0 && self.ScrollItemCommonItems[0].uiTransform != null)
                {
                    self.ScrollItemCommonItems[0].ES_CommonItem.OnClickUIItem();
                }
            }
        }

        public static void OnSelectItem(this ES_ProtectEquip self, BagInfo bagInfo)
        {
            self.XilianBagInfo = bagInfo;
            if (self.ScrollItemCommonItems != null)
            {
                foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.ES_CommonItem.SetSelected(bagInfo);
                }
            }

            self.OnUpdateXinLian();
        }

        public static void InitSubItemUI(this ES_ProtectEquip self)
        {
            BagInfo bagInfo = self.XilianBagInfo;
            self.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            self.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);
        }

        public static async ETTask OnXiLianButton(this ES_ProtectEquip self, bool isprotectd)
        {
            BagInfo bagInfo = self.XilianBagInfo;
            if (bagInfo == null)
            {
                return;
            }

            await BagClientNetHelper.ItemProtect(self.Root(), bagInfo.BagInfoID, isprotectd);

            if (self.IsDisposed)
            {
                return;
            }

            string tip = isprotectd? "锁定" : "解锁";
            FlyTipComponent.Instance.ShowFlyTipDi($"装备{tip}成功");
            self.XilianBagInfo = self.Root().GetComponent<BagComponentC>().GetBagInfo(self.XilianBagInfo.BagInfoID);
            self.OnXiLianReturn();
        }
    }
}