using System;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_XiLianShowEquipItem))]
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(ES_CommonItem))]
    [FriendOf(typeof(ES_EquipSet))]
    [EntitySystemOf(typeof(ES_RoleXiLianShow))]
    [FriendOfAttribute(typeof(ES_RoleXiLianShow))]
    public static partial class ES_RoleXiLianShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleXiLianShow self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_EquipItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.E_XiLianButtonButton.AddListener(() => { self.OnXiLianButton(1).Coroutine(); });
            self.E_XiLianTenButton.AddListener(() => { self.OnXiLianButton(5).Coroutine(); });
            self.E_Btn_XiLianNumRewardButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_RoleXiLianNumReward).Coroutine();
            });
            self.E_Btn_XiLianExplainButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_RoleXiLianExplain).Coroutine();
            });

            using (zstring.Block())
            {
                self.E_NeedDiamondText.text = zstring.Format("x {0}", GlobalValueConfigCategory.Instance.Get(73).Value);
            }

            self.EG_XiLianInfoRectTransform.gameObject.SetActive(false);
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleXiLianShow self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.AssetList.Count; i++)
            {
                resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
            }

            self.AssetList.Clear();
            self.AssetList = null;

            self.DestroyWidget();
        }

        private static void OnItemTypeSet(this ES_RoleXiLianShow self, int index)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            switch (index)
            {
                case 0:
                    self.E_XiLianShowEquipItemsScrollRect.gameObject.SetActive(true);
                    self.E_EquipItemsLoopVerticalScrollRect.gameObject.SetActive(false);

                    List<ItemInfo> itemInfos = new List<ItemInfo>();
                    itemInfos.AddRange(bagComponent.GetItemsByLoc(ItemLocType.ItemLocEquip));
                    itemInfos.AddRange(bagComponent.GetItemsByLoc(ItemLocType.ItemLocEquip_2));

                    for (int i = itemInfos.Count; i < 14; i++)
                    {
                        itemInfos.Add(null);
                    }

                    ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
                    for (int i = 0; i < itemInfos.Count; i++)
                    {
                        if (!self.ScrollItemXiLianShowEquipItems.ContainsKey(i))
                        {
                            Scroll_Item_XiLianShowEquipItem item = self.AddChild<Scroll_Item_XiLianShowEquipItem>();
                            string path = "Assets/Bundles/UI/Item/Item_XiLianShowEquipItem.prefab";
                            if (!self.AssetList.Contains(path))
                            {
                                self.AssetList.Add(path);
                            }

                            GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                            GameObject go = UnityEngine.Object.Instantiate(prefab,
                                self.E_XiLianShowEquipItemsScrollRect.transform.Find("Content").gameObject.transform);
                            item.BindTrans(go.transform);
                            self.ScrollItemXiLianShowEquipItems.Add(i, item);
                        }

                        Scroll_Item_XiLianShowEquipItem scrollItemXiLianShowEquipItem = self.ScrollItemXiLianShowEquipItems[i];
                        scrollItemXiLianShowEquipItem.uiTransform.gameObject.SetActive(true);
                        scrollItemXiLianShowEquipItem.Refresh(itemInfos[i], userInfoComponent.UserInfo.Occ, ItemOperateEnum.Juese, itemInfos);
                        scrollItemXiLianShowEquipItem.OnClickAction = self.OnSelectEquipItem;
                        scrollItemXiLianShowEquipItem.UpdateSelectStatus(self.XilianBagInfo);
                    }

                    if (self.ScrollItemXiLianShowEquipItems.Count > itemInfos.Count)
                    {
                        for (int i = itemInfos.Count; i < self.ScrollItemXiLianShowEquipItems.Count; i++)
                        {
                            Scroll_Item_XiLianShowEquipItem scrollItemXiLianShowEquipItem = self.ScrollItemXiLianShowEquipItems[i];
                            scrollItemXiLianShowEquipItem.uiTransform.gameObject.SetActive(false);
                        }
                    }

                    break;
                case 1:
                    self.E_XiLianShowEquipItemsScrollRect.gameObject.SetActive(false);
                    self.E_EquipItemsLoopVerticalScrollRect.gameObject.SetActive(true);

                    self.ShowBagInfos.Clear();
                    List<ItemInfo> equipInfos = bagComponent.GetItemsByType(ItemTypeEnum.Equipment);
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

                    // if (self.XilianBagInfo != null)
                    // {
                    //     self.OnSelectBagItem(self.XilianBagInfo);
                    // }
                    // else if (self.ShowBagInfos.Count > 0)
                    // {
                    //     Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[0];
                    //     if (scrollItemCommonItem.uiTransform != null)
                    //     {
                    //         scrollItemCommonItem.OnClickUIItem();
                    //     }
                    // }

                    break;
            }

            if (self.CurrentItemType != index)
            {
                self.ResetEquipCombatChange(self.XilianBagInfo);
                self.OnUpdateXinLian();
            }
            
            self.CurrentItemType = index;
        }

        public static void OnUpdateUI(this ES_RoleXiLianShow self)
        {
            self.XilianBagInfo = null;
            self.EG_XiLianInfoRectTransform.gameObject.SetActive(false);
            self.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
        }

        private static void OnBagItemsRefresh(this ES_RoleXiLianShow self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.ItemXiLian, self.OnSelectBagItem);
            scrollItemCommonItem.E_ItemDragEventTrigger.gameObject.SetActive(false);
            self.SetBagItemSelect(self.XilianBagInfo);
        }

        private static void SetBagItemSelect(this ES_RoleXiLianShow self, ItemInfo bagInfo)
        {
            if (self.ScrollItemCommonItems != null)
            {
                foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.SetSelected(bagInfo);
                }
            }

        }
        
        private static void OnSelectBagItem(this ES_RoleXiLianShow self, ItemInfo bagInfo)
        {
            self.XilianBagInfo = bagInfo;

            self.SetBagItemSelect(bagInfo);

            self.ResetEquipCombatChange(bagInfo);
            self.OnUpdateXinLian();
        }

        private static void OnSelectEquipItem(this ES_RoleXiLianShow self, ItemInfo bagInfo)
        {
            self.XilianBagInfo = bagInfo;

            if (self.ScrollItemXiLianShowEquipItems != null)
            {
                foreach (Scroll_Item_XiLianShowEquipItem item in self.ScrollItemXiLianShowEquipItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.UpdateSelectStatus(bagInfo);
                }
            }

            self.ResetEquipCombatChange(bagInfo);
            self.OnUpdateXinLian();
        }

        public static void UpdateAttribute(this ES_RoleXiLianShow self, ItemInfo bagInfo)
        {
            CommonViewHelper.DestoryChild(self.E_XiLianShowEquipPropertyItemsScrollRect.transform.Find("Content").gameObject);
            if (bagInfo == null)
            {
                return;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            ResourcesLoaderComponent resourcesLoader = self.Root().GetComponent<ResourcesLoaderComponent>();
            string path = "Assets/Bundles/UI/Item/Item_XiLianShowEquipPropertyItem.prefab";
            if (!self.AssetList.Contains(path))
            {
                self.AssetList.Add(path);
            }

            GameObject prefab = resourcesLoader.LoadAssetSync<GameObject>(path);
            self.ShowXiLianAttribute(bagComponent.GetEquipList(), bagInfo, prefab, self.E_XiLianShowEquipPropertyItemsScrollRect.transform.Find("Content").gameObject);
        }

        public static int ShowXiLianAttribute(this ES_RoleXiLianShow self, List<ItemInfo> equipItemList, ItemInfo itemInfo, GameObject propertyGO,
        GameObject parentGO)
        {
            int properShowNum = 0;
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemInfo.ItemID);
            EquipConfig equipConfig = EquipConfigCategory.Instance.Get(itemConfig.ItemEquipID);
            int equip_Hp = equipConfig.Equip_Hp;
            int equip_MinAct = equipConfig.Equip_MinAct;
            int equip_MaxAct = equipConfig.Equip_MaxAct;
            int equip_MinMagAct = equipConfig.Equip_MinMagAct;
            int equip_MaxMagAct = equipConfig.Equip_MaxMagAct;
            int equip_MinDef = equipConfig.Equip_MinDef;
            int equip_MaxDef = equipConfig.Equip_MaxDef;
            int equip_MinAdf = equipConfig.Equip_MinAdf;
            int equip_MaxAdf = equipConfig.Equip_MaxAdf;
            double equip_Cri = equipConfig.Equip_Cri;
            double equip_Hit = equipConfig.Equip_Hit;
            double equip_Dodge = equipConfig.Equip_Dodge;
            double equip_DamgeAdd = equipConfig.Equip_DamgeAdd;
            double equip_DamgeSub = equipConfig.Equip_DamgeSub;
            double equip_Speed = equipConfig.Equip_Speed;
            double equip_Lucky = equipConfig.Equip_Lucky;

            ItemInfo last_itemInfo = self.EquipCombatChangeDic[itemInfo.BagInfoID].Item1;
            int last_equip_Hp = equipConfig.Equip_Hp;
            int last_equip_MinAct = equipConfig.Equip_MinAct;
            int last_equip_MaxAct = equipConfig.Equip_MaxAct;
            int last_equip_MinMagAct = equipConfig.Equip_MinMagAct;
            int last_equip_MaxMagAct = equipConfig.Equip_MaxMagAct;
            int last_equip_MinDef = equipConfig.Equip_MinDef;
            int last_equip_MaxDef = equipConfig.Equip_MaxDef;
            int last_equip_MinAdf = equipConfig.Equip_MinAdf;
            int last_equip_MaxAdf = equipConfig.Equip_MaxAdf;
            double last_equip_Cri = equipConfig.Equip_Cri;
            double last_equip_Hit = equipConfig.Equip_Hit;
            double last_equip_Dodge = equipConfig.Equip_Dodge;
            double last_equip_DamgeAdd = equipConfig.Equip_DamgeAdd;
            double last_equip_DamgeSub = equipConfig.Equip_DamgeSub;
            double last_equip_Speed = equipConfig.Equip_Speed;
            double last_equip_Lucky = equipConfig.Equip_Lucky;
            
            
            // 换算总显示数值
            if (itemInfo.XiLianHideProLists != null)
            {
                for (int i = 0; i < itemInfo.XiLianHideProLists.Count; i++)
                {
                    int hidePropertyType = itemInfo.XiLianHideProLists[i].HideID;
                    int hidePropertyValue = (int)itemInfo.XiLianHideProLists[i].HideValue;

                    switch (hidePropertyType)
                    {
                        case NumericType.Base_MaxHp_Base:
                            equip_Hp = equip_Hp + hidePropertyValue;
                            break;
                        case NumericType.Base_MaxAct_Base:
                            equip_MaxAct = equip_MaxAct + hidePropertyValue;
                            break;
                        case NumericType.Base_MaxDef_Base:
                            equip_MaxDef = equip_MaxDef + hidePropertyValue;
                            break;
                        case NumericType.Base_MaxAdf_Base:
                            equip_MaxAdf = equip_MaxAdf + hidePropertyValue;
                            break;
                    }
                }
            }
            if (last_itemInfo.XiLianHideProLists != null)
            {
                for (int i = 0; i < last_itemInfo.XiLianHideProLists.Count; i++)
                {
                    int hidePropertyType = last_itemInfo.XiLianHideProLists[i].HideID;
                    int hidePropertyValue = (int)last_itemInfo.XiLianHideProLists[i].HideValue;

                    switch (hidePropertyType)
                    {
                        case NumericType.Base_MaxHp_Base:
                            last_equip_Hp = equip_Hp + hidePropertyValue;
                            break;
                        case NumericType.Base_MaxAct_Base:
                            last_equip_MaxAct = equip_MaxAct + hidePropertyValue;
                            break;
                        case NumericType.Base_MaxDef_Base:
                            last_equip_MaxDef = equip_MaxDef + hidePropertyValue;
                            break;
                        case NumericType.Base_MaxAdf_Base:
                            last_equip_MaxAdf = equip_MaxAdf + hidePropertyValue;
                            break;
                    }
                }
            }

            // 显示职业护甲加成
            string occShowStr = "";
            string textShow = "";
            string langStr = "";

            if (equip_Hp != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("生命");
                textShow = langStr + "  " + equip_Hp + occShowStr;

                bool ifHideProperty = false;
                int hidePropertyType = 0;
                int hidePropertyValue = 0;
                if (itemInfo.XiLianHideProLists != null)
                {
                    for (int i = 0; i < itemInfo.XiLianHideProLists.Count; i++)
                    {
                        hidePropertyType = itemInfo.XiLianHideProLists[i].HideID;

                        if (hidePropertyType == NumericType.Base_MaxHp_Base)
                        {
                            hidePropertyValue = (int)itemInfo.XiLianHideProLists[i].HideValue;
                            textShow = langStr + " ：" + equip_Hp + "(+" + hidePropertyValue + ")" + occShowStr + occShowStr;
                            ifHideProperty = true;
                        }
                    }
                }
                int last_hidePropertyValue = 0;
                if (last_itemInfo.XiLianHideProLists != null)
                {
                    for (int i = 0; i < last_itemInfo.XiLianHideProLists.Count; i++)
                    {
                        hidePropertyType = last_itemInfo.XiLianHideProLists[i].HideID;

                        if (hidePropertyType == NumericType.Base_MaxHp_Base)
                        {
                            last_hidePropertyValue = (int)last_itemInfo.XiLianHideProLists[i].HideValue;
                        }
                    }
                }

                if (ifHideProperty)
                {
                    GameObject newGo = self.ShowPropertyText_2(0, textShow, "1", propertyGO, parentGO, hidePropertyValue - last_hidePropertyValue);
                    self.ShowProgressBar(hidePropertyValue, equipConfig.HideMax, newGo);
                    properShowNum += 1;
                }
                else
                {
                    GameObject newGo = self.ShowPropertyText_2(0, textShow, "0", propertyGO, parentGO, hidePropertyValue - last_hidePropertyValue);
                    self.ShowProgressBar(hidePropertyValue, equipConfig.HideMax, newGo);
                    properShowNum += 1;
                }
            }

            if (equip_MinAct != 0 || equip_MaxAct != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("攻击");
                textShow = langStr + " ：" + equip_MinAct + " - " + equip_MaxAct;
                bool ifHideProperty = false;
                int hidePropertyType = 0;
                int hidePropertyValue = 0;
                if (itemInfo.XiLianHideProLists != null)
                {
                    for (int i = 0; i < itemInfo.XiLianHideProLists.Count; i++)
                    {
                        hidePropertyType = itemInfo.XiLianHideProLists[i].HideID;

                        if (hidePropertyType == NumericType.Base_MaxAct_Base)
                        {
                            hidePropertyValue = (int)itemInfo.XiLianHideProLists[i].HideValue;
                            textShow = langStr + " ：" + equip_MinAct + " - " + equip_MaxAct + "(+" + hidePropertyValue + ")" + occShowStr;
                            ifHideProperty = true;
                        }
                    }
                }
                int last_hidePropertyValue = 0;
                if (last_itemInfo.XiLianHideProLists != null)
                {
                    for (int i = 0; i < last_itemInfo.XiLianHideProLists.Count; i++)
                    {
                        hidePropertyType = last_itemInfo.XiLianHideProLists[i].HideID;

                        if (hidePropertyType == NumericType.Base_MaxAct_Base)
                        {
                            last_hidePropertyValue = (int)last_itemInfo.XiLianHideProLists[i].HideValue;
                        }
                    }
                }

                if (ifHideProperty)
                {
                    GameObject newGo = self.ShowPropertyText_2(0, textShow, "1", propertyGO, parentGO, hidePropertyValue - last_hidePropertyValue);
                    self.ShowProgressBar(hidePropertyValue, equipConfig.HideMax, newGo);
                    properShowNum += 1;
                }
                else
                {
                    GameObject newGo = self.ShowPropertyText_2(0, textShow, "0", propertyGO, parentGO, hidePropertyValue - last_hidePropertyValue);
                    self.ShowProgressBar(hidePropertyValue, equipConfig.HideMax, newGo);
                    properShowNum += 1;
                }
            }

            if (equip_MinDef != 0 || equip_MaxDef != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("防御");
                textShow = langStr + " ：" + equip_MinDef + " - " + equip_MaxDef;
                bool ifHideProperty = false;
                int hidePropertyType = 0;
                int hidePropertyValue = 0;
                if (itemInfo.XiLianHideProLists != null)
                {
                    for (int i = 0; i < itemInfo.XiLianHideProLists.Count; i++)
                    {
                        hidePropertyType = itemInfo.XiLianHideProLists[i].HideID;

                        if (hidePropertyType == NumericType.Base_MaxDef_Base)
                        {
                            hidePropertyValue = (int)itemInfo.XiLianHideProLists[i].HideValue;
                            textShow = langStr + " ：" + equip_MinDef + " - " + equip_MaxDef + "(+" + hidePropertyValue + ")" + occShowStr;
                            ifHideProperty = true;
                        }
                    }
                }
                int last_hidePropertyValue = 0;
                if (last_itemInfo.XiLianHideProLists != null)
                {
                    for (int i = 0; i < last_itemInfo.XiLianHideProLists.Count; i++)
                    {
                        hidePropertyType = last_itemInfo.XiLianHideProLists[i].HideID;

                        if (hidePropertyType == NumericType.Base_MaxDef_Base)
                        {
                            last_hidePropertyValue = (int)last_itemInfo.XiLianHideProLists[i].HideValue;
                        }
                    }
                }

                if (ifHideProperty)
                {
                    GameObject newGo = self.ShowPropertyText_2(0, textShow, "1", propertyGO, parentGO, hidePropertyValue - last_hidePropertyValue);
                    self.ShowProgressBar(hidePropertyValue, equipConfig.HideMax, newGo);
                    properShowNum += 1;
                }
                else
                {
                    GameObject newGo = self.ShowPropertyText_2(0, textShow, "0", propertyGO, parentGO, hidePropertyValue - last_hidePropertyValue);
                    self.ShowProgressBar(hidePropertyValue, equipConfig.HideMax, newGo);
                    properShowNum += 1;
                }
            }

            if (equip_MinAdf != 0 || equip_MaxAdf != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("魔防");
                textShow = langStr + " ：" + equip_MinAdf + " - " + equip_MaxAdf;
                bool ifHideProperty = false;
                int hidePropertyType = 0;
                int hidePropertyValue = 0;
                if (itemInfo.XiLianHideProLists != null)
                {
                    for (int i = 0; i < itemInfo.XiLianHideProLists.Count; i++)
                    {
                        hidePropertyType = itemInfo.XiLianHideProLists[i].HideID;

                        if (hidePropertyType == NumericType.Base_MaxAdf_Base)
                        {
                            hidePropertyValue = (int)itemInfo.XiLianHideProLists[i].HideValue;
                            textShow = langStr + " ：" + equip_MinAdf + " - " + equip_MaxAdf + "(+" + hidePropertyValue + ")" + occShowStr;
                            ifHideProperty = true;
                        }
                    }
                }
                int last_hidePropertyValue = 0;
                if (last_itemInfo.XiLianHideProLists != null)
                {
                    for (int i = 0; i < last_itemInfo.XiLianHideProLists.Count; i++)
                    {
                        hidePropertyType = last_itemInfo.XiLianHideProLists[i].HideID;

                        if (hidePropertyType == NumericType.Base_MaxAdf_Base)
                        {
                            last_hidePropertyValue = (int)last_itemInfo.XiLianHideProLists[i].HideValue;
                        }
                    }
                }

                if (ifHideProperty)
                {
                    GameObject newGo = self.ShowPropertyText_2(0, textShow, "1", propertyGO, parentGO, hidePropertyValue - last_hidePropertyValue);
                    self.ShowProgressBar(hidePropertyValue, equipConfig.HideMax, newGo);
                    properShowNum += 1;
                }
                else
                {
                    GameObject newGo = self.ShowPropertyText_2(0, textShow, "0", propertyGO, parentGO, hidePropertyValue - last_hidePropertyValue);
                    self.ShowProgressBar(hidePropertyValue, equipConfig.HideMax, newGo);
                    properShowNum += 1;
                }
            }

            if (equip_Cri != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("暴击");
                textShow = langStr + "  " + equip_Cri * 100 + "%\n";
                GameObject newGo = self.ShowPropertyText_2(0, textShow, "0", propertyGO, parentGO);
                self.ShowProgressBar(1, 1, newGo);
                properShowNum += 1;
            }
            
            if (equip_Hit != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("命中");
                textShow = langStr + "  " + equip_Hit * 100 + "%\n";
                GameObject newGo = self.ShowPropertyText_2(0, textShow, "0", propertyGO, parentGO);
                self.ShowProgressBar(1, 1, newGo);
                properShowNum += 1;
            }
            
            if (equip_Dodge != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("闪避");
                textShow = langStr + "  " + equip_Dodge * 100 + "%\n";
                GameObject newGo = self.ShowPropertyText_2(0, textShow, "0", propertyGO, parentGO);
                self.ShowProgressBar(1, 1, newGo);
                properShowNum += 1;
            }
            
            if (equip_DamgeAdd != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("伤害加成");
                textShow = langStr + "  " + equip_DamgeAdd * 100 + "%\n";
                GameObject newGo = self.ShowPropertyText_2(0, textShow, "0", propertyGO, parentGO);
                self.ShowProgressBar(1, 1, newGo);
                properShowNum += 1;
            }
            
            if (equip_DamgeSub != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("伤害减免");
                textShow = langStr + "  " + equip_DamgeSub * 100 + "%\n";
                GameObject newGo = self.ShowPropertyText_2(0, textShow, "0", propertyGO, parentGO);
                self.ShowProgressBar(1, 1, newGo);
                properShowNum += 1;
            }
            
            if (equip_Speed != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("移动速度");
                textShow = langStr + "  " + equip_Dodge;
                GameObject newGo = self.ShowPropertyText_2(0, textShow, "0", propertyGO, parentGO);
                self.ShowProgressBar(1, 1, newGo);
                properShowNum += 1;
            }
            
            if (equip_Lucky != 0)
            {
                langStr = LanguageComponent.Instance.LoadLocalization("幸运值");
                textShow = langStr + "  " + equip_Lucky;
                GameObject newGo = self.ShowPropertyText_2(0, textShow, "6", propertyGO, parentGO);
                self.ShowProgressBar(1, 1, newGo);
                properShowNum += 1;
            }

            //显示隐藏洗炼属性
            if (itemInfo.XiLianHideTeShuProLists != null)
            {
                for (int i = 0; i < itemInfo.XiLianHideTeShuProLists.Count; i++)
                {
                    int nowType = itemInfo.XiLianHideTeShuProLists[i].HideID;
                    if (nowType != NumericType.Base_MaxHp_Base && nowType != NumericType.Base_MaxAct_Base &&
                        nowType != NumericType.Base_MaxDef_Base && nowType != NumericType.Base_MaxAdf_Base)
                    {
                        int hidePropertyType = itemInfo.XiLianHideTeShuProLists[i].HideID;
                        long hidePropertyValue = itemInfo.XiLianHideTeShuProLists[i].HideValue;
                        HideProListConfig hidePro = HideProListConfigCategory.Instance.Get(hidePropertyType);
                        string proStr = "";
                        string showColor = "1";
                        if (NumericHelp.GetNumericValueType(hidePro.PropertyType) == 2)
                        {
                            proStr = hidePro.Name + LanguageComponent.Instance.LoadLocalization("提升") +
                                    ((float)hidePropertyValue / 100.0f).ToString("0.##") +
                                    "%"; // 0.82   0.80
                        }
                        else
                        {
                            proStr = hidePro.Name + LanguageComponent.Instance.LoadLocalization("提升") + hidePropertyValue +
                                    LanguageComponent.Instance.LoadLocalization("点");

                            if (hidePro.Name == "幸运值")
                            {
                                showColor = "6";
                            }
                        }

                        GameObject newGo = self.ShowPropertyText_2(1, proStr, showColor, propertyGO, parentGO);
                        HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(hidePropertyType);
                        float propertyValueMax = float.Parse(hideProListConfig.PropertyValueMax);
                        self.ShowProgressBar(hidePropertyValue, NumericHelp.NumericValueSaveType(hideProListConfig.PropertyType, propertyValueMax), newGo);

                        properShowNum += 1;
                    }
                }
            }

            //显示隐藏技能
            if (itemInfo.HideSkillLists != null)
            {
                string skillTip = itemConfig.EquipType == 301 ? "套装效果，附加技能：" : "隐藏技能：";
                for (int i = 0; i < itemInfo.HideSkillLists.Count; i++)
                {
                    int skillID = itemInfo.HideSkillLists[i];
                    SkillConfig skillCof = SkillConfigCategory.Instance.Get(skillID);
                    string proStr = LanguageComponent.Instance.LoadLocalization(skillTip) + skillCof.SkillName;
                    GameObject newGo = self.ShowPropertyText_2(2, proStr, "2", propertyGO, parentGO);
                    self.ShowProgressBar(1, 1, newGo);

                    properShowNum += 1;
                }
            }

            //显示装备附加属性
            // for (int i = 0; i < equipConfig.AddPropreListType.Length; i++)
            // {
            //     if (equipConfig.AddPropreListIfShow.Length <= i)
            //     {
            //         continue;
            //     }
            //
            //     if (equipConfig.AddPropreListIfShow[i] == 0)
            //     {
            //         int numericType = equipConfig.AddPropreListType[i];
            //         if (numericType == 0)
            //         {
            //             continue;
            //         }
            //
            //         string attribute = "";
            //         long numericValue = equipConfig.AddPropreListValue[i];
            //
            //         for (int y = 0; y < baginfo.XiLianHideProLists.Count; y++)
            //         {
            //             if (equipConfig.AddPropreListType.Length <= y)
            //             {
            //                 break;
            //             }
            //
            //             if (baginfo.XiLianHideProLists[y].HideID == equipConfig.AddPropreListType[i])
            //             {
            //                 numericValue += baginfo.XiLianHideProLists[i].HideValue;
            //             }
            //         }
            //
            //         int showType = NumericHelp.GetNumericValueType(numericType);
            //         if (showType == 2)
            //         {
            //             float value = (float)numericValue / 100f;
            //             attribute = $"{GetAttributeName(numericType)} + " + value.ToString("0.##") + "%";
            //         }
            //         else
            //         {
            //             attribute = $"{GetAttributeName(numericType)} + {numericValue}";
            //         }
            //
            //         ShowPropertyText(attribute, "0", propertyGO, parentGO);
            //         properShowNum += 1;
            //     }
            // }

            //显示附魔属性
            // for (int i = 0; i < baginfo.FumoProLists.Count; i++)
            // {
            //     HideProList hideProList = baginfo.FumoProLists[i];
            //     int showType = NumericHelp.GetNumericValueType(hideProList.HideID);
            //     string attribute;
            //     if (showType == 2)
            //     {
            //         float value = (float)hideProList.HideValue / 100f;
            //         attribute = $"附魔属性: {GetAttributeName(hideProList.HideID)} + " + value.ToString("0.##") + "%";
            //     }
            //     else
            //     {
            //         attribute = $"附魔属性: {GetAttributeName(hideProList.HideID)} + {hideProList.HideValue}";
            //     }
            //
            //     ShowPropertyText(attribute, "1", propertyGO, parentGO);
            //     properShowNum += 1;
            // }

            // 显示增幅属性
            // for (int i = 0; i < baginfo.IncreaseProLists.Count; i++)
            // {
            //     HideProList hide = baginfo.IncreaseProLists[i];
            //     string canTransf = "";
            //     HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(hide.HideID);
            //     string proName = GetAttributeName(hideProListConfig.PropertyType);
            //     int showType = NumericHelp.GetNumericValueType(hideProListConfig.PropertyType);
            //
            //     if (hideProListConfig.IfMove == 1)
            //     {
            //         canTransf = "传承";
            //     }
            //
            //     string attribute;
            //     if (showType == 2)
            //     {
            //         float value = (float)hide.HideValue / 100f;
            //         attribute = $"{canTransf}增幅: {proName} + " + value.ToString("0.##") + "%";
            //     }
            //     else
            //     {
            //         attribute = $"{canTransf}增幅: {proName} + {hide.HideValue}";
            //     }
            //
            //     ShowPropertyText(attribute, "1", propertyGO, parentGO);
            //     properShowNum += 1;
            // }

            // 显示增幅技能
            // for (int i = 0; i < baginfo.IncreaseSkillLists.Count; i++)
            // {
            //     int hide = baginfo.IncreaseSkillLists[i];
            //     string canTransf = "";
            //     HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(hide);
            //     SkillConfig skillConfig = SkillConfigCategory.Instance.Get(hideProListConfig.PropertyType);
            //     string skillName = skillConfig.SkillName;
            //     if (hideProListConfig.IfMove == 1)
            //     {
            //         canTransf = "传承";
            //     }
            //
            //     string attribute = $"{canTransf}增幅: " + skillName;
            //     ShowPropertyText(attribute, "1", propertyGO, parentGO);
            //     properShowNum += 1;
            // }

            // 显示描述
            // if (itemConfig.ItemDes != "" && itemConfig.ItemDes != "0" && itemConfig.ItemDes != null)
            // {
            //     string[] des = itemConfig.ItemDes.Split('\n');
            //     foreach (string s in des)
            //     {
            //         int allLength = s.Length;
            //         int addNum = Mathf.CeilToInt(allLength / 18f);
            //         for (int a = 0; a < addNum; a++)
            //         {
            //             int leftNum = allLength - a * 18;
            //             leftNum = Math.Min(leftNum, 18);
            //             ShowPropertyText(s.Substring(a * 18, leftNum), "1", propertyGO, parentGO);
            //         }
            //
            //         properShowNum += addNum;
            //     }
            // }

            //显示传承技能
            // string showYanSe = "2";
            // if (baginfo.InheritSkills != null)
            // {
            //     for (int i = 0; i < baginfo.InheritSkills.Count; i++)
            //     {
            //         int skillID = baginfo.InheritSkills[i];
            //         if (skillID != 0)
            //         {
            //             SkillConfig skillCof = SkillConfigCategory.Instance.Get(skillID);
            //             string proStr = LanguageComponent.Instance.LoadLocalization("传承鉴定") + ":" + skillCof.SkillDescribe;
            //
            //             //获取当前穿戴的装备是否有相同的传承属性
            //             bool ifRepeat = false;
            //
            //             for (int y = 0; y < equipItemList.Count; y++)
            //             {
            //                 //Debug.Log("equipItemList.Count = " + equipItemList.Count);
            //                 List<int> inheritSkills = equipItemList[i].InheritSkills;
            //                 Debug.Log("inheritSkills.Count = " + inheritSkills.Count);
            //
            //                 for (int z = 0; z < inheritSkills.Count; z++)
            //                 {
            //                     if (inheritSkills[z] == skillID && equipItemList[y].BagInfoID != baginfo.BagInfoID)
            //                     {
            //                         proStr += "\n(同类传承属性只激活一种)";
            //                         ifRepeat = true;
            //                         showYanSe = "11";
            //                         break;
            //                     }
            //                 }
            //             }
            //
            //             //////防止循环多次
            //             if (ifRepeat)
            //             {
            //                 break;
            //             }
            //
            //             //ShowPropertyText(proStr, "2", Obj_EquipPropertyText, Obj_EquipBaseSetList);
            //
            //             int allLength = proStr.Length;
            //             int addNum = Mathf.CeilToInt(allLength / 18f);
            //             if (ifRepeat && allLength <= 18)
            //             {
            //                 addNum += 1;
            //             }
            //
            //             for (int a = 0; a < addNum; a++)
            //             {
            //                 int leftNum = allLength - a * 18;
            //                 leftNum = Math.Min(leftNum, 18);
            //                 ShowPropertyText(proStr.Substring(a * 18, leftNum), showYanSe, propertyGO, parentGO);
            //                 properShowNum += 1;
            //             }
            //         }
            //     }
            // }

            return properShowNum;
        }

        public static GameObject ShowPropertyText_2(this ES_RoleXiLianShow self, int showIcon, string showText, string showType, GameObject proItem, GameObject parObj, int change = 0)
        {
            GameObject go = UnityEngine.Object.Instantiate(proItem, parObj.transform, true);
            go.transform.localScale = new Vector3(1, 1, 1);

            go.transform.Find("Image_BasePro").gameObject.SetActive(showIcon == 0);
            go.transform.Find("Image_ExtraPro").gameObject.SetActive(showIcon == 1);
            go.transform.Find("Image_Skill").gameObject.SetActive(showIcon == 2);
            
            Text textComponent = go.GetComponent<Text>();
            if (textComponent == null)
            {
                textComponent = go.GetComponentInChildren<Text>();
            }

            textComponent.text = showText;
            go.transform.localPosition = new Vector3(0, 0, 0);
            go.SetActive(true);

            switch (showType)
            {
                //极品提示  绿色
                case "1":
                    textComponent.color = new Color(169f / 255f, 255f / 255f, 30 / 255f);
                    break;
                //隐藏技能  橙色
                case "2":
                    textComponent.color = new Color(248 / 255f, 62f / 255, 191f / 255f);
                    break;
                //红色
                case "3":
                    textComponent.color = Color.red;
                    break;
                //蓝色
                case "4":
                    textComponent.color = new Color(1f, 0.5f, 1f);
                    break;
                //白色
                case "5":
                    textComponent.color = new Color(100f / 255f, 80f / 255f, 60f / 255f);
                    break;
                //橙色
                case "6":
                    textComponent.color = new Color(255f / 255f, 90f / 255f, 0f);
                    break;
                //灰色
                case "11":
                    textComponent.color = new Color(0.66f, 0.66f, 0.66f);
                    break;
            }

            go.transform.Find("Image_Down").gameObject.SetActive(change < 0);
            go.transform.Find("Image_Up").gameObject.SetActive(change > 0);

            return go;
        }

        public static void ShowProgressBar(this ES_RoleXiLianShow self, float now, float max, GameObject proItem)
        {
            float fillAmount = Mathf.Clamp(now / max, 0f, 1f);
            proItem.transform.Find("E_ImageExpValue").GetComponent<Image>().fillAmount = fillAmount;

            RectTransform imageExpRight = proItem.transform.Find("E_ImageExpValue/ImageExpRight").GetComponent<RectTransform>();
            imageExpRight.gameObject.SetActive(fillAmount > 0.05f);
            Vector2 highlightPos = imageExpRight.localPosition;
            highlightPos.x = proItem.transform.Find("E_ImageExpValue").GetComponent<RectTransform>().sizeDelta.x * fillAmount - 0f;
            imageExpRight.localPosition = highlightPos;
        }

        private static void OnUpdateXinLian(this ES_RoleXiLianShow self)
        {
            ItemInfo bagInfo = self.XilianBagInfo;
            self.EG_XiLianInfoRectTransform.gameObject.SetActive(bagInfo != null);
            if (bagInfo == null)
            {
                return;
            }

            self.UpdateAttribute(bagInfo);
            
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);

            self.E_XuanZhonItemItemIconImage.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon));

            self.E_XuanZhonItemItemQualityImage.sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(
                ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemQualityIcon, FunctionUI.ItemQualiytoPath(itemConfig.ItemQuality)));

            self.E_XuanZhonItemNameText.text = itemConfig.ItemName;
            self.E_XuanZhonItemNameText.color = FunctionUI.QualityReturnColorDi(itemConfig.ItemQuality);

            self.UpdateCombat();

            //洗炼消耗
            int[] itemCost = itemConfig.XiLianStone;
            if (itemCost == null || itemCost.Length < 2)
            {
                return;
            }

            self.E_CostItemIconImage.sprite =
                    resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemCost[0].ToString()));

            using (zstring.Block())
            {
                self.E_Text_CostValueText.text = zstring.Format("x {0}", itemCost[1]);
            }
        }

        private static void UpdateCombat(this ES_RoleXiLianShow self)
        {
            long combatChange = self.EquipCombatChangeDic[self.XilianBagInfo.BagInfoID].Item2;
            
            using (zstring.Block())
            {
                self.E_BatAddText.text = zstring.Format("预计战力增长：{0}", combatChange);
            }

            self.E_CombatUpImage.gameObject.SetActive(combatChange > 0);
            self.E_CombatDownImage.gameObject.SetActive(combatChange < 0);
        }

        private static async ETTask OnXiLianButton(this ES_RoleXiLianShow self, int times)
        {
            if (self.XilianBagInfo == null)
            {
                return;
            }

            ItemInfo itemInfo = self.XilianBagInfo;
            if (times == 1)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemInfo.ItemID);
                List<RewardItem> costItems = new List<RewardItem>();
                int[] itemCost = itemConfig.XiLianStone;
                if (itemCost != null && itemCost.Length >= 2)
                {
                    costItems.Add(new RewardItem() { ItemID = itemCost[0], ItemNum = itemCost[1] * times });
                }

                if (!self.Root().GetComponent<BagComponentC>().CheckNeedItem(costItems))
                {
                    FlyTipComponent.Instance.ShowFlyTip("材料不足！");
                    return;
                }
            }

            if (times > 1)
            {
                int needDimanond = int.Parse(GlobalValueConfigCategory.Instance.Get(73).Value.Split('@')[0]);
                int itemXiLianNumber = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>()
                        .GetAsInt(NumericType.ItemXiLianNumber);
                string[] set = GlobalValueConfigCategory.Instance.Get(116).Value.Split(';');
                float discount;
                if (itemXiLianNumber < int.Parse(set[0]))
                {
                    discount = 1;
                }
                else
                {
                    discount = float.Parse(set[1]);
                }

                if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.Diamond < (int)(needDimanond * discount))
                {
                    HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_DiamondNotEnoughError);
                    return;
                }
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int oldXiLianDu = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.ItemXiLianDu);
            
            M2C_ItemXiLianResponse response = await BagClientNetHelper.RquestItemXiLian(self.Root(), itemInfo.BagInfoID, times);
            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            if (times == 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("洗练道具成功");
                self.UpdateEquipCombatChange(itemInfo, response.ItemXiLianResults[0].ChangeCombat);
                self.OnXiLianReturn();
                self.ShowXiLianEffect().Coroutine();
            }

            if (times > 1)
            {
                int newXiLianDu = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.ItemXiLianDu);
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("获得{0}洗练经验", newXiLianDu - oldXiLianDu));
                }

                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_RoleXiLianTen);
                DlgRoleXiLianTen dlgRoleXiLianTen = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRoleXiLianTen>();
                dlgRoleXiLianTen.OnInitUI(itemInfo, response.ItemXiLianResults);
                self.OnXiLianReturn();
            }

            //记录tap数据
            //             PlayerComponent playerComponent = self.Root().GetComponent<PlayerComponent>();
            //             string serverName = playerComponent.ServerName;
            //             UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            // #if UNITY_ANDROID
            //             TapSDKHelper.UpLoadPlayEvent(userInfo.Name, serverName, userInfo.Lv, 2, times);
            // #endif
        }

        private static void ResetEquipCombatChange(this ES_RoleXiLianShow self, ItemInfo bagInfo)
        {
            if (bagInfo == null)
            {
                return;
            }
            
            if (!self.EquipCombatChangeDic.ContainsKey(bagInfo.BagInfoID))
            {
                self.EquipCombatChangeDic.Add(bagInfo.BagInfoID, (bagInfo, 0));
            }
            else
            {
                (ItemInfo, long) info = self.EquipCombatChangeDic[bagInfo.BagInfoID];
                self.EquipCombatChangeDic[bagInfo.BagInfoID] = (info.Item1, 0);
                
                // self.EquipCombatChangeDic.Add(bagInfo.BagInfoID, (bagInfo, 0));// 属性变化也重置
            }
        }
        
        public static void UpdateEquipCombatChange(this ES_RoleXiLianShow self, ItemInfo oldItemInfo, long changeCombat)
        {
            // CommonHelp.DeepCopy<ItemInfo>(itemInfo)
            self.EquipCombatChangeDic[oldItemInfo.BagInfoID] = (oldItemInfo, changeCombat);
        }
        
        public static void OnXiLianReturn(this ES_RoleXiLianShow self)
        {
            self.XilianBagInfo = self.Root().GetComponent<BagComponentC>().GetBagInfo(self.BagInfoID);
            self.OnUpdateXinLian();
            self.OnItemTypeSet(self.CurrentItemType);
        }

        private static async ETTask ShowXiLianEffect(this ES_RoleXiLianShow self)
        {
            self.ETCancellationToken?.Cancel();
            self.ETCancellationToken = null;
            self.ETCancellationToken = new ETCancellationToken();
            long instance = self.InstanceId;
            self.EG_XiLianEffectRectTransform.gameObject.SetActive(false);
            self.EG_XiLianEffectRectTransform.gameObject.SetActive(true);
            await self.Root().GetComponent<TimerComponent>().WaitAsync(2000, self.ETCancellationToken);
            if (instance != self.InstanceId)
            {
                return;
            }

            self.EG_XiLianEffectRectTransform.gameObject.SetActive(false);
        }
    }
}
