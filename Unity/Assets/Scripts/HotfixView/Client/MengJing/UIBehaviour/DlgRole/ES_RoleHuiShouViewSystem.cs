using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(UserInfoComponentC))]
    [FriendOf(typeof(ES_CommonItem))]
    [EntitySystemOf(typeof(ES_RoleHuiShou))]
    [FriendOfAttribute(typeof(ES_RoleHuiShou))]
    public static partial class ES_RoleHuiShouSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleHuiShou self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.E_YiJianInputButton.AddListener(self.OnYiJianInputButton);
            self.E_HuiShouButton.AddListener(self.OnHuiShouButton);

            self.HuiShouUIList[0] = self.ES_CommonItem_1;
            self.ES_CommonItem_1.UpdateItem(null, ItemOperateEnum.None);
            self.HuiShouUIList[1] = self.ES_CommonItem_2;
            self.ES_CommonItem_2.UpdateItem(null, ItemOperateEnum.None);
            self.HuiShouUIList[2] = self.ES_CommonItem_3;
            self.ES_CommonItem_3.UpdateItem(null, ItemOperateEnum.None);
            self.HuiShouUIList[3] = self.ES_CommonItem_4;
            self.ES_CommonItem_4.UpdateItem(null, ItemOperateEnum.None);
            self.HuiShouUIList[4] = self.ES_CommonItem_5;
            self.ES_CommonItem_5.UpdateItem(null, ItemOperateEnum.None);
            self.HuiShouUIList[5] = self.ES_CommonItem_6;
            self.ES_CommonItem_6.UpdateItem(null, ItemOperateEnum.None);
            self.HuiShouUIList[6] = self.ES_CommonItem_7;
            self.ES_CommonItem_7.UpdateItem(null, ItemOperateEnum.None);
            self.HuiShouUIList[7] = self.ES_CommonItem_8;
            self.ES_CommonItem_8.UpdateItem(null, ItemOperateEnum.None);
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleHuiShou self)
        {
            self.DestroyWidget();
        }

        private static void OnBagItemsRefresh(this ES_RoleHuiShou self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.HuishouBag);
            scrollItemCommonItem.SetEventTrigger(true);
            scrollItemCommonItem.PointerDownHandler = (binfo, pdata) => { self.OnPointerDown(binfo, pdata).Coroutine(); };
            scrollItemCommonItem.PointerUpHandler = (binfo, pdata) => { self.OnPointerUp(binfo, pdata); };
        }

        public static void OnHuiShouSelect(this ES_RoleHuiShou self, string dataparams)
        {
            self.UpdateHuiShouInfo(dataparams);
            self.UpdateHuiShouUI();
            self.OnUpdateGetList();
            self.UpdateSelected();
        }

        public static void OnEquipHuiShow(this ES_RoleHuiShou self)
        {
            self.OnUpdateUI();
        }

        public static void OnUpdateUI(this ES_RoleHuiShou self)
        {
            self.HuiShouInfos = new ItemInfo[self.HuiShouInfos.Length];
            self.RefreshBagItems();
            self.UpdateHuiShouUI();
            self.OnUpdateGetList();
            self.UpdateSelected();
        }

        private static void UpdateHuiShouInfo(this ES_RoleHuiShou self, string dataparams)
        {
            string[] huishouInfo = dataparams.Split('_');
            ItemInfo bagInfo = self.Root().GetComponent<BagComponentC>().GetBagInfo(long.Parse(huishouInfo[1]));
            if (huishouInfo[0] == "1")
            {
                for (int i = 0; i < self.HuiShouInfos.Length; i++)
                {
                    if (self.HuiShouInfos[i] == bagInfo)
                    {
                        return;
                    }
                }

                for (int i = 0; i < self.HuiShouInfos.Length; i++)
                {
                    if (self.HuiShouInfos[i] == null)
                    {
                        self.HuiShouInfos[i] = bagInfo;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < self.HuiShouInfos.Length; i++)
                {
                    if (self.HuiShouInfos[i] == bagInfo)
                    {
                        self.HuiShouInfos[i] = null;
                        break;
                    }
                }
            }
        }

        private static void UpdateSelected(this ES_RoleHuiShou self)
        {
            for (int i = 0; i < self.ScrollItemCommonItems.Keys.Count - 1; i++)
            {
                Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[i];
                // 滚动组件的子物体是动态从对象池里拿的，只引用看的到的
                if (scrollItemCommonItem.uiTransform != null)
                {
                    if (scrollItemCommonItem.Baginfo == null)
                    {
                        continue;
                    }

                    bool have = false;
                    for (int h = 0; h < self.HuiShouInfos.Length; h++)
                    {
                        if (self.HuiShouInfos[h] != null &&
                            self.HuiShouInfos[h].BagInfoID == scrollItemCommonItem.Baginfo.BagInfoID)
                        {
                            have = true;
                            break;
                        }
                    }

                    scrollItemCommonItem.E_XuanZhongImage.gameObject.SetActive(have);
                    scrollItemCommonItem.E_ImageReceivedImage.gameObject.SetActive(have);
                }
            }
        }

        private static void RefreshBagItems(this ES_RoleHuiShou self)
        {
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();

            self.ShowBagInfos.Clear();

            self.ShowBagInfos.AddRange(bagComponentC.GetItemsByType(ItemTypeEnum.Equipment));
            self.ShowBagInfos.AddRange(bagComponentC.GetItemsByType(ItemTypeEnum.Gemstone));
            self.ShowBagInfos.AddRange(bagComponentC.GetItemsByLoc(ItemLocType.ItemPetHeXinBag));
            self.ShowBagInfos.AddRange(bagComponentC.GetItemsByTypeAndSubType(ItemTypeEnum.Consume, 5));

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }

        private static async ETTask OnPointerDown(this ES_RoleHuiShou self, ItemInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = true;
            using (zstring.Block())
            {
                EventSystem.Instance.Publish(self.Root(), new HuiShouSelect() { DataParamString = zstring.Format("1_{0}", binfo.BagInfoID) });
            }

            await self.Root().GetComponent<TimerComponent>().WaitAsync(500);
            if (!self.IsHoldDown)
                return;

            EventSystem.Instance.Publish(self.Root(),
                new ShowItemTips()
                {
                    BagInfo = binfo,
                    ItemOperateEnum = ItemOperateEnum.None,
                    InputPoint = Input.mousePosition,
                    Occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ,
                    EquipList = new List<ItemInfo>()
                });
        }

        private static void OnPointerUp(this ES_RoleHuiShou self, ItemInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = false;
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
        }

        private static void OnYiJianInputButton(this ES_RoleHuiShou self)
        {
            //最多选取五个
            self.HuiShouInfos = new ItemInfo[self.HuiShouInfos.Length];

            int number = 0;
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();
            List<ItemInfo> bagInfos = bagComponentC.GetItemsByType(ItemTypeEnum.Equipment);
            bagInfos.AddRange(bagComponentC.GetItemsByType(ItemTypeEnum.Gemstone));
            for (int i = 0; i < bagInfos.Count; i++)
            {
                if (bagInfos[i].IsProtect)
                {
                    continue;
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.ItemType == ItemTypeEnum.Equipment)
                {
                    // 绿色、蓝色品质的生肖不分解
                    if (itemConfig.EquipType == 101 && (itemConfig.ItemQuality == (int)ItemQualityEnem.Quality2 ||
                            itemConfig.ItemQuality == (int)ItemQualityEnem.Quality3))
                    {
                        continue;
                    }

                    if (itemConfig.ItemQuality < (int)ItemQualityEnem.Quality4)
                    {
                        self.HuiShouInfos[number] = bagInfos[i];
                        number++;
                    }
                }

                if (itemConfig.ItemType == ItemTypeEnum.Gemstone)
                {
                    if (itemConfig.ItemQuality <= (int)ItemQualityEnem.Quality3)
                    {
                        self.HuiShouInfos[number] = bagInfos[i];
                        number++;
                    }
                }

                if (number >= 8)
                {
                    break;
                }
            }

            self.UpdateHuiShouUI();
            self.OnUpdateGetList();
            self.UpdateSelected();
        }

        private static void UpdateHuiShouUI(this ES_RoleHuiShou self)
        {
            for (int i = 0; i < self.HuiShouInfos.Length; i++)
            {
                ES_CommonItem esCommonItem = self.HuiShouUIList[i];
                esCommonItem.UpdateItem(self.HuiShouInfos[i], ItemOperateEnum.HuishouShow);
            }
        }

        private static void OnUpdateGetList(this ES_RoleHuiShou self)
        {
            Dictionary<int, BagInfo> huishouGet = new Dictionary<int, BagInfo>();
            for (int i = 0; i < self.HuiShouInfos.Length; i++)
            {
                string huishouItem = "";
                if (self.HuiShouInfos[i] != null)
                {
                    huishouItem = ItemConfigCategory.Instance.Get(self.HuiShouInfos[i].ItemID).HuiShouGetItem;
                }

                if (huishouItem.Length > 0)
                {
                    string[] itemList = huishouItem.Split(';');
                    for (int k = 0; k < itemList.Length; k++)
                    {
                        string[] itemInfo = itemList[k].Split(',');
                        int itemId = int.Parse(itemInfo[0]);
                        int itemNum = int.Parse(itemInfo[1]) * self.HuiShouInfos[i].ItemNum;

                        if (huishouGet.ContainsKey(itemId))
                        {
                            huishouGet[itemId].ItemNum += itemNum;
                        }
                        else
                        {
                            BagInfo bagInfoNew = BagInfo.Create();
                            bagInfoNew.ItemID = itemId;
                            bagInfoNew.ItemNum = itemNum;
                            huishouGet.Add(itemId, bagInfoNew);
                        }
                    }
                }
            }

            List<BagInfo> bagInfos = huishouGet.Values.ToList();
            List<RewardItem> rewardItems = new List<RewardItem>();
            for (int i = 0; i < bagInfos.Count; i++)
            {
                rewardItems.Add(new RewardItem() { ItemID = bagInfos[i].ItemID, ItemNum = bagInfos[i].ItemNum });
            }

            self.ES_RewardList.Refresh(rewardItems);
        }

        private static void OnHuiShouButton(this ES_RoleHuiShou self)
        {
            using (zstring.Block())
            {
                List<long> huishouList = new List<long>();
                zstring tip = "";
                bool petHeXin8 = false;
                for (int i = 0; i < self.HuiShouInfos.Length; i++)
                {
                    if (self.HuiShouInfos[i] != null)
                    {
                        ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.HuiShouInfos[i].ItemID);
                        string gemStr = self.HuiShouInfos[i].GemIDNew;
                        string[] gem = gemStr.Split('_');
                        for (int j = 0; j < gem.Length; j++)
                        {
                            if (gem[j] != "0")
                            {
                                tip += " ";
                                tip += ItemConfigCategory.Instance.Get(self.HuiShouInfos[i].ItemID).ItemName;
                                break;
                            }
                        }

                        if (itemConfig.ItemType == ItemTypeEnum.PetHeXin && itemConfig.UseLv >= 8)
                        {
                            petHeXin8 = true;
                        }

                        huishouList.Add(self.HuiShouInfos[i].BagInfoID);
                    }
                }

                if (huishouList.Count == 0)
                {
                    return;
                }

                if (tip != "")
                {
                    tip += " 中镶嵌宝石，分解会导致宝石消失!\n";
                }

                if (petHeXin8)
                {
                    tip += "请问确实需要分解高级的宠物之核嘛？";
                }

                if (tip != "")
                {
                    PopupTipHelp.OpenPopupTip(self.Root(), "分解", tip, async () =>
                    {
                        await BagClientNetHelper.RequestHuiShou(self.Root(), huishouList);
                        FlyTipComponent.Instance.ShowFlyTip("分解成功");
                    }, () => { }).Coroutine();
                }
                else
                {
                    BagClientNetHelper.RequestHuiShou(self.Root(), huishouList).Coroutine();
                }
            }
        }
    }
}
