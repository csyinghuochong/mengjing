using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof(ES_JiaYuanCooking))]
    [FriendOfAttribute(typeof(ES_JiaYuanCooking))]
    public static partial class ES_JiaYuanCookingSystem
    {
        [EntitySystem]
        private static void Awake(this ES_JiaYuanCooking self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.E_ButtonMakeButton.AddListenerAsync(self.OnButtonMakeButton);
            self.CostItemList[0] = self.ES_CommonItem_0;
            self.CostItemList[1] = self.ES_CommonItem_1;
            self.CostItemList[2] = self.ES_CommonItem_2;
            self.CostItemList[3] = self.ES_CommonItem_3;

            self.OnUpdateUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_JiaYuanCooking self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnButtonMakeButton(this ES_JiaYuanCooking self)
        {
            if (self.Root().GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("背包空间不足！");
                return;
            }

            M2C_JiaYuanCookResponse response = await JiaYuanNetHelper.JiaYuanCookRequest(self.Root(), self.GetSelectIds());
            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            if (response.ItemId != 0)
            {
                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CommonReward);
                List<RewardItem> rewardItems = new List<RewardItem>();
                rewardItems.Add(new() { ItemID = response.ItemId, ItemNum = 1 });
                self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgCommonReward>().OnUpdateUI(rewardItems);
            }

            if (response.LearnId != 0)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(response.LearnId);
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("恭喜你学会制作 {0}", itemConfig.ItemName));
                }
            }

            self.Root().GetComponent<JiaYuanComponentC>().LearnMakeIds_7 = response.LearnMakeIds;
            self.OnUpdateUI();
        }

        public static List<long> GetSelectIds(this ES_JiaYuanCooking self)
        {
            List<long> ids = new List<long>();
            for (int i = 0; i < self.CostItemList.Length; i++)
            {
                ES_CommonItem esCommonItem = self.CostItemList[i];
                if (esCommonItem.Baginfo == null)
                {
                    continue;
                }

                ids.Add(esCommonItem.Baginfo.BagInfoID);
            }

            return ids;
        }

        public static void ResetUiItem(this ES_JiaYuanCooking self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            Dictionary<long, long> itemNumber = new Dictionary<long, long>();

            for (int i = 0; i < self.CostItemList.Length; i++)
            {
                ES_CommonItem esCommonItem = self.CostItemList[i];
                if (esCommonItem.Baginfo == null)
                {
                    esCommonItem.UpdateItem(null, ItemOperateEnum.None);
                    continue;
                }

                ItemInfo bagInfo = bagComponent.GetBagInfo(esCommonItem.Baginfo.BagInfoID);
                if (bagInfo == null)
                {
                    esCommonItem.UpdateItem(null, ItemOperateEnum.None);
                    continue;
                }

                if (!itemNumber.ContainsKey(bagInfo.BagInfoID))
                {
                    itemNumber.Add(bagInfo.BagInfoID, 1);
                }
                else
                {
                    itemNumber[bagInfo.BagInfoID]++;
                }

                if (itemNumber[bagInfo.BagInfoID] > bagInfo.ItemNum)
                {
                    esCommonItem.UpdateItem(null, ItemOperateEnum.None);
                }
            }
        }

        private static void OnBagItemsRefresh(this ES_JiaYuanCooking self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(index < self.ShowBagInfos.Count ? self.ShowBagInfos[index] : null, ItemOperateEnum.HuishouBag);
            scrollItemCommonItem.PointerDownHandler = (ItemInfo binfo, PointerEventData pdata) =>
            {
                self.OnPointerDown(binfo, pdata).Coroutine();
            };
            scrollItemCommonItem.PointerUpHandler = (ItemInfo binfo, PointerEventData pdata) => { self.OnPointerUp(binfo, pdata); };
            scrollItemCommonItem.SetEventTrigger(true);

            scrollItemCommonItem.E_ItemDragEventTrigger.gameObject.SetActive(index < self.ShowBagInfos.Count);
            scrollItemCommonItem.E_ItemNameText.gameObject.SetActive(false);
        }

        public static void UpdateBagUI(this ES_JiaYuanCooking self, int itemType = -1)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();

            self.ShowBagInfos.Clear();
            List<ItemInfo> baglist = bagComponent.GetBagList();
            for (int i = 0; i < baglist.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(baglist[i].ItemID);
                if (itemConfig.ItemType == 2 && (itemConfig.ItemSubType == 201 || itemConfig.ItemSubType == 301))
                {
                    self.ShowBagInfos.Add(baglist[i]);
                }
            }

            int max = bagComponent.GetBagTotalCell(ItemLocType.ItemLocBag);
            self.AddUIScrollItems(ref self.ScrollItemCommonItems, max);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, max);
        }

        public static void UpdateSelected(this ES_JiaYuanCooking self)
        {
            if (self.ScrollItemCommonItems != null)
            {
                foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    ItemInfo bagInfo = item.Baginfo;
                    if (bagInfo == null)
                    {
                        continue;
                    }

                    bool have = false;
                    for (int h = 0; h < self.CostItemList.Length; h++)
                    {
                        ES_CommonItem esCommonItem = self.CostItemList[h];
                        if (esCommonItem.Baginfo != null && esCommonItem.Baginfo.BagInfoID == bagInfo.BagInfoID)
                        {
                            have = true;
                        }
                    }

                    item.E_XuanZhongImage.gameObject.SetActive(have);
                }
            }
        }

        public static void OnHuiShouSelect(this ES_JiaYuanCooking self, string dataparams)
        {
            long curNumber = 0;
            string[] huishouInfo = dataparams.Split('_');
            ItemInfo bagInfo = self.Root().GetComponent<BagComponentC>().GetBagInfo(long.Parse(huishouInfo[1]));

            long totalNumber = bagInfo.ItemNum;

            if (huishouInfo[0] == "1")
            {
                for (int i = 0; i < self.CostItemList.Length; i++)
                {
                    ES_CommonItem esCommonItem = self.CostItemList[i];
                    ItemInfo bagInfo1 = esCommonItem.Baginfo;
                    if (bagInfo1 != null && bagInfo1.ItemID == bagInfo.ItemID)
                    {
                        curNumber++;
                    }
                }

                if (curNumber >= totalNumber)
                {
                    return;
                }

                for (int i = 0; i < self.CostItemList.Length; i++)
                {
                    ES_CommonItem esCommonItem = self.CostItemList[i];
                    if (esCommonItem.Baginfo != null)
                    {
                        continue;
                    }

                    ItemInfo bagInfo1 = new ItemInfo();
                    bagInfo1.ItemID = bagInfo.ItemID;
                    bagInfo1.BagInfoID = bagInfo.BagInfoID;
                    bagInfo1.ItemNum = 1;
                    // bagInfo1.RpcId = i;
                    esCommonItem.UpdateItem(bagInfo1, ItemOperateEnum.HuishouShow);
                    esCommonItem.E_ItemNumText.text = "1";
                    esCommonItem.E_ItemNameText.gameObject.SetActive(false);
                    break;
                }
            }
            else
            {
                for (int i = self.CostItemList.Length - 1; i >= 0; i--)
                {
                    ES_CommonItem esCommonItem = self.CostItemList[i];
                    ItemInfo bagInfo1 = esCommonItem.Baginfo;
                    if (bagInfo1 == null)
                    {
                        continue;
                    }

                    if (bagInfo1.BagInfoID == bagInfo.BagInfoID)
                    {
                        esCommonItem.UpdateItem(null, ItemOperateEnum.HuishouShow);
                        esCommonItem.E_ItemNumText.text = "1";
                        esCommonItem.E_ItemNameText.gameObject.SetActive(false);
                        break;
                    }
                }
            }

            self.UpdateSelected();
        }

        public static async ETTask OnPointerDown(this ES_JiaYuanCooking self, ItemInfo binfo, PointerEventData pdata)
        {
            if (binfo == null)
            {
                return;
            }

            self.IsHoldDown = true;
            EventSystem.Instance.Publish(self.Root(), new HuiShouSelect() { DataParamString = $"1_{binfo.BagInfoID}" });

            await self.Root().GetComponent<TimerComponent>().WaitAsync(500);
            if (!self.IsHoldDown)
            {
                return;
            }

            EventSystem.Instance.Publish(self.Root(),
                new ShowItemTips()
                {
                    BagInfo = binfo,
                    ItemOperateEnum = ItemOperateEnum.None,
                    InputPoint = Input.mousePosition,
                    Occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ,
                    EquipList = new()
                });
        }

        public static void OnPointerUp(this ES_JiaYuanCooking self, ItemInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = false;
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
        }

        public static void OnUpdateUI(this ES_JiaYuanCooking self)
        {
            self.ResetUiItem();
            self.UpdateBagUI();
            self.UpdateSelected();
        }
    }
}
