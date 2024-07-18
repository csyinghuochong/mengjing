using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(ES_CommonItem))]
    [FriendOf(typeof(ES_EquipSet))]
    [EntitySystemOf(typeof(ES_EquipmentIncreaseShow))]
    [FriendOfAttribute(typeof(ES_EquipmentIncreaseShow))]
    public static partial class ES_EquipmentIncreaseShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_EquipmentIncreaseShow self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_EquipItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.E_BagItemsLoopVerticalScrollRect.

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            BagInfo bagInfo = bagComponent.GetEquipBySubType(ItemLocType.ItemLocEquip, (int)ItemSubTypeEnum.Wuqi);
            self.ES_EquipSet.PlayerLv(userInfo.Lv);
            self.ES_EquipSet.PlayerName(userInfo.Name);
            self.ES_EquipSet.ShowPlayerModel(bagInfo, userInfo.Occ, unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.EquipIndex),
                bagComponent.FashionEquipList);

            self.ES_CommonItem.uiTransform.gameObject.SetActive(false);
        }

        [EntitySystem]
        private static void Destroy(this ES_EquipmentIncreaseShow self)
        {
            self.DestroyWidget();
        }

        private static void OnItemTypeSet(this ES_EquipmentIncreaseShow self, int index)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            switch (index)
            {
                case 0:
                    self.ES_EquipSet.uiTransform.gameObject.SetActive(true);
                    self.E_EquipItemsLoopVerticalScrollRect.gameObject.SetActive(false);

                    self.ES_EquipSet.PlayShowIdelAnimate(null);
                    self.ES_EquipSet.RefreshEquip(bagComponent.GetItemsByLoc(ItemLocType.ItemLocEquip),
                        bagComponent.GetItemsByLoc(ItemLocType.ItemLocEquip_2), userInfoComponent.UserInfo.Occ, ItemOperateEnum.Juese);
                    self.ES_EquipSet.SetCallBack(self.OnSelectItem);
                    break;
                case 1:
                    self.ES_EquipSet.uiTransform.gameObject.SetActive(false);
                    self.E_EquipItemsLoopVerticalScrollRect.gameObject.SetActive(true);

                    self.ShowBagInfos.Clear();
                    List<BagInfo> equipInfos = bagComponent.GetItemsByType(ItemTypeEnum.Equipment);
                    for (int i = 0; i < equipInfos.Count; i++)
                    {
                        if (equipInfos[i].IfJianDing)
                        {
                            continue;
                        }

                        ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equipInfos[i].ItemID);
                        if (itemConfig.EquipType == 101 || itemConfig.EquipType == 201)
                        {
                            continue;
                        }

                        self.ShowBagInfos.Add(equipInfos[i]);
                    }

                    self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
                    self.E_EquipItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);

                    if (self.XilianBagInfo != null)
                    {
                        self.OnSelectItem(self.XilianBagInfo);
                    }
                    else if (self.ShowBagInfos.Count > 0)
                    {
                        Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[0];
                        if (scrollItemCommonItem.uiTransform != null)
                        {
                            scrollItemCommonItem.ES_CommonItem.OnClickUIItem();
                        }
                    }

                    break;
            }
        }

        private static void OnBagItemsRefresh(this ES_EquipmentIncreaseShow self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.ItemXiLian, self.OnSelectItem);
        }

        private static void OnSelectItem(this ES_EquipmentIncreaseShow self, BagInfo bagInfo)
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

                    item.UpdateSelectStatus(bagInfo);
                }
            }

            self.OnUpdateXinLian();
        }
    }
}