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

            self.EG_XuanZhonItemRectTransform.gameObject.SetActive(false);
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
                            scrollItemCommonItem.ES_CommonItem.OnClickUIItem();
                        }
                    }

                    break;
            }

            self.CurrentItemType = index;
        }

        public static void OnUpdateUI(this ES_RoleXiLianShow self)
        {
            self.XilianBagInfo = null;
            self.OnItemTypeSet(0);
        }

        private static void OnBagItemsRefresh(this ES_RoleXiLianShow self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.ItemXiLian, self.OnSelectBagItem);
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

                    item.UpdateSelectStatus(bagInfo);
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
            self.EG_XuanZhonItemRectTransform.gameObject.SetActive(bagInfo != null);
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
                self.E_Text_CostValueText.text = zstring.Format("x {1}", itemCost[1]);
            }
        }

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