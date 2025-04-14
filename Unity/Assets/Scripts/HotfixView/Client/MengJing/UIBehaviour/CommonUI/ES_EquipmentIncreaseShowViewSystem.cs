using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
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
            self.E_EquipItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnEquipItemsRefresh);
            self.E_ReelItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnReelItemsRefresh);
            self.E_IncreaseButtonButton.AddListenerAsync(self.OnIncreaseButtonButton);

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            ItemInfo bagInfo = bagComponent.GetEquipBySubType(ItemLocType.ItemLocEquip, (int)ItemSubTypeEnum.Wuqi);
            self.ES_EquipSet.PlayerLv(userInfo.Lv);
            self.ES_EquipSet.PlayerName(userInfo.Name);
            self.ES_EquipSet.ShowPlayerModel(bagInfo, userInfo.Occ, unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.EquipIndex),
                bagComponent.FashionEquipList);

            self.ES_CommonItem.uiTransform.gameObject.SetActive(false);

            self.OnUpdateUI();
            self.InitSubItemUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_EquipmentIncreaseShow self)
        {
            self.DestroyWidget();
        }

        private static void OnItemTypeSet(this ES_EquipmentIncreaseShow self, int page)
        {
            self.Page = page;
            self.EquipmentBagInfo = null;
            self.OnEquiListUpdate(page);
        }

        public static void OnUpdateUI(this ES_EquipmentIncreaseShow self)
        {
            self.OnEquiListUpdate(self.Page);
            self.OnReelListUpdate();
        }

        public static void UpdateAttribute(this ES_EquipmentIncreaseShow self, ItemInfo bagInfo)
        {
            CommonViewHelper.DestoryChild(self.EG_EquipBaseSetListRectTransform.gameObject);
            if (bagInfo == null)
            {
                return;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            ItemViewHelp.ShowBaseAttribute(bagComponent.GetEquipList(), bagInfo, self.E_Obj_EquipPropertyTextText.gameObject,
                self.EG_EquipBaseSetListRectTransform.gameObject);
        }

        public static void OnUpdateIncrease(this ES_EquipmentIncreaseShow self)
        {
            self.EquipmentBagInfo = self.Root().GetComponent<BagComponentC>().GetBagInfo(self.EquipmentBagInfo.BagInfoID);
            ItemInfo bagInfo = self.EquipmentBagInfo;
            self.UpdateAttribute(bagInfo);
            if (bagInfo == null)
            {
                return;
            }

            if (self.ES_CommonItem != null)
            {
                self.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            }
        }

        private static void OnEquipItemsRefresh(this ES_EquipmentIncreaseShow self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemEquipItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemEquipItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowEquipBagInfos[index], ItemOperateEnum.ItemXiLian, self.OnSelectEquip);
        }

        public static void OnEquiListUpdate(this ES_EquipmentIncreaseShow self, int page)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (page == 0)
            {
                self.ES_EquipSet.uiTransform.gameObject.SetActive(true);
                self.E_EquipItemsLoopVerticalScrollRect.gameObject.SetActive(false);

                self.ES_EquipSet.PlayShowIdelAnimate(null);
                self.ES_EquipSet.RefreshEquip(bagComponent.GetItemsByLoc(ItemLocType.ItemLocEquip),
                    bagComponent.GetItemsByLoc(ItemLocType.ItemLocEquip_2), userInfoComponent.UserInfo.Occ, ItemOperateEnum.Juese);
                self.ES_EquipSet.SetCallBack(self.OnSelectEquip);
            }
            else
            {
                self.ES_EquipSet.uiTransform.gameObject.SetActive(false);
                self.E_EquipItemsLoopVerticalScrollRect.gameObject.SetActive(true);

                List<ItemInfo> equipInfos = bagComponent.GetItemsByType(ItemTypeEnum.Equipment);
                self.ShowEquipBagInfos.Clear();
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

                    self.ShowEquipBagInfos.Add(equipInfos[i]);
                }

                self.AddUIScrollItems(ref self.ScrollItemEquipItems, self.ShowEquipBagInfos.Count);
                self.E_EquipItemsLoopVerticalScrollRect.SetVisible(true, self.ShowEquipBagInfos.Count);

                if (self.EquipmentBagInfo != null)
                {
                    self.OnSelectEquip(self.EquipmentBagInfo);
                }
                else if (self.ShowEquipBagInfos.Count > 0)
                {
                    Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemEquipItems[0];
                    if (scrollItemCommonItem.uiTransform != null)
                    {
                        scrollItemCommonItem.OnClickUIItem();
                    }
                }
            }
        }

        private static void OnReelItemsRefresh(this ES_EquipmentIncreaseShow self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemReelItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemReelItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowReelBagInfos[index], ItemOperateEnum.None, self.OnSelectReel);
        }

        public static void OnReelListUpdate(this ES_EquipmentIncreaseShow self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            self.ShowReelBagInfos.Clear();
            foreach (ItemInfo bagInfo in bagComponent.GetBagList())
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                if (itemConfig.ItemType == ItemTypeEnum.Consume && itemConfig.ItemSubType == 17)
                {
                    self.ShowReelBagInfos.Add(bagInfo);
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemReelItems, self.ShowReelBagInfos.Count);
            self.E_ReelItemsLoopVerticalScrollRect.SetVisible(true, self.ShowReelBagInfos.Count);
        }

        public static void OnSelectReel(this ES_EquipmentIncreaseShow self, ItemInfo bagInfo)
        {
            self.ReelBagInfo = bagInfo;
            if (self.ScrollItemReelItems != null)
            {
                foreach (var value in self.ScrollItemReelItems.Values)
                {
                    Scroll_Item_CommonItem item = value;
                    if (item.uiTransform != null)
                    {
                        item.SetSelected(bagInfo);
                    }
                }
            }
        }

        public static void OnSelectEquip(this ES_EquipmentIncreaseShow self, ItemInfo bagInfo)
        {
            self.EquipmentBagInfo = bagInfo;
            if (self.ScrollItemEquipItems != null)
            {
                foreach (var value in self.ScrollItemEquipItems.Values)
                {
                    Scroll_Item_CommonItem item = value;
                    if (item.uiTransform != null)
                    {
                        item.SetSelected(bagInfo);
                    }
                }
            }

            self.OnUpdateIncrease();
        }

        public static void InitSubItemUI(this ES_EquipmentIncreaseShow self)
        {
            ItemInfo bagInfo = self.EquipmentBagInfo;
            if (bagInfo != null)
            {
                self.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
                self.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);
            }
        }

        public static async ETTask OnIncreaseButtonButton(this ES_EquipmentIncreaseShow self)
        {
            if (self.EquipmentBagInfo == null)
            {
                return;
            }

            if (self.ReelBagInfo == null)
            {
                FlyTipComponent.Instance.ShowFlyTip("未选择增幅卷轴");
                return;
            }

            // 获取卷轴的传承和非传承的技能与属性
            zstring reelCanTransfAttribute = "传承增幅:";
            zstring reelNoTransfAttribute = "增幅:";
            for (int i = 0; i < self.ReelBagInfo.IncreaseProLists.Count; i++)
            {
                HideProList hide = self.ReelBagInfo.IncreaseProLists[i];
                HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(hide.HideID);
                string proName = ItemViewHelp.GetAttributeName(hideProListConfig.PropertyType);
                int showType = NumericHelp.GetNumericValueType(hideProListConfig.PropertyType);

                using (zstring.Block())
                {
                    string str = "";
                    if (showType == 2)
                    {
                        float value = (float)hide.HideValue / 100f;
                        str = zstring.Format("{0} {1}% }", proName, value.ToString("0.##"));
                    }
                    else
                    {
                        str = zstring.Format("{0} {1} ", proName, hide.HideValue);
                    }

                    if (hideProListConfig.IfMove == 1)
                    {
                        reelCanTransfAttribute += str;
                    }
                    else
                    {
                        reelNoTransfAttribute += str;
                    }
                }
            }

            for (int i = 0; i < self.ReelBagInfo.IncreaseSkillLists.Count; i++)
            {
                int hide = self.ReelBagInfo.IncreaseSkillLists[i];
                HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(hide);
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(hideProListConfig.PropertyType);
                string skillName = skillConfig.SkillName;

                using (zstring.Block())
                {
                    if (hideProListConfig.IfMove == 1)
                    {
                        reelCanTransfAttribute += zstring.Format("{0} ", skillName);
                    }
                    else
                    {
                        reelNoTransfAttribute += zstring.Format("{0} ", skillName);
                    }
                }
            }

            // 获取装备的传承和非传承的技能与属性
            zstring equipmentCanTransfAttribute = "传承增幅:";
            zstring equipmentNoTransfAttribute = "增幅:";
            for (int i = 0; i < self.EquipmentBagInfo.IncreaseProLists.Count; i++)
            {
                HideProList hide = self.EquipmentBagInfo.IncreaseProLists[i];
                HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(hide.HideID);
                string proName = ItemViewHelp.GetAttributeName(hideProListConfig.PropertyType);
                int showType = NumericHelp.GetNumericValueType(hideProListConfig.PropertyType);

                using (zstring.Block())
                {
                    string str = "";
                    if (showType == 2)
                    {
                        float value = (float)hide.HideValue / 100f;
                        str = zstring.Format("{0} {1}% ", proName, value.ToString("0.##"));
                    }
                    else
                    {
                        str = zstring.Format("{0} {1} ", proName, hide.HideValue);
                    }

                    if (hideProListConfig.IfMove == 1)
                    {
                        equipmentCanTransfAttribute += str;
                    }
                    else
                    {
                        equipmentNoTransfAttribute += str;
                    }
                }
            }

            for (int i = 0; i < self.EquipmentBagInfo.IncreaseSkillLists.Count; i++)
            {
                int hide = self.EquipmentBagInfo.IncreaseSkillLists[i];
                HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(hide);
                SkillConfig skillConfig = SkillConfigCategory.Instance.Get(hideProListConfig.PropertyType);
                string skillName = skillConfig.SkillName;

                using (zstring.Block())
                {
                    if (hideProListConfig.IfMove == 1)
                    {
                        equipmentCanTransfAttribute += zstring.Format("{0} ", skillName);
                    }
                    else
                    {
                        equipmentNoTransfAttribute += zstring.Format("{0} ", skillName);
                    }
                }
            }

            // 当前装备已经存在传承增幅
            zstring tipStr = "";
            bool isTip = false;
            using (zstring.Block())
            {
                if (reelCanTransfAttribute != "传承增幅:" && equipmentCanTransfAttribute != "传承增幅:")
                {
                    tipStr += zstring.Format("当前<color=#BEFF34>{0}</color> \n是否覆盖已有\n{1}\n", reelCanTransfAttribute, equipmentCanTransfAttribute);
                    isTip = true;
                }

                // 当前装备已经存在非传承增幅
                if (reelNoTransfAttribute != "增幅:" && equipmentNoTransfAttribute != "增幅:")
                {
                    tipStr += zstring.Format("当前<color=#BEFF34>{0}</color> \n是否覆盖已有\n{1}\n", reelNoTransfAttribute, equipmentNoTransfAttribute);
                    isTip = true;
                }
            }

            // 是否弹出提示框
            if (isTip)
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "装备增幅", tipStr, async () =>
                {
                    await BagClientNetHelper.SendEquipmentIncrease(self.Root(), self.EquipmentBagInfo, self.ReelBagInfo);
                    FlyTipComponent.Instance.ShowFlyTip("增幅成功");
                    self.OnUpdateIncrease();
                }, () => { }).Coroutine();
            }
            else
            {
                await BagClientNetHelper.SendEquipmentIncrease(self.Root(), self.EquipmentBagInfo, self.ReelBagInfo);
                FlyTipComponent.Instance.ShowFlyTip("增幅成功");
                self.OnUpdateIncrease();
            }
        }
    }
}
