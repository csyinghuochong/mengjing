using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_CommonItem))]
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof(ES_RoleBag))]
    [FriendOfAttribute(typeof(ES_RoleBag))]
    public static partial class ES_RoleBagSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleBag self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.E_OpenOneSellSetButton.AddListenerAsync(self.OnOpenOneSellSetButton);
            self.E_OneGemButton.AddListener(self.OnOneGemButton);
            self.E_ZhengLiButton.AddListenerAsync(self.OnZhengLiButton);
            self.E_OneSellButton.AddListener(self.OnOneSellButton);
            self.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleBag self)
        {
            self.DestroyWidget();
        }

        private static void OnBagItemsRefresh(this ES_RoleBag self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            int openell = bagComponent.GetBagTotalCell(ItemLocType.ItemLocBag);
            if (index < openell)
            {
                scrollItemCommonItem.UpdateUnLock(true);
                scrollItemCommonItem.Refresh(index < self.ShowBagInfos.Count ? self.ShowBagInfos[index] : null, ItemOperateEnum.Bag,
                    self.UpdateSelect);
            }
            else
            {
                int addcell = bagComponent.BagBuyCellNumber[0] + (index - openell);
                BuyCellCost buyCellCost = ConfigData.BuyBagCellCosts[addcell];
                int itemid = int.Parse(buyCellCost.Get.Split(';')[0]);
                int itemnum = int.Parse(buyCellCost.Get.Split(';')[1]);
                ItemInfo bagInfoNew = new ItemInfo();
                bagInfoNew.ItemID = itemid;
                bagInfoNew.BagInfoID = index;
                bagInfoNew.ItemNum = itemnum;
                scrollItemCommonItem.Refresh(bagInfoNew, ItemOperateEnum.None);
                scrollItemCommonItem.E_LockButton.AddListener(self.OnClickImage_Lock);
                scrollItemCommonItem.UpdateUnLock(false);
            }

            ItemInfo bagInfo = scrollItemCommonItem.Baginfo;
            if (bagInfo == null)
            {
                return;
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            if (itemConfig.ItemType != 3)
            {
                return;
            }

            int curQulity = 0;
            int curLevel = 0;
            List<ItemInfo> curEquiplist = bagComponent.GetEquipListByWeizhi(itemConfig.ItemSubType);
            for (int e = 0; e < curEquiplist.Count; e++)
            {
                ItemConfig curEquipConfig = ItemConfigCategory.Instance.Get(curEquiplist[e].ItemID);
                if (curEquipConfig.UseLv < curLevel || curLevel == 0)
                {
                    curLevel = curEquipConfig.UseLv;
                }

                if (curEquipConfig.ItemQuality < curQulity || curQulity == 0)
                {
                    curQulity = curEquipConfig.ItemQuality;
                }
            }

            if (curEquiplist.Count < 3 && itemConfig.ItemSubType == 5)
            {
                curQulity = 0;
                curLevel = 0;
            }

            if (itemConfig.EquipType != 0 && itemConfig.EquipType != 99 && itemConfig.EquipType != 101 && itemConfig.EquipType != 201)
            {
                //武器类型
                switch (userInfoComponent.UserInfo.Occ)
                {
                    //战士
                    case 1:
                        if (itemConfig.EquipType < 10 && itemConfig.EquipType != 1 && itemConfig.EquipType != 2)
                        {
                            return;
                        }

                        break;

                    //法师
                    case 2:
                        if (itemConfig.EquipType < 10 && itemConfig.EquipType != 3 && itemConfig.EquipType != 4)
                        {
                            return;
                        }

                        break;
                    //猎人
                    case 3:
                        if (itemConfig.EquipType < 10 && itemConfig.EquipType != 1 && itemConfig.EquipType != 5)
                        {
                            return;
                        }

                        break;
                }

                if (userInfoComponent.UserInfo.OccTwo > 100)
                {
                    OccupationTwoConfig occTwoCof = OccupationTwoConfigCategory.Instance.Get(userInfoComponent.UserInfo.OccTwo);
                    //护甲类型
                    if (itemConfig.EquipType > 10 && itemConfig.EquipType != occTwoCof.ArmorMastery)
                    {
                        return;
                    }
                }
            }

            scrollItemCommonItem.E_UpTipImage.gameObject.SetActive(userInfoComponent.UserInfo.Lv >= itemConfig.UseLv
                && itemConfig.UseLv > curLevel && itemConfig.ItemQuality > curQulity && itemConfig.EquipType != 201); // 晶核不显示箭头
        }

        public static void OnClickImage_Lock(this ES_RoleBag self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            BuyCellCost buyCellCost = ConfigData.BuyBagCellCosts[bagComponent.BagBuyCellNumber[0]];

            using (zstring.Block())
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "购买格子",
                    zstring.Format("是否花费{0}购买一个背包格子?", CommonViewHelper.GetNeedItemDesc(buyCellCost.Cost)),
                    () => { BagClientNetHelper.RequestBuyBagCell(self.Root(), 0).Coroutine(); }, null).Coroutine();
            }

            return;
        }

        private static void OnItemTypeSet(this ES_RoleBag self, int index)
        {
            self.CurrentItemType = index;
            self.RefreshBagItems();
        }

        public static void RefreshBagItems(this ES_RoleBag self)
        {
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();

            self.ShowBagInfos.Clear();

            int itemTypeEnum = ItemTypeEnum.ALL;
            switch (self.CurrentItemType)
            {
                case 0:
                    itemTypeEnum = ItemTypeEnum.ALL;
                    break;
                case 1:
                    itemTypeEnum = ItemTypeEnum.Equipment;
                    break;
                case 2:
                    itemTypeEnum = ItemTypeEnum.Material;
                    break;
                case 3:
                    itemTypeEnum = ItemTypeEnum.Consume;
                    break;
            }

            int allNumber = bagComponentC.GetBagShowCell(ItemLocType.ItemLocBag);
            // int maxCount = GlobalValueConfigCategory.Instance.BagMaxCapacity;
            self.ShowBagInfos.AddRange(bagComponentC.GetItemsByType(itemTypeEnum));
            self.AddUIScrollItems(ref self.ScrollItemCommonItems, allNumber);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, allNumber);
        }

        private static void UpdateSelect(this ES_RoleBag self, ItemInfo bagInfo)
        {
            for (int i = 0; i < self.ScrollItemCommonItems.Keys.Count - 1; i++)
            {
                Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[i];
                if (scrollItemCommonItem.uiTransform != null)
                {
                    scrollItemCommonItem.SetSelected(bagInfo);
                }
            }
        }

        private static async ETTask OnOpenOneSellSetButton(this ES_RoleBag self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_OneSellSet);
        }

        private static void OnOneGemButton(this ES_RoleBag self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("请至少预留一个格子");
                return;
            }

            List<ItemInfo> bagItemList = bagComponent.GetBagList();
            List<ItemInfo> gemList = new List<ItemInfo>();
            for (int i = 0; i < bagItemList.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagItemList[i].ItemID);
                if (itemConfig.ItemType != ItemTypeEnum.Gemstone)
                {
                    continue;
                }

                if (!EquipMakeConfigCategory.Instance.GetHeChengList.ContainsKey(itemConfig.Id))
                {
                    continue;
                }

                gemList.Add(bagItemList[i]);
            }

            long costgold = 0;
            long costvitality = 0;
            for (int i = gemList.Count - 1; i >= 0; i--)
            {
                KeyValuePairInt keyValuePair = EquipMakeConfigCategory.Instance.GetHeChengList[gemList[i].ItemID];
                int neednumber = (int)keyValuePair.Value;
                int newmakeid = keyValuePair.KeyId;
                int newnumber = gemList[i].ItemNum / neednumber;
                EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(newmakeid);
                costgold += (equipMakeConfig.MakeNeedGold * newnumber);
                costvitality += (equipMakeConfig.CostVitality * newnumber);
            }

            if (costgold <= 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("当前背包暂无可合成宝石");
                return;
            }

            using (zstring.Block())
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "合成宝石", zstring.Format("一键合成消耗{0}金币", costgold),
                            () => { BagClientNetHelper.RquestGemHeCheng(self.Root(), 0).Coroutine(); }, null)
                        .Coroutine();
            }
        }

        private static async ETTask OnZhengLiButton(this ES_RoleBag self)
        {
            FlyTipComponent flyTipComponent = self.Root().GetComponent<FlyTipComponent>();
            int errorCode = await BagClientNetHelper.RequestSortByLoc(self.Root(), ItemLocType.ItemLocBag);
            if (errorCode == ErrorCode.ERR_Success)
            {
                flyTipComponent.ShowFlyTip("整理完成!");
            }
        }

        private static void OnOneSellButton(this ES_RoleBag self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "一键出售", "是否一键出售低品质装备和宝石，出售品质可以在设置中进行选择。",
                        () => { BagClientNetHelper.RequestOneSell(self.Root(), ItemLocType.ItemLocBag).Coroutine(); }, null)
                    .Coroutine();
        }
    }
}
