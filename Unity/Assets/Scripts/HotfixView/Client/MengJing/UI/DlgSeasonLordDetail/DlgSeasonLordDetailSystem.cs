using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(ES_CommonItem))]
    [FriendOf(typeof(DlgSeasonLordDetail))]
    public static class DlgSeasonLordDetailSystem
    {
        public static void RegisterUIEvent(this DlgSeasonLordDetail self)
        {
            self.View.E_UseItemBtnButton.AddListenerAsync(self.OnUseItemBtnButton);
            self.View.E_CloseBtnButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SeasonLordDetail);
            });

            self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            
            self.UpdateInfo();
            self.UpdateItemList();
            self.UpdateTime().Coroutine();
        }

        public static void ShowWindow(this DlgSeasonLordDetail self, Entity contextData = null)
        {
        }

        public static async ETTask OnUseItemBtnButton(this DlgSeasonLordDetail self)
        {
            if (self.BagInfo == null)
            {
                FlyTipComponent.Instance.ShowFlyTip("未选择道具！");
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            long now = TimeHelper.ServerNow();
            long end = numericComponent.GetAsLong(NumericType.SeasonBossRefreshTime);
            if (end - now <= 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("赛季首领已经出现！");
                return;
            }

            List<long> fruidids = new List<long>();
            fruidids.Add(self.BagInfo.BagInfoID);
            C2M_SeasonUseFruitRequest reuqest = new() { BagInfoIDs = fruidids };
            M2C_SeasonUseFruitResponse response = (M2C_SeasonUseFruitResponse)await self.Root().GetComponent<ClientSenderCompnent>().Call(reuqest);

            if (response.Error == ErrorCode.ERR_Success)
            {
                FlyTipComponent.Instance.ShowFlyTip("使用成功！");
                self.BagInfo = null;
                self.View.ES_CommonItem.uiTransform.gameObject.SetActive(false);
                self.View.E_ItemNameTextText.text = string.Empty;
                self.View.E_ItemDesTextText.text = string.Empty;
                self.UpdateItemList();
            }
        }

        public static void UpdateInfo(this DlgSeasonLordDetail self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();

            int fubenid = numericComponent.GetAsInt(NumericType.SeasonBossFuben);;
            DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(fubenid);
            using (zstring.Block())
            {
                self.View.E_PositionTextText.text = zstring.Format("即将出现在{0}中...", dungeonConfig.ChapterName);
            }

            int bossId = ConfigData.SeasonBossId;
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(bossId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.MonsterIcon, monsterConfig.MonsterHeadIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.View.E_MonsterHeadImgImage.sprite = sp;
        }

        private static void OnBagItemsRefresh(this DlgSeasonLordDetail self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(index < self.ShowBagInfos.Count ? self.ShowBagInfos[index] : null, ItemOperateEnum.None, self.OnSelect);
        }

        public static void UpdateItemList(this DlgSeasonLordDetail self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();

            self.ShowBagInfos.Clear();
            List<ItemInfo> bagInfos = bagComponent.GetItemsByLoc(ItemLocType.ItemLocBag);
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.ItemType == ItemTypeEnum.Consume && itemConfig.ItemSubType == 132)
                {
                    self.ShowBagInfos.Add(bagInfos[i]);
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count >= 10 ? self.ShowBagInfos.Count : 10);
            self.View.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count >= 10 ? self.ShowBagInfos.Count : 10);
        }

        public static void OnSelect(this DlgSeasonLordDetail self, ItemInfo bagInfo)
        {
            self.BagInfo = bagInfo;
            ItemInfo bagInfoNew = new ItemInfo();
            bagInfoNew.ItemID = bagInfo.ItemID;
            bagInfoNew.ItemNum = 1;
            self.View.ES_CommonItem.UpdateItem(bagInfoNew, ItemOperateEnum.None);
            self.View.ES_CommonItem.uiTransform.gameObject.SetActive(true);
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            self.View.E_ItemNameTextText.text = itemConfig.ItemName;
            self.View.E_ItemDesTextText.text = itemConfig.ItemDes;

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

        public static async ETTask UpdateTime(this DlgSeasonLordDetail self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();

            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (!self.IsDisposed)
            {
                long now = TimeHelper.ServerNow();
                long end = numericComponent.GetAsLong(NumericType.SeasonBossRefreshTime);
                if (end - now > 0)
                {
                    DateTime nowTime = TimeInfo.Instance.ToDateTime(now);
                    DateTime endTime = TimeInfo.Instance.ToDateTime(end);
                    TimeSpan ts = endTime - nowTime;
                    using (zstring.Block())
                    {
                        self.View.E_RefreshTimeTextText.text = zstring.Format("剩余时间:{0}天{1}时{2}分{3}秒", ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
                    }
                }
                else
                {
                    self.View.E_RefreshTimeTextText.text = "出现!!";
                }

                await timerComponent.WaitAsync(1000);
                if (self.IsDisposed)
                {
                    break;
                }
            }
        }
    }
}
