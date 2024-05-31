﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
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

            self.UITypeViewComponent = self.AddChild<UITypeViewComponent, GameObject>(self.EG_TypeListNodeRectTransform.gameObject);
            self.UITypeViewComponent.TypeButtonItemAsset = ABPathHelper.GetUGUIPath("Common/UITypeItem");
            self.UITypeViewComponent.TypeButtonAsset = ABPathHelper.GetUGUIPath("Common/UITypeButton");
            self.UITypeViewComponent.ClickTypeItemHandler = (itemType, itemSubType) => { self.OnClickTypeItem(itemType, itemSubType).Coroutine(); };

            self.UITypeViewComponent.TypeButtonInfos = self.InitTypeButtonInfos();
            self.UITypeViewComponent.OnInitUI().Coroutine();

            self.E_Btn_SearchButton.AddListenerAsync(self.OnClickBtn_Search);
            self.E_NextPageBtnButton.AddListener(self.OnNextPageBtn);
            self.E_PrePageBtnButton.AddListener(self.OnPrePageBtn);
        }

        [EntitySystem]
        private static void Destroy(this ES_PaiMaiBuy self)
        {
            self.DestroyWidget();
        }

        /// <summary>
        /// 定位对应的切页和某个道具所在的位置
        /// </summary>
        /// <param name="self"></param>
        /// <param name="itemType"></param>
        /// <param name="paimaiItemId"></param>
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

            C2P_PaiMaiFindRequest reuqest = new() { ItemType = itemType, PaiMaiItemInfoId = paimaiItemId };
            P2C_PaiMaiFindResponse response = (P2C_PaiMaiFindResponse)await self.Root().GetComponent<ClientSenderCompnent>().Call(reuqest);
            if (response.Page == 0)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("道具已经被买走了!");
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

            // 移动到指定位置
            for (int i = 0; i < self.PaiMaiIteminfos_Now.Count; i++)
            {
                if (self.PaiMaiIteminfos_Now[i].Id == paimaiItemId)
                {
                    self.ItemListNode.GetComponent<RectTransform>().localPosition = new Vector3(0, i * 124f, 0);
                    break;
                }
            }
        }

        /// <summary>
        /// 初始化切页
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static List<TypeButtonInfo> InitTypeButtonInfos(this ES_PaiMaiBuy self)
        {
            //显示列表
            TypeButtonInfo typeButtonInfo = new TypeButtonInfo();
            List<TypeButtonInfo> typeButtonInfos = new List<TypeButtonInfo>();
            typeButtonInfo = new TypeButtonInfo();
            foreach (int key in ItemViewHelp.ItemSubType1Name.Keys)
            {
                typeButtonInfo.typeButtonItems.Add(new TypeButtonItem() { SubTypeId = key, ItemName = ItemViewHelp.ItemSubType1Name[key] });
            }

            typeButtonInfo.TypeId = 1;
            typeButtonInfo.TypeName = ItemViewHelp.ItemTypeName[ItemTypeEnum.Consume];
            typeButtonInfos.Add(typeButtonInfo);

            typeButtonInfo = new TypeButtonInfo();
            foreach (int key in ItemViewHelp.ItemSubType2Name.Keys)
            {
                typeButtonInfo.typeButtonItems.Add(new TypeButtonItem() { SubTypeId = key, ItemName = ItemViewHelp.ItemSubType2Name[key] });
            }

            typeButtonInfo.TypeId = 2;
            typeButtonInfo.TypeName = ItemViewHelp.ItemTypeName[ItemTypeEnum.Material];
            typeButtonInfos.Add(typeButtonInfo);

            typeButtonInfo = new TypeButtonInfo();
            foreach (int key in ItemViewHelp.ItemSubType3Name.Keys)
            {
                typeButtonInfo.typeButtonItems.Add(new TypeButtonItem() { SubTypeId = key, ItemName = ItemViewHelp.ItemSubType3Name[key] });
            }

            typeButtonInfo.TypeId = 3;
            typeButtonInfo.TypeName = ItemViewHelp.ItemTypeName[ItemTypeEnum.Equipment];
            typeButtonInfos.Add(typeButtonInfo);

            typeButtonInfo = new TypeButtonInfo();
            foreach (int key in ItemViewHelp.ItemSubType4Name.Keys)
            {
                typeButtonInfo.typeButtonItems.Add(new TypeButtonItem() { SubTypeId = key, ItemName = ItemViewHelp.ItemSubType4Name[key] });
            }

            typeButtonInfo.TypeId = 4;
            typeButtonInfo.TypeName = ItemViewHelp.ItemTypeName[ItemTypeEnum.Gemstone];
            typeButtonInfos.Add(typeButtonInfo);

            return typeButtonInfos;
        }

        /// <summary>
        /// 移除拍卖物品数据(本地)
        /// </summary>
        /// <param name="self"></param>
        /// <param name="type"></param>
        /// <param name="paiMaiItemInfo"></param>
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

        /// <summary>
        /// 点击切页
        /// </summary>
        /// <param name="self"></param>
        /// <param name="itemType"></param>
        /// <param name="itemSubType"></param>
        /// <param name="page"></param>
        public static async ETTask OnClickTypeItem(this ES_PaiMaiBuy self, int itemType, int itemSubType, int page = 1)
        {
            Log.Debug($"-------点击切页 ItemType:{itemType} ItemSubType:{itemSubType} Page:{page}--------");
            self.PaiMaiIteminfos_Now.Clear();

            self.ItemType = itemType;
            self.ItemSubType = itemSubType;
            self.PageIndex = page;

            // 先尝试从缓存获取
            self.PaiMaiIteminfos_Now.AddRange(self.GetInfoLocal(self.ItemType, self.ItemSubType));

            if (self.PaiMaiIteminfos_Now == null || self.PaiMaiIteminfos_Now.Count <= 0)
            {
                // 从服务端获取
                await self.UpdatePaiMaiData(itemType);
                self.PaiMaiIteminfos_Now.AddRange(self.GetInfoLocal(self.ItemType, self.ItemSubType));
            }

            // 展示拍卖物品
            self.ShowPaiMaiList();

            self.Text_PageShow.GetComponent<Text>().text = self.PageIndex.ToString();
        }

        /// <summary>
        /// 从本地缓存获取数据
        /// </summary>
        /// <param name="self"></param>
        /// <param name="itemType"></param>
        /// <param name="itemSubType"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="self"></param>
        public static void OnPrePageBtn(this ES_PaiMaiBuy self)
        {
            if (self.PageIndex <= 1)
            {
                return;
            }

            self.PageIndex -= 1;
            self.OnClickTypeItem(self.ItemType, self.ItemSubType, self.PageIndex).Coroutine();
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="self"></param>
        public static void OnNextPageBtn(this ES_PaiMaiBuy self)
        {
            switch (self.ItemType)
            {
                case 1:
                    if (self.PageIndex >= self.MaxPage_Consume)
                    {
                        FloatTipManager.Instance.ShowFloatTipDi("已达最后一页");
                        return;
                    }

                    break;

                case 2:
                    if (self.PageIndex >= self.MaxPage_Material)
                    {
                        FloatTipManager.Instance.ShowFloatTipDi("已达最后一页");
                        return;
                    }

                    break;

                case 3:
                    if (self.PageIndex >= self.MaxPage_Equipment)
                    {
                        FloatTipManager.Instance.ShowFloatTipDi("已达最后一页");
                        return;
                    }

                    break;

                case 4:
                    if (self.PageIndex >= self.MaxPage_Gemstone)
                    {
                        FloatTipManager.Instance.ShowFloatTipDi("已达最后一页");
                        return;
                    }

                    break;
            }

            self.PageIndex += 1;
            self.OnClickTypeItem(self.ItemType, self.ItemSubType, self.PageIndex).Coroutine();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="self"></param>
        public static async ETTask OnClickBtn_Search(this ES_PaiMaiBuy self)
        {
            string text = self.InputField.GetComponent<InputField>().text;

            if (string.IsNullOrEmpty(text))
            {
                FloatTipManager.Instance.ShowFloatTipDi("请输入道具名字！！！");
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
                FloatTipManager.Instance.ShowFloatTipDi("不存在该名称的道具，请输入正确的道具名！！！");
                return;
            }

            long timeNow = TimeHelper.ServerNow();
            if (timeNow - self.SearchTime <= 3000)
            {
                FloatTipManager.Instance.ShowFloatTipDi("搜索过于频繁！！！");
                return;
            }

            self.SearchTime = timeNow;

            self.PaiMaiIteminfos_Now.Clear();

            C2P_PaiMaiSearchRequest reuqest = new C2P_PaiMaiSearchRequest() { FindTypeList = findTypeList, FindItemIdList = findItemIdList };
            P2C_PaiMaiSearchResponse response =
                    (P2C_PaiMaiSearchResponse)await self.ZoneScene().GetComponent<SessionComponent>().Session.Call(reuqest);
            self.PaiMaiIteminfos_Now.AddRange(response.PaiMaiItemInfos);

            self.ShowPaiMaiList();
            if (self.PaiMaiIteminfos_Now.Count <= 0)
            {
                FloatTipManager.Instance.ShowFloatTipDi("未找到对应拍卖行道具");
            }
        }

        /// <summary>
        /// 更新拍卖数据,同时更新self.PaiMaiIteminfos_Now(此作法会错过一些道具)
        /// </summary>
        /// <param name="self"></param>
        /// <param name="itemType"></param>
        public static async ETTask UpdatePaiMaiData(this ES_PaiMaiBuy self, int itemType)
        {
            long instanceId = self.InstanceId;

            C2P_PaiMaiListRequest c2M_PaiMaiBuyRequest = new C2P_PaiMaiListRequest()
            {
                Page = self.PageIndex, PaiMaiType = itemType, UserId = UnitHelper.GetMyUnitId(self.ZoneScene()),
            };
            P2C_PaiMaiListResponse m2C_PaiMaiBuyResponse =
                    (P2C_PaiMaiListResponse)await self.DomainScene().GetComponent<SessionComponent>().Session.Call(c2M_PaiMaiBuyRequest);

            //因为是异步不加这里,消息来了玩家关闭界面会报错
            if (instanceId != self.InstanceId)
            {
                return;
            }

            switch (itemType)
            {
                case 1:
                    self.PaiMaiItemInfos_Consume[self.PageIndex].Clear();
                    self.PaiMaiItemInfos_Consume[self.PageIndex].AddRange(m2C_PaiMaiBuyResponse.PaiMaiItemInfos);
                    self.MaxPage_Consume = m2C_PaiMaiBuyResponse.NextPage;
                    break;

                case 2:
                    self.PaiMaiItemInfos_Material[self.PageIndex].Clear();
                    self.PaiMaiItemInfos_Material[self.PageIndex].AddRange(m2C_PaiMaiBuyResponse.PaiMaiItemInfos);
                    self.MaxPage_Material = m2C_PaiMaiBuyResponse.NextPage;
                    break;

                case 3:
                    self.PaiMaiItemInfos_Equipment[self.PageIndex].Clear();
                    self.PaiMaiItemInfos_Equipment[self.PageIndex].AddRange(m2C_PaiMaiBuyResponse.PaiMaiItemInfos);
                    self.MaxPage_Equipment = m2C_PaiMaiBuyResponse.NextPage;
                    break;

                case 4:
                    self.PaiMaiItemInfos_Gemstone[self.PageIndex].Clear();
                    self.PaiMaiItemInfos_Gemstone[self.PageIndex].AddRange(m2C_PaiMaiBuyResponse.PaiMaiItemInfos);
                    self.MaxPage_Gemstone = m2C_PaiMaiBuyResponse.NextPage;
                    break;
            }
        }

        /// <summary>
        /// 展示拍卖物品
        /// </summary>
        /// <param name="self"></param>
        public static void ShowPaiMaiList(this ES_PaiMaiBuy self)
        {
            int number = 0;
            for (int i = 0; i < self.PaiMaiIteminfos_Now.Count; i++)
            {
                PaiMaiItemInfo paiMaiItemInfo = self.PaiMaiIteminfos_Now[i];
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(paiMaiItemInfo.BagInfo.ItemID);
                if (!ComHelp.IsShowPaiMai(itemConfig.ItemType, itemConfig.ItemSubType))
                {
                    continue;
                }

                UIPaiMaiBuyItemComponent uI = null;

                if (number < self.PaiMaiList.Count)
                {
                    uI = self.PaiMaiList[number];
                    uI.GameObject.SetActive(true);
                }
                else
                {
                    GameObject go = UnityEngine.Object.Instantiate(self.UIPaiMaiBuyItem);
                    go.SetActive(true);
                    UICommonHelper.SetParent(go, self.ItemListNode);
                    go.transform.localScale = Vector3.one * 1f;
                    uI = self.AddChild<UIPaiMaiBuyItemComponent, GameObject>(go);
                    self.PaiMaiList.Add(uI);
                }

                uI.OnUpdateItem(paiMaiItemInfo);
                number++;
            }

            for (int i = number; i < self.PaiMaiList.Count; i++)
            {
                self.PaiMaiList[i].GameObject.SetActive(false);
            }
        }
    }
}