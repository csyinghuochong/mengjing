using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(DlgTreasureOpen))]
    public static class DlgTreasureOpenSystem
    {
        public static void RegisterUIEvent(this DlgTreasureOpen self)
        {
            self.View.E_ButtonStopButton.AddListenerAsync(self.OnButtonStop);
            self.View.E_ButtonOpenButton.AddListener(self.OnButtonOpen);
            self.View.E_ButtonCloseButton.AddListener(self.OnButtonClose);
            self.View.E_ButtonDiButton.AddListener(self.OnButtonClose);
            self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            
            self.OnStopTurn = false;
            self.TargetIndex = 0;
            self.CurrentIndex = 0;
            self.Interval = 100;
            self.View.E_ImageSelectImage.gameObject.SetActive(false);
            self.View.E_ButtonOpenButton.gameObject.SetActive(false);
            self.View.E_ButtonStopButton.gameObject.SetActive(false);
        }

        public static void ShowWindow(this DlgTreasureOpen self, Entity contextData = null)
        {
        }

        public static void OnButtonClose(this DlgTreasureOpen self)
        {
            if (self.ifStop)
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TreasureOpen);
            }
        }

        public static void ShotTip(this DlgTreasureOpen self)
        {
            if (self.ifStop == false)
            {
                self.ifStop = true;
                string itemInfo = self.BagInfo.ItemPar.Split('@')[2];
                int itemId = int.Parse(itemInfo.Split(';')[0]);
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemId);
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("获得物品 {0} ×{1}", itemConfig.ItemName, itemInfo.Split(';')[1]));
                }
            }
        }

        private static void OnBagItemsRefresh(this DlgTreasureOpen self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            ItemInfo bagInfo = new ItemInfo();
            bagInfo.ItemID = self.RewardShowItems[index];
            scrollItemCommonItem.Refresh(bagInfo, ItemOperateEnum.None);
            scrollItemCommonItem.E_ItemNumText.gameObject.SetActive(false);
        }

        public static void OnInitUI(this DlgTreasureOpen self, ItemInfo bagInfo)
        {
            self.BagInfo = bagInfo;

            // $"{dungeonid}@{"TaskMove_6"}@{11;1}";
            //self.BagInfo.ItemPar.Split('@')[1]

            string rewardStr = bagInfo.ItemPar.Split('@')[2];
            string rewardItemID = rewardStr.Split(';')[0];

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            int num = RandomHelper.NextInt(10, 15);
            List<int> rewardItems = DropHelper.TreasureDropItmeShow(int.Parse(itemConfig.ItemUsePar), num);

            int dungeonid = int.Parse(bagInfo.ItemPar.Split('@')[0]);

            int baotutype = 1;
            
            if (itemConfig.ItemQuality == 4)
            {
                baotutype = 1;
            }

            if (itemConfig.ItemQuality == 5)
            {
                baotutype = 2;
            }

            int dropID2 = CommonHelp.TreasureToDropID(dungeonid, self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv, baotutype);
            List<int> rewardItemsTeShu = DropHelper.TreasureDropItmeShow(dropID2, 27 - num);
            rewardItems.AddRange(rewardItemsTeShu);

            //Log.Info("rewardItems = " + rewardItems.Count);
            bool ifAddStatus = false;

            self.RewardShowItems.Clear();
            for (int i = 0; i < rewardItems.Count; i++)
            {
                //每次添加5%概率添加
                if (RandomHelper.RandFloat01() <= 0.05f && ifAddStatus == false)
                {
                    ifAddStatus = true;
                    self.RewardShowItems.Add(int.Parse(rewardItemID));
                    //Log.Info("rewardItemID = " + rewardItemID);
                }

                self.RewardShowItems.Add(rewardItems[i]);
            }

            if (ifAddStatus == false)
            {
                ifAddStatus = true;
                self.RewardShowItems.Add(int.Parse(rewardItemID));
                //Log.Info("rewardItemID222 = " + rewardItemID);
            }

            //Log.Info("rewardShowItems.Count = " + rewardShowItems.Count);

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.RewardShowItems.Count);
            self.View.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.RewardShowItems.Count);

            //开始触发
            self.OnButtonOpen();
        }

        public static async ETTask OnStartTurn(this DlgTreasureOpen self)
        {
            long instanceId = self.InstanceId;
            self.CurrentIndex = 0;

            while (!self.OnStopTurn)
            {
                self.View.E_ImageSelectImage.gameObject.SetActive(true);
                Scroll_Item_CommonItem item = self.ScrollItemCommonItems[self.CurrentIndex];
                if (item.uiTransform != null)
                {
                    CommonViewHelper.SetParent(self.View.E_ImageSelectImage.gameObject, item.uiTransform.gameObject);
                }

                self.CurrentIndex++;
                if (self.CurrentIndex == self.ScrollItemCommonItems.Count)
                {
                    self.CurrentIndex = 0;
                }

                await self.Root().GetComponent<TimerComponent>().WaitAsync(self.Interval);
                if (instanceId != self.InstanceId)
                {
                    return;
                }
            }
        }

        public static async ETTask OnButtonStop(this DlgTreasureOpen self)
        {
            if (self.OnStopTurn)
            {
                return;
            }

            self.View.E_ButtonStopButton.gameObject.SetActive(false);
            self.OnStopTurn = true;
            int targetItem = int.Parse(self.BagInfo.ItemPar.Split('@')[2].Split(';')[0]);
            for (int i = 0; i < self.ScrollItemCommonItems.Count; i++)
            {
                Scroll_Item_CommonItem item = self.ScrollItemCommonItems[i];
                if (item.uiTransform != null)
                {
                    if (item.Baginfo.ItemID == targetItem)
                    {
                        self.TargetIndex = i;
                        break;
                    }
                }
            }

            int moveNumber = 0;
            if (self.TargetIndex > self.CurrentIndex)
            {
                moveNumber = self.TargetIndex - self.CurrentIndex;
            }
            else
            {
                moveNumber = self.TargetIndex + self.ScrollItemCommonItems.Count - self.CurrentIndex;
            }

            long instanceId = self.InstanceId;
            while (moveNumber >= 0)
            {
                if (moveNumber < 5)
                {
                    self.Interval += 50;
                }

                self.View.E_ImageSelectImage.gameObject.SetActive(true);
                Scroll_Item_CommonItem item = self.ScrollItemCommonItems[self.CurrentIndex];
                if (item.uiTransform != null)
                {
                    CommonViewHelper.SetParent(self.View.E_ImageSelectImage.gameObject, item.uiTransform.gameObject);
                }

                self.CurrentIndex++;
                if (self.CurrentIndex == self.ScrollItemCommonItems.Count)
                {
                    self.CurrentIndex = 0;
                }

                moveNumber--;
                await self.Root().GetComponent<TimerComponent>().WaitAsync(self.Interval);
                //Log.Debug($" self.Interval:  {self.Interval}   {moveNumber}");
                if (instanceId != self.InstanceId)
                {
                    return;
                }
            }
            
            self.Root().GetComponent<BagComponentC>().RealAddItem--;
            M2C_ItemOperateResponse response = await BagClientNetHelper.RequestUseItem(self.Root(), self.BagInfo);
            self.Root().GetComponent<BagComponentC>().RealAddItem++;
            if (response.Error == ErrorCode.ERR_Success)
            {
                 self.ShotTip();
            }

            await self.Root().GetComponent<TimerComponent>().WaitAsync(3000);
            //Log.Debug($" self.Interval:  {self.Interval}   {moveNumber}");
            if (instanceId != self.InstanceId)
            {
                return;
            }

            self.OnButtonClose();
        }

        public static void OnButtonOpen(this DlgTreasureOpen self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("背包空间不足！");
                return;
            }

            self.OnStartTurn().Coroutine();
            self.View.E_ButtonStopButton.gameObject.SetActive(true);
        }
    }
}