using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof(ES_PetChouKa))]
    [FriendOf(typeof(ES_PetChouKa))]
    public static partial class ES_PetChouKaSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetChouKa self, Transform transform)
        {
            self.uiTransform = transform;
            
            self.E_ButtonStopButton.AddListener(() => { self.OnButtonStop().Coroutine(); });
            self.E_ButtonOpenButton.AddListener(() => { self.OnButtonOpen().Coroutine(); });
            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            
            self.OnStopTurn = false;
            self.TargetIndex = 0;
            self.CurrentIndex = 0;
            self.Interval = 100;
            self.E_ImageSelectImage.gameObject.SetActive(false);
            self.E_ButtonOpenButton.gameObject.SetActive(true);
            self.E_ButtonStopButton.gameObject.SetActive(false);
            
            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_PetChouKa self)
        {
            self.DestroyWidget();
        }

        private static void OnBagItemsRefresh(this ES_PetChouKa self, Transform transform, int index)
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
            bagInfo.ItemNum = 1;
            scrollItemCommonItem.Refresh(bagInfo, ItemOperateEnum.None);
            scrollItemCommonItem.E_ItemNumText.gameObject.SetActive(false);
        }

        private static void OnInitUI(this ES_PetChouKa self)
        {
            string[] itemInfo = GlobalValueConfigCategory.Instance.Get(137).Value.Split(';');
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(int.Parse(itemInfo[0]));
            self.E_OpenCostItemIconImage.overrideSprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon));
            self.E_OpenCostNumText.text = itemInfo[1];
            
            self.RewardShowItems.Clear();
            List<RewardItem> droplist = DropHelper.DropIDToShowItem(int.Parse(GlobalValueConfigCategory.Instance.Get(138).Value), 1);
            foreach (RewardItem rewardItem in droplist)
            {
                self.RewardShowItems.Add(rewardItem.ItemID);
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.RewardShowItems.Count);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.RewardShowItems.Count);
        }

        public static async ETTask OnStartTurn(this ES_PetChouKa self)
        {
            long instanceId = self.InstanceId;
            self.CurrentIndex = 0;

            while (!self.OnStopTurn)
            {
                self.E_ImageSelectImage.gameObject.SetActive(true);
                Scroll_Item_CommonItem item = self.ScrollItemCommonItems[self.CurrentIndex];
                if (item.uiTransform != null)
                {
                    CommonViewHelper.SetParent(self.E_ImageSelectImage.gameObject, item.uiTransform.gameObject);
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

        private static async ETTask OnButtonStop(this ES_PetChouKa self)
        {
            if (self.OnStopTurn)
            {
                return;
            }

            self.E_ButtonStopButton.gameObject.SetActive(false);
            self.OnStopTurn = true;
            int targetItem = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>().GetAsInt(NumericType.PetChouKaRewardItemId);
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
            };

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

                self.E_ImageSelectImage.gameObject.SetActive(true);
                Scroll_Item_CommonItem item = self.ScrollItemCommonItems[self.CurrentIndex];
                if (item.uiTransform != null)
                {
                    CommonViewHelper.SetParent(self.E_ImageSelectImage.gameObject, item.uiTransform.gameObject);
                }

                self.CurrentIndex++;
                if (self.CurrentIndex == self.ScrollItemCommonItems.Count)
                {
                    self.CurrentIndex = 0;
                }

                moveNumber--;
                await self.Root().GetComponent<TimerComponent>().WaitAsync(self.Interval); ;
                if (instanceId != self.InstanceId)
                {
                    return;
                }
            }

            await PetNetHelper.RequestPetChouKaEnd(self.Root());

            self.OnStopTurn = false;
            self.E_ButtonOpenButton.gameObject.SetActive(true);
            self.E_ButtonStopButton.gameObject.SetActive(false);
        }

        private static async ETTask OnButtonOpen(this ES_PetChouKa self)
        {
            int error = await PetNetHelper.RequestPetChouKaStart(self.Root());

            if (error != ErrorCode.ERR_Success)
            {
                return;
            }
            
            self.E_ButtonOpenButton.gameObject.SetActive(false);
            self.E_ButtonStopButton.gameObject.SetActive(true);
            
            self.OnStartTurn().Coroutine();
        }
    }
}