using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PaiMaiBuyItem))]
    [FriendOf(typeof (UITypeViewComponent))]
    [FriendOf(typeof (UITypeButtonComponent))]
    [EntitySystemOf(typeof (ES_PaiMaiBuy))]
    [FriendOfAttribute(typeof (ES_PaiMaiBuy))]
    public static partial class ES_PaiMaiBuySystem
    {
        [EntitySystem]
        private static void Awake(this ES_PaiMaiBuy self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_SearchButton.AddListenerAsync(self.OnBtn_SearchButton);
            self.E_NextPageBtnButton.AddListener(self.OnNextPageBtnButton);
            self.E_PrePageBtnButton.AddListener(self.OnPrePageBtnButton);

            self.E_PaiMaiBuyItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnPaiMaiBuyItemsRefresh);

            self.UITypeViewComponent = self.AddChild<UITypeViewComponent, GameObject>(self.EG_TypeListNodeRectTransform.gameObject);
            self.UITypeViewComponent.TypeButtonItemAsset = ABPathHelper.GetUGUIPath("Common/UITypeItem");
            self.UITypeViewComponent.TypeButtonAsset = ABPathHelper.GetUGUIPath("Common/UITypeButton");
            self.UITypeViewComponent.ClickTypeItemHandler = (itemType, itemSubType) => { self.OnClickTypeItem(itemType, itemSubType).Coroutine(); };

            self.UITypeViewComponent.TypeButtonInfos = self.InitTypeButtonInfos();
            self.UITypeViewComponent.OnInitUI().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_PaiMaiBuy self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnClickGoToPaiMai(this ES_PaiMaiBuy self, int itemType, long paimaiItemId)
        {
            if (itemType != 1)
            {
                foreach (var value in self.UITypeViewComponent.TypeButtonComponents)
                {
                    if (value.TypeId == itemType)
                    {
                        value.OnClickTypeButton();
                        break;
                    }
                }
            }

            long instanceid = self.InstanceId;

            P2C_PaiMaiFindResponse response = await PaiMaiNetHelper.PaiMaiFind(self.Root(), itemType, paimaiItemId);
            if (response.Page == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("道具已经被买走了!");
                return;
            }

            if (self.InstanceId != instanceid)
            {
                return;
            }

            await self.OnClickTypeItem(itemType, 0, response.Page);

            await self.Root().GetComponent<TimerComponent>().WaitAsync(500);
            if (self.InstanceId != instanceid)
            {
                return;
            }

            for (int i = 0; i < self.PaiMaiIteminfos_Now.Count; i++)
            {
                if (self.PaiMaiIteminfos_Now[i].Id == paimaiItemId)
                {
                    self.E_PaiMaiBuyItemsLoopVerticalScrollRect.transform.Find("Content").localPosition = new Vector3(0, i * 124f, 0);
                    break;
                }
            }
        }

        public static List<TypeButtonInfo> InitTypeButtonInfos(this ES_PaiMaiBuy self)
        {
            TypeButtonInfo typeButtonInfo = new();
            List<TypeButtonInfo> typeButtonInfos = new List<TypeButtonInfo>();
            typeButtonInfo = new TypeButtonInfo();
            foreach (int key in ItemViewData.ItemSubType1Name.Keys)
            {
                typeButtonInfo.typeButtonItems.Add(new TypeButtonItem() { SubTypeId = key, ItemName = ItemViewData.ItemSubType1Name[key] });
            }

            typeButtonInfo.TypeId = 1;
            typeButtonInfo.TypeName = ItemViewData.ItemTypeName[ItemTypeEnum.Consume];
            typeButtonInfos.Add(typeButtonInfo);

            typeButtonInfo = new TypeButtonInfo();
            foreach (int key in ItemViewData.ItemSubType2Name.Keys)
            {
                typeButtonInfo.typeButtonItems.Add(new TypeButtonItem() { SubTypeId = key, ItemName = ItemViewData.ItemSubType2Name[key] });
            }

            typeButtonInfo.TypeId = 2;
            typeButtonInfo.TypeName = ItemViewData.ItemTypeName[ItemTypeEnum.Material];
            typeButtonInfos.Add(typeButtonInfo);

            typeButtonInfo = new TypeButtonInfo();
            foreach (int key in ItemViewData.ItemSubType3Name.Keys)
            {
                typeButtonInfo.typeButtonItems.Add(new TypeButtonItem() { SubTypeId = key, ItemName = ItemViewData.ItemSubType3Name[key] });
            }

            typeButtonInfo.TypeId = 3;
            typeButtonInfo.TypeName = ItemViewData.ItemTypeName[ItemTypeEnum.Equipment];
            typeButtonInfos.Add(typeButtonInfo);

            typeButtonInfo = new TypeButtonInfo();
            foreach (int key in ItemViewData.ItemSubType4Name.Keys)
            {
                typeButtonInfo.typeButtonItems.Add(new TypeButtonItem() { SubTypeId = key, ItemName = ItemViewData.ItemSubType4Name[key] });
            }

            typeButtonInfo.TypeId = 4;
            typeButtonInfo.TypeName = ItemViewData.ItemTypeName[ItemTypeEnum.Gemstone];
            typeButtonInfos.Add(typeButtonInfo);

            return typeButtonInfos;
        }

        public static void RemoveItem(this ES_PaiMaiBuy self, int type, PaiMaiItemInfo paiMaiItemInfo)
        {
            long infoId = paiMaiItemInfo.Id;
            switch (type)
            {
                case 1:
                    foreach (List<PaiMaiItemInfo> paiMaiItemInfos in self.PaiMaiItemInfos_Consume.Values)
                    {
                        foreach (PaiMaiItemInfo info in paiMaiItemInfos)
                        {
                            if (info.Id == infoId)
                            {
                                paiMaiItemInfos.Remove(info);
                                break;
                            }
                        }
                    }

                    break;
                case 2:
                    foreach (List<PaiMaiItemInfo> paiMaiItemInfos in self.PaiMaiItemInfos_Material.Values)
                    {
                        foreach (PaiMaiItemInfo info in paiMaiItemInfos)
                        {
                            if (info.Id == infoId)
                            {
                                paiMaiItemInfos.Remove(info);
                                break;
                            }
                        }
                    }

                    break;
                case 3:
                    foreach (List<PaiMaiItemInfo> paiMaiItemInfos in self.PaiMaiItemInfos_Equipment.Values)
                    {
                        foreach (PaiMaiItemInfo info in paiMaiItemInfos)
                        {
                            if (info.Id == infoId)
                            {
                                paiMaiItemInfos.Remove(info);
                                break;
                            }
                        }
                    }

                    break;
                case 4:
                    foreach (List<PaiMaiItemInfo> paiMaiItemInfos in self.PaiMaiItemInfos_Equipment.Values)
                    {
                        foreach (PaiMaiItemInfo info in paiMaiItemInfos)
                        {
                            if (info.Id == infoId)
                            {
                                paiMaiItemInfos.Remove(info);
                                break;
                            }
                        }
                    }

                    break;
            }
        }

        public static async ETTask OnClickTypeItem(this ES_PaiMaiBuy self, int itemType, int itemSubType, int page = 1)
        {
            self.PaiMaiIteminfos_Now.Clear();

            self.ItemType = itemType;
            self.ItemSubType = itemSubType;
            self.PageIndex = page;

            self.PaiMaiIteminfos_Now.AddRange(self.GetInfoLocal(self.ItemType, self.ItemSubType));

            if (self.PaiMaiIteminfos_Now == null || self.PaiMaiIteminfos_Now.Count <= 0)
            {
                await self.UpdatePaiMaiData(itemType);
                self.PaiMaiIteminfos_Now.AddRange(self.GetInfoLocal(self.ItemType, self.ItemSubType));
            }

            self.ShowPaiMaiList();

            self.E_Text_PageShowText.text = self.PageIndex.ToString();
        }

        public static List<PaiMaiItemInfo> GetInfoLocal(this ES_PaiMaiBuy self, int itemType, int itemSubType)
        {
            List<PaiMaiItemInfo> paiMaiItemInfos = new List<PaiMaiItemInfo>();
            switch (itemType)
            {
                case 1:
                    if (!self.PaiMaiItemInfos_Consume.ContainsKey(self.PageIndex))
                    {
                        self.PaiMaiItemInfos_Consume.Add(self.PageIndex, new List<PaiMaiItemInfo>());
                    }

                    paiMaiItemInfos.AddRange(self.PaiMaiItemInfos_Consume[self.PageIndex]);
                    break;

                case 2:
                    if (!self.PaiMaiItemInfos_Material.ContainsKey(self.PageIndex))
                    {
                        self.PaiMaiItemInfos_Material.Add(self.PageIndex, new List<PaiMaiItemInfo>());
                    }

                    paiMaiItemInfos.AddRange(self.PaiMaiItemInfos_Material[self.PageIndex]);
                    break;

                case 3:
                    if (!self.PaiMaiItemInfos_Equipment.ContainsKey(self.PageIndex))
                    {
                        self.PaiMaiItemInfos_Equipment.Add(self.PageIndex, new List<PaiMaiItemInfo>());
                    }

                    paiMaiItemInfos.AddRange(self.PaiMaiItemInfos_Equipment[self.PageIndex]);
                    break;

                case 4:
                    if (!self.PaiMaiItemInfos_Gemstone.ContainsKey(self.PageIndex))
                    {
                        self.PaiMaiItemInfos_Gemstone.Add(self.PageIndex, new List<PaiMaiItemInfo>());
                    }

                    paiMaiItemInfos.AddRange(self.PaiMaiItemInfos_Gemstone[self.PageIndex]);
                    break;
            }

            if (itemSubType != 0)
            {
                for (int i = paiMaiItemInfos.Count - 1; i >= 0; i--)
                {
                    ItemConfig itemConfig = ItemConfigCategory.Instance.Get(paiMaiItemInfos[i].BagInfo.ItemID);
                    if (itemConfig.ItemSubType != itemSubType)
                    {
                        paiMaiItemInfos.RemoveAt(i);
                    }
                }
            }

            return paiMaiItemInfos;
        }

        public static void OnPrePageBtnButton(this ES_PaiMaiBuy self)
        {
            if (self.PageIndex <= 1)
            {
                return;
            }

            self.PageIndex -= 1;
            self.OnClickTypeItem(self.ItemType, self.ItemSubType, self.PageIndex).Coroutine();
        }

        public static void OnNextPageBtnButton(this ES_PaiMaiBuy self)
        {
            switch (self.ItemType)
            {
                case 1:
                    if (self.PageIndex >= self.MaxPage_Consume)
                    {
                        FlyTipComponent.Instance.ShowFlyTip("已达最后一页");
                        return;
                    }

                    break;

                case 2:
                    if (self.PageIndex >= self.MaxPage_Material)
                    {
                        FlyTipComponent.Instance.ShowFlyTip("已达最后一页");
                        return;
                    }

                    break;

                case 3:
                    if (self.PageIndex >= self.MaxPage_Equipment)
                    {
                        FlyTipComponent.Instance.ShowFlyTip("已达最后一页");
                        return;
                    }

                    break;

                case 4:
                    if (self.PageIndex >= self.MaxPage_Gemstone)
                    {
                        FlyTipComponent.Instance.ShowFlyTip("已达最后一页");
                        return;
                    }

                    break;
            }

            self.PageIndex += 1;
            self.OnClickTypeItem(self.ItemType, self.ItemSubType, self.PageIndex).Coroutine();
        }

        public static async ETTask OnBtn_SearchButton(this ES_PaiMaiBuy self)
        {
            string text = self.E_InputFieldInputField.text;

            if (string.IsNullOrEmpty(text))
            {
                FlyTipComponent.Instance.ShowFlyTip("请输入道具名字！！！");
                return;
            }

            List<int> findTypeList = new List<int>();
            List<int> findItemIdList = new List<int>();

            foreach (ItemConfig itemConfig in ItemConfigCategory.Instance.GetAll().Values)
            {
                if (itemConfig.ItemName.Contains(text))
                {
                    if (!findItemIdList.Contains(itemConfig.Id))
                    {
                        findItemIdList.Add(itemConfig.Id);
                    }

                    if (!findTypeList.Contains(itemConfig.ItemType))
                    {
                        findTypeList.Add(itemConfig.ItemType);
                    }
                }
            }

            if (findTypeList.Count <= 0 || findItemIdList.Count <= 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("不存在该名称的道具，请输入正确的道具名！！！");
                return;
            }

            long timeNow = TimeHelper.ServerNow();
            if (timeNow - self.SearchTime <= 3000)
            {
                FlyTipComponent.Instance.ShowFlyTip("搜索过于频繁！！！");
                return;
            }

            self.SearchTime = timeNow;

            self.PaiMaiIteminfos_Now.Clear();

            P2C_PaiMaiSearchResponse response = await PaiMaiNetHelper.PaiMaiSearch(self.Root(), findTypeList, findItemIdList);
            self.PaiMaiIteminfos_Now.AddRange(response.PaiMaiItemInfos);

            self.ShowPaiMaiList();
            if (self.PaiMaiIteminfos_Now.Count <= 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("未找到对应拍卖行道具");
            }
        }

        public static async ETTask UpdatePaiMaiData(this ES_PaiMaiBuy self, int itemType)
        {
            long instanceId = self.InstanceId;

            P2C_PaiMaiListResponse response =
                    await PaiMaiNetHelper.PaiMaiList(self.Root(), self.PageIndex, itemType, UnitHelper.GetMyUnitFromClientScene(self.Root()).Id);
            if (instanceId != self.InstanceId)
            {
                return;
            }

            switch (itemType)
            {
                case 1:
                    self.PaiMaiItemInfos_Consume[self.PageIndex].Clear();
                    self.PaiMaiItemInfos_Consume[self.PageIndex].AddRange(response.PaiMaiItemInfos);
                    self.MaxPage_Consume = response.NextPage;
                    break;

                case 2:
                    self.PaiMaiItemInfos_Material[self.PageIndex].Clear();
                    self.PaiMaiItemInfos_Material[self.PageIndex].AddRange(response.PaiMaiItemInfos);
                    self.MaxPage_Material = response.NextPage;
                    break;

                case 3:
                    self.PaiMaiItemInfos_Equipment[self.PageIndex].Clear();
                    self.PaiMaiItemInfos_Equipment[self.PageIndex].AddRange(response.PaiMaiItemInfos);
                    self.MaxPage_Equipment = response.NextPage;
                    break;

                case 4:
                    self.PaiMaiItemInfos_Gemstone[self.PageIndex].Clear();
                    self.PaiMaiItemInfos_Gemstone[self.PageIndex].AddRange(response.PaiMaiItemInfos);
                    self.MaxPage_Gemstone = response.NextPage;
                    break;
            }
        }

        public static void ShowPaiMaiList(this ES_PaiMaiBuy self)
        {
            self.ShowPaiMaiIteminfos.Clear();
            for (int i = 0; i < self.PaiMaiIteminfos_Now.Count; i++)
            {
                PaiMaiItemInfo paiMaiItemInfo = self.PaiMaiIteminfos_Now[i];
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(paiMaiItemInfo.BagInfo.ItemID);
                if (!CommonHelp.IsShowPaiMai(itemConfig.ItemType, itemConfig.ItemSubType))
                {
                    continue;
                }

                self.ShowPaiMaiIteminfos.Add(paiMaiItemInfo);
            }

            self.AddUIScrollItems(ref self.ScrollItemPaiMaiBuyItems, self.ShowPaiMaiIteminfos.Count);
            self.E_PaiMaiBuyItemsLoopVerticalScrollRect.SetVisible(true, self.ShowPaiMaiIteminfos.Count);
        }

        private static void OnPaiMaiBuyItemsRefresh(this ES_PaiMaiBuy self, Transform transform, int index)
        {
            foreach (Scroll_Item_PaiMaiBuyItem item in self.ScrollItemPaiMaiBuyItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_PaiMaiBuyItem scrollItemPaiMaiBuyItem = self.ScrollItemPaiMaiBuyItems[index].BindTrans(transform);
            scrollItemPaiMaiBuyItem.OnUpdateItem(self.PaiMaiIteminfos_Now[index]);
        }
    }
}
