using System;
using System.Collections.Generic;
using UnityEngine;

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

                    if (self.XilianBagInfo != null)
                    {
                        self.OnSelectBagItem(self.XilianBagInfo);
                    }
                    else if (self.ShowBagInfos.Count > 0)
                    {
                        Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[0];
                        if (scrollItemCommonItem.uiTransform != null)
                        {
                            scrollItemCommonItem.OnClickUIItem();
                        }
                    }

                    break;
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
            self.OnSelectBagItem(self.XilianBagInfo);
        }

        private static void OnSelectBagItem(this ES_RoleXiLianShow self, ItemInfo bagInfo)
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

                    item.SetSelected(bagInfo);
                }
            }

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
            ItemViewHelp.ShowXiLianAttribute(bagComponent.GetEquipList(), bagInfo, prefab,
                self.E_XiLianShowEquipPropertyItemsScrollRect.transform.Find("Content").gameObject);
        }

        private static void OnUpdateXinLian(this ES_RoleXiLianShow self)
        {
            ItemInfo bagInfo = self.XilianBagInfo;
            self.EG_XiLianInfoRectTransform.gameObject.SetActive(bagInfo != null);
            self.UpdateAttribute(bagInfo);
            if (bagInfo == null)
            {
                return;
            }

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

        # region 计算装备大概的战力

        private static void UpdateCombat(this ES_RoleXiLianShow self)
        {
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(self.XilianBagInfo.ItemID);

            int zhanliValue = 0;

            Dictionary<int, long> UpdateProDicList = new Dictionary<int, long>();

            int equipHpSum = 0;
            int equipMinActSum = 0;
            int equipMaxActSum = 0;
            int equipMinMageSum = 0;
            int equipMaxMageSum = 0;
            int equipMinDefSum = 0;
            int equipMaxDefSum = 0;
            int equipMinAdfSum = 0;
            int equipMaxAdfSum = 0;

            bool ifAddHidePro = true;
            int occTwoValue = self.Root().GetComponent<UserInfoComponentC>().UserInfo.OccTwo;
            if (occTwoValue != 0)
            {
                if (itemCof.EquipType == 11 || itemCof.EquipType == 12 ||
                    itemCof.EquipType == 13 && self.XilianBagInfo.Loc == (int)ItemLocType.ItemLocEquip)
                {
                    int selfMastery = OccupationTwoConfigCategory.Instance.Get(occTwoValue).ArmorMastery;
                    if (selfMastery != itemCof.EquipType)
                    {
                        //护甲不匹配不添加专精数据
                        ifAddHidePro = false;
                    }
                }
            }

            if (ifAddHidePro)
            {
                //存储装备精炼数值
                if (self.XilianBagInfo.HideProLists != null)
                {
                    for (int y = 0; y < self.XilianBagInfo.HideProLists.Count; y++)
                    {
                        HideProList hidePro = self.XilianBagInfo.HideProLists[y];
                        AddUpdateProDicList(hidePro.HideID, hidePro.HideValue, UpdateProDicList);
                    }
                }
            }

            //存储洗炼数值
            if (self.XilianBagInfo.XiLianHideProLists != null)
            {
                for (int y = 0; y < self.XilianBagInfo.XiLianHideProLists.Count; y++)
                {
                    HideProList hidePro = self.XilianBagInfo.XiLianHideProLists[y];
                    AddUpdateProDicList(hidePro.HideID, hidePro.HideValue, UpdateProDicList);
                }
            }

            //存储洗炼数值
            if (self.XilianBagInfo.XiLianHideTeShuProLists != null)
            {
                for (int y = 0; y < self.XilianBagInfo.XiLianHideTeShuProLists.Count; y++)
                {
                    HideProList hidePro = self.XilianBagInfo.XiLianHideTeShuProLists[y];
                    HideProListConfig hideproCof = HideProListConfigCategory.Instance.Get(hidePro.HideID);
                    AddUpdateProDicList(hideproCof.PropertyType, hidePro.HideValue, UpdateProDicList);
                }
            }

            //存储附魔属性
            if (self.XilianBagInfo.FumoProLists != null)
            {
                for (int y = 0; y < self.XilianBagInfo.FumoProLists.Count; y++)
                {
                    HideProList hidePro = self.XilianBagInfo.FumoProLists[y];
                    AddUpdateProDicList(hidePro.HideID, hidePro.HideValue, UpdateProDicList);
                }
            }

            // 存储增幅属性
            if (self.XilianBagInfo.IncreaseProLists != null && self.XilianBagInfo.IncreaseProLists.Count > 0)
            {
                for (int j = 0; j < self.XilianBagInfo.IncreaseProLists.Count; j++)
                {
                    HideProList hideProList = self.XilianBagInfo.IncreaseProLists[j];
                    HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(hideProList.HideID);
                    AddUpdateProDicList(hideProListConfig.PropertyType, hideProList.HideValue, UpdateProDicList);
                }
            }

            //.InheritSkills //传承技能
            // 存储增幅技能属性
            if (self.XilianBagInfo.IncreaseSkillLists != null && self.XilianBagInfo.IncreaseSkillLists.Count > 0)
            {
                for (int s = 0; s < self.XilianBagInfo.IncreaseSkillLists.Count; s++)
                {
                    HideProListConfig hideProListConfig = HideProListConfigCategory.Instance.Get(self.XilianBagInfo.IncreaseSkillLists[s]);
                    SkillConfig skillConfig = SkillConfigCategory.Instance.Get(hideProListConfig.PropertyType);

                    if (skillConfig.SkillType != (int)SkillTypeEnum.PassiveAddProSkill)
                    {
                        continue;
                    }

                    string GameObjectParameter = skillConfig.GameObjectParameter;
                    if (CommonHelp.IfNull(GameObjectParameter))
                    {
                        continue;
                    }

                    string[] addProList = GameObjectParameter.Split(";");
                    for (int p = 0; p < addProList.Length; p++)
                    {
                        string[] addProStr = addProList[p].Split(",");
                        if (addProStr.Length < 2)
                        {
                            break;
                        }

                        int key = int.Parse(addProStr[0]);
                        try
                        {
                            if (NumericHelp.GetNumericValueType(key) == 1)
                            {
                                AddUpdateProDicList(key, long.Parse(addProStr[1]), UpdateProDicList);
                            }
                            else
                            {
                                AddUpdateProDicList(key, (int)(float.Parse(addProStr[1]) * 10000), UpdateProDicList);
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Error($"{ex.ToString()} {GameObjectParameter}");
                        }
                    }
                }
            }

            //史诗宝石数量
            int equipShiShiGemNum = 0;
            List<int> ShiShiGemID = new List<int>();

            EquipConfig mEquipCon = EquipConfigCategory.Instance.Get(itemCof.ItemEquipID);

            //职业专精
            float occMastery = 0f;

            //极品属性
            float addPro = 0;

            if (self.XilianBagInfo.HideSkillLists.Contains(68000104) || self.XilianBagInfo.IncreaseSkillLists.Contains(3903))
            {
                addPro = 0.2f;
            }

            //虚弱属性
            if (self.XilianBagInfo.HideSkillLists.Contains(68000107))
            {
                addPro = -0.1f;
            }

            //胜算属性
            if (self.XilianBagInfo.HideSkillLists.Contains(68000105) || self.XilianBagInfo.IncreaseSkillLists.Contains(3904))
            {
                mEquipCon.Equip_MinAct = mEquipCon.Equip_MaxAct;
            }

            EquipQiangHuaConfig equipQiangHuaConfig = null; /// QiangHuaHelper.GetQiangHuaConfig(itemCof.ItemSubType, qianghuaLv);
            if (equipQiangHuaConfig != null)
            {
                addPro += float.Parse(equipQiangHuaConfig.EquipPropreAdd);
                //addPro += float.Parse(EquipQiangHuaConfigCategory.Instance.Get(QiangHuaHelper.GetQiangHuaId(itemCof.ItemSubType, qianghuaLv[itemCof.ItemSubType])).EquipPropreAdd);
            }

            //存储基础属性
            equipHpSum = (int)(equipHpSum + mEquipCon.Equip_Hp * (1 + occMastery + addPro));
            equipMinActSum = (int)(equipMinActSum + mEquipCon.Equip_MinAct * (1 + occMastery + addPro));
            equipMaxActSum = (int)(equipMaxActSum + mEquipCon.Equip_MaxAct * (1 + occMastery + addPro));
            equipMinMageSum = (int)(equipMinMageSum + mEquipCon.Equip_MinMagAct * (1 + occMastery + addPro));
            equipMaxMageSum = (int)(equipMaxMageSum + mEquipCon.Equip_MaxMagAct * (1 + occMastery + addPro));
            equipMinDefSum = (int)(equipMinDefSum + mEquipCon.Equip_MinDef * (1 + occMastery + addPro));
            equipMaxDefSum = (int)(equipMaxDefSum + mEquipCon.Equip_MaxDef * (1 + occMastery + addPro));
            equipMinAdfSum = (int)(equipMinAdfSum + mEquipCon.Equip_MinAdf * (1 + occMastery + addPro));
            equipMaxAdfSum = (int)(equipMaxAdfSum + mEquipCon.Equip_MaxAdf * (1 + occMastery + addPro));

            //存储特殊属性
            for (int y = 0; y < mEquipCon.AddPropreListType.Length; y++)
            {
                if (mEquipCon.AddPropreListType[y] != 0 && mEquipCon.AddPropreListValue.Length > y)
                {
                    //记录属性
                    AddUpdateProDicList(mEquipCon.AddPropreListType[y], (long)mEquipCon.AddPropreListValue[y], UpdateProDicList);
                }
            }

            //获取宝石属性
            if (string.IsNullOrEmpty(self.XilianBagInfo.GemIDNew))
            {
                self.XilianBagInfo.GemIDNew = ConfigData.DefaultGem;
            }

            string[] gemList = self.XilianBagInfo.GemIDNew.Split('_');

            for (int z = 0; z < gemList.Length; z++)
            {
                int gemID = int.Parse(gemList[z]);
                if (gemID == 0)
                {
                    continue;
                }

                //史诗宝石数量最多4个
                ItemConfig itemGemCof = ItemConfigCategory.Instance.Get(gemID);
                if (itemGemCof.ItemSubType == 110)
                {
                    if (ShiShiGemID.Contains(itemGemCof.Id))
                    {
                        //重复宝石直接跳出
                        continue;
                    }
                    else
                    {
                        equipShiShiGemNum += 1;
                        ShiShiGemID.Add(itemGemCof.Id);
                    }
                }

                if (equipShiShiGemNum > 4 && itemGemCof.ItemSubType == 110)
                {
                    continue;
                }

                // "100403;10@100203;60
                ItemConfig gemitemCof = ItemConfigCategory.Instance.Get(gemID);
                string[] attributeList = gemitemCof.ItemUsePar.Split('@');
                for (int a = 0; a < attributeList.Length; a++)
                {
                    //100203;113
                    string attributeItem = attributeList[a];
                    string[] attributeInfo = attributeItem.Split(';');
                    int gemPro = 0;
                    try
                    {
                        gemPro = int.Parse(attributeInfo[0]);
                    }
                    catch (Exception ex)
                    {
                        Log.Debug("attri: " + ex.ToString());
                        continue;
                    }

                    long gemValue = long.Parse(attributeInfo[1]);

                    //浮点数处理
                    if (NumericHelp.GetNumericValueType(gemPro) == 2)
                    {
                        //gemValue = gemValue * 10000;
                    }

                    //宝石专精
                    if (self.XilianBagInfo.HideSkillLists.Contains(68000108) || self.XilianBagInfo.IncreaseSkillLists.Contains(2108) ||
                        self.XilianBagInfo.IncreaseSkillLists.Contains(3902))
                    {
                        gemValue = (long)((float)gemValue * 1.2f);
                    }

                    AddUpdateProDicList(gemPro, gemValue, UpdateProDicList);
                }
            }

            //汇总属性
            long BaseHp = equipHpSum;
            long BaseMinAct = equipMinActSum;
            long BaseMaxAct = equipMaxActSum;
            long BaseMinMage = equipMinMageSum;
            long BaseMaxMage = equipMaxMageSum;
            long BaseMinDef = equipMinDefSum;
            long BaseMaxDef = equipMaxDefSum;
            long BaseMinAdf = equipMinAdfSum;
            long BaseMaxAdf = equipMaxAdfSum;
            

            //更新基础属性
            AddUpdateProDicList(NumericType.Base_MaxHp_Base, BaseHp, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_MinAct_Base, BaseMinAct, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_MaxAct_Base, BaseMaxAct, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_Mage_Base, BaseMaxMage, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_MinDef_Base, BaseMinDef, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_MaxDef_Base, BaseMaxDef, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_MinAdf_Base, BaseMinAdf, UpdateProDicList);
            AddUpdateProDicList(NumericType.Base_MaxAdf_Base, BaseMaxAdf, UpdateProDicList);

            long Power_value = GetOnePro(NumericType.Now_Power, UpdateProDicList);
            long Agility_value = GetOnePro(NumericType.Now_Agility, UpdateProDicList);
            long Intellect_value = GetOnePro(NumericType.Now_Intellect, UpdateProDicList);
            long Stamina_value = GetOnePro(NumericType.Now_Stamina, UpdateProDicList);
            long Constitution_value = GetOnePro(NumericType.Now_Constitution, UpdateProDicList);

            //战力计算
            long ShiLi_Act = 0;
            float ShiLi_ActPro = 0f;
            long ShiLi_Def = 0;
            float ShiLi_DefPro = 0f;
            long ShiLi_Hp = 0;
            float ShiLi_HpPro = 0f;
            //long proLvAdd = criLv + hitLv + dodgeLv + resLv + skillAddLv;
            long proLvAdd = 0;

            //传承鉴定特殊属性加成
            int chuanchengProAdd = 0;
            if (self.XilianBagInfo.InheritSkills.Count >= 1)
            {
                chuanchengProAdd += 500;
            }

            //攻击部分
            foreach (var Item in NumericData.ZhanLi_Act)
            {
                ShiLi_Act += (int)((float)ReturnGetFightNumLong(Item.Key, UpdateProDicList) * Item.Value);
            }

            //隐藏技能战力
            int skillFightValue = 0;

            for (int z = 0; z < self.XilianBagInfo.HideSkillLists.Count; z++)
            {
                Dictionary<int, HideProListConfig> hideCof = new Dictionary<int, HideProListConfig>();
                hideCof = HideProListConfigCategory.Instance.GetAll();

                foreach (HideProListConfig hideProConfig in hideCof.Values)
                {
                    if (hideProConfig.PropertyType == self.XilianBagInfo.HideSkillLists[z])
                    {
                        skillFightValue += hideProConfig.AddFightValue;
                    }
                }
            }

            //隐藏技能算在攻击部分
            ShiLi_Act += skillFightValue;

            foreach (var Item in NumericData.ZhanLi_ActPro)
            {
                ShiLi_ActPro += ((float)ReturnGetFightNumfloat(Item.Key, UpdateProDicList) * Item.Value);
            }

            //幸运副本附加
            long luck = 0;
            UpdateProDicList.TryGetValue(NumericType.Now_Luck, out luck);
            switch (luck)
            {
                case 0:
                    ShiLi_ActPro += 0.01f;
                    break;
                case 1:
                    ShiLi_ActPro += 0.02f;
                    break;
                case 2:
                    ShiLi_ActPro += 0.04f;
                    break;
                case 3:
                    ShiLi_ActPro += 0.08f;
                    break;
                case 4:
                    ShiLi_ActPro += 0.12f;
                    break;
                case 5:
                    ShiLi_ActPro += 0.2f;
                    break;
                case 6:
                    ShiLi_ActPro += 0.3f;
                    break;
                case 7:
                    ShiLi_ActPro += 0.4f;
                    break;
                case 8:
                    ShiLi_ActPro += 0.5f;
                    break;
                case 9:
                    ShiLi_ActPro += 0.9f;
                    break;

                default:
                    ShiLi_ActPro += 1f;
                    break;
            }

            //防御部分
            foreach (var Item in NumericData.ZhanLi_Def)
            {
                ShiLi_Def += (int)((float)ReturnGetFightNumLong(Item.Key, UpdateProDicList) * Item.Value);
            }

            foreach (var Item in NumericData.ZhanLi_DefPro)
            {
                ShiLi_DefPro += ((float)ReturnGetFightNumfloat(Item.Key, UpdateProDicList) * Item.Value);
            }

            //血量部分
            foreach (var Item in NumericData.ZhanLi_Hp)
            {
                ShiLi_Hp += (int)((float)ReturnGetFightNumLong(Item.Key, UpdateProDicList) * Item.Value);
            }

            foreach (var Item in NumericData.ZhanLi_HpPro)
            {
                ShiLi_HpPro += ((float)ReturnGetFightNumfloat(Item.Key, UpdateProDicList) * Item.Value);
            }

            zhanliValue = (int)(ShiLi_Act * (1 + ShiLi_ActPro) + ShiLi_Def * (1 + ShiLi_DefPro) + (ShiLi_Hp * 0.1f) * (1 + ShiLi_HpPro)) +
                    (int)proLvAdd + chuanchengProAdd;

            long oneProSum = Stamina_value + Intellect_value + Agility_value + Power_value + Constitution_value;
            int addZhanliValue = (int)(zhanliValue * (oneProSum / 30000f));
            if (addZhanliValue > 0)
            {
                zhanliValue = zhanliValue + addZhanliValue;
            }

            using (zstring.Block())
            {
                self.E_BatAddText.text = zstring.Format("预计战力增长：{0}", zhanliValue);
            }
        }

        private static void AddUpdateProDicList(int typeID, long typeValue, Dictionary<int, long> dic)
        {
            //缓存属性
            if (dic.ContainsKey(typeID))
            {
                dic[typeID] += typeValue;
            }
            else
            {
                dic[typeID] = typeValue;
            }
        }

        private static int GetOnePro(int typeID, Dictionary<int, long> dic)
        {
            if (ifNumTypeOnePro(typeID))
            {
                //缓存属性
                int baseType = typeID * 100 + 1;
                int mulType = typeID * 100 + 2;
                int addType = typeID * 100 + 3;
                long baseValue = 0;
                float mulValue = 0;
                long addValue = 0;
                if (dic.ContainsKey(baseType))
                {
                    baseValue = dic[baseType];
                }

                if (dic.ContainsKey(mulType))
                {
                    mulValue = (float)dic[mulType] / 10000f;
                }

                if (dic.ContainsKey(addType))
                {
                    addValue = dic[addType];
                }

                return (int)(baseValue * (1 + mulValue) + addValue);
            }

            return 0;
        }

        //是否是一级属性
        private static bool ifNumTypeOnePro(int numericType)
        {
            if (numericType < (int)NumericType.Max)
            {
                numericType = numericType * 100;
            }

            int nowValue = (int)numericType / 100;
            if (nowValue == NumericType.Now_Power || nowValue == NumericType.Now_Agility || nowValue == NumericType.Now_Intellect ||
                nowValue == NumericType.Now_Stamina || nowValue == NumericType.Now_Constitution)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static long ReturnGetFightNumLong(int numericType, Dictionary<int, long> dic)
        {
            if (numericType < NumericType.Max)
            {
                numericType = numericType * 100;
            }

            int nowValue = numericType / 100;
            int add = nowValue * 100 + 1;
            int mul = nowValue * 100 + 2;
            int finalAdd = nowValue * 100 + 3;

            long addValue = 0;
            dic.TryGetValue(add, out addValue);
            long mulValue = 0;
            dic.TryGetValue(mul, out mulValue);
            long finalAddValue = 0;
            dic.TryGetValue(finalAdd, out finalAddValue);

            long nowPropertyValue = (long)(addValue * (1 + (float)mulValue / 10000) + finalAddValue);

            return nowPropertyValue;
        }

        private static float ReturnGetFightNumfloat(int numericType, Dictionary<int, long> dic)
        {
            if (numericType < NumericType.Max)
            {
                numericType = numericType * 100;
            }

            int nowValue = numericType / 100;
            int add = nowValue * 100 + 1;
            int mul = nowValue * 100 + 2;
            int finalAdd = nowValue * 100 + 3;

            long addValue = 0;
            dic.TryGetValue(add, out addValue);
            long mulValue = 0;
            dic.TryGetValue(mul, out mulValue);
            long finalAddValue = 0;
            dic.TryGetValue(finalAdd, out finalAddValue);

            long nowPropertyValue = (long)(addValue * (1 + (float)mulValue / 10000) + finalAddValue);

            return nowPropertyValue / 10000f;
        }

        # endregion

        private static async ETTask OnXiLianButton(this ES_RoleXiLianShow self, int times)
        {
            if (self.XilianBagInfo == null)
            {
                return;
            }

            ItemInfo bagInfo = self.XilianBagInfo;
            if (times == 1)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
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

            M2C_ItemXiLianResponse response = await BagClientNetHelper.RquestItemXiLian(self.Root(), bagInfo.BagInfoID, times);
            if (response.Error != 0)
            {
                return;
            }

            if (times == 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("洗炼道具成功");
                self.OnXiLianReturn();
                self.ShowXiLianEffect().Coroutine();
            }

            if (times > 1)
            {
                int newXiLianDu = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.ItemXiLianDu);
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("获得{0}洗炼经验", newXiLianDu - oldXiLianDu));
                }

                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_RoleXiLianTen);
                DlgRoleXiLianTen dlgRoleXiLianTen = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRoleXiLianTen>();
                dlgRoleXiLianTen.OnInitUI(bagInfo, response.ItemXiLianResults);
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