using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(ES_CommonItem))]
    [FriendOf(typeof(DlgSeasonLordDetail))]
    public static class DlgSeasonLordDetailSystem
    {
        public static void RegisterUIEvent(this DlgSeasonLordDetail self)
        {
            self.View.E_UseItemBtnButton.AddListenerAsync(self.OnUseItemBtn);
            self.View.E_CloseBtnButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SeasonLordDetail);
            });

            self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
        }

        public static void ShowWindow(this DlgSeasonLordDetail self, Entity contextData = null)
        {
            self.UpdateInfo();
            self.UpdateItemList();
            self.UpdateTime().Coroutine();
        }

        public static async ETTask OnUseItemBtn(this DlgSeasonLordDetail self)
        {
            if (self.BagInfo == null)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("未选择道具！");
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            long now = TimeHelper.ServerNow();
            long end = numericComponent.GetAsLong(NumericType.SeasonBossRefreshTime);
            if (end - now <= 0)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("赛季首领已经出现！");
                return;
            }

            List<long> fruidids = new List<long>();
            fruidids.Add(self.BagInfo.BagInfoID);
            C2M_SeasonUseFruitRequest reuqest = new() { BagInfoIDs = fruidids };
            M2C_SeasonUseFruitResponse response = (M2C_SeasonUseFruitResponse)await self.Root().GetComponent<ClientSenderCompnent>().Call(reuqest);

            if (response.Error == ErrorCode.ERR_Success)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("使用成功！");
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

            // int fubenid = numericComponent.GetAsInt(NumericType.SeasonBossFuben);
            int fubenid = 10001;
            DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(fubenid);
            self.View.E_PositionTextText.text = $"即将出现在{dungeonConfig.ChapterName}中...";

            int bossId = SeasonHelper.SeasonBossId;
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(bossId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.MonsterIcon, monsterConfig.MonsterHeadIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.View.E_MonsterHeadImgImage.sprite = sp;
        }

        private static void OnBagItemsRefresh(this DlgSeasonLordDetail self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(index < self.ShowBagInfos.Count ? self.ShowBagInfos[index] : null, ItemOperateEnum.None, self.OnSelect);
        }

        public static void UpdateItemList(this DlgSeasonLordDetail self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();

            self.ShowBagInfos.Clear();
            List<BagInfo> bagInfos = bagComponent.GetItemsByLoc(ItemLocType.ItemLocBag);
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

        public static void OnSelect(this DlgSeasonLordDetail self, BagInfo bagInfo)
        {
            self.BagInfo = bagInfo;
            BagInfo bagInfoNew = BagInfo.Create();
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

                    item.ES_CommonItem.SetSelected(bagInfo);
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
                    self.View.E_RefreshTimeTextText.text = $"剩余时间:{ts.Days}天{ts.Hours}时{ts.Minutes}分{ts.Seconds}秒";
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