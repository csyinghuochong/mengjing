using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgCellDungeonSettlement))]
    public static class DlgCellDungeonSettlementSystem
    {
        public static void RegisterUIEvent(this DlgCellDungeonSettlement self)
        {
            self.View.E_closeButtonButton.AddListener(()=> { self.OnCloseButton().Coroutine(); });
            self.View.E_Star_1_liangImage.gameObject.SetActive(false);
            self.View.E_Star_2_liangImage.gameObject.SetActive(false);
            self.View.E_Star_3_liangImage.gameObject.SetActive(false);
            self.View.EG_SelectEffectSetRectTransform.gameObject.SetActive(false);
        }

        public static void ShowWindow(this DlgCellDungeonSettlement self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgCellDungeonSettlement self)
        {
        }

        private static async ETTask OnCloseButton(this DlgCellDungeonSettlement self)
        {
            if (TimeHelper.ClientNow() - self.OpenTime <= 3 * 1000)
            {
                return;
            }


            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CellDungeonSettlementSelectReward);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgCellDungeonSettlementSelectReward>().OnUpdateUI(self.m2C_FubenSettlement).Coroutine();

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CellDungeonSettlement);
        }

        public static async ETTask OnUpdateUI(this DlgCellDungeonSettlement self, M2C_FubenSettlement m2C_FubenSettlement)
        {
            self.m2C_FubenSettlement = m2C_FubenSettlement;
            self.OpenTime = TimeHelper.ClientNow();
            
            // self.View.E_Text_expText.text = m2C_FubenSettlement.RewardExp.ToString();
            // self.View.E_Text_goldText.text = m2C_FubenSettlement.RewardGold.ToString();
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            string prefabPath = "Assets/Bundles/UI/Item/Item_CommonItem.prefab";
            GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(prefabPath);
            
            GameObject gameObject2 = UnityEngine.Object.Instantiate(prefab, self.View.E_RewardListScrollRect.transform.Find("Content").gameObject.transform);
            Scroll_Item_CommonItem item2 = self.AddChild<Scroll_Item_CommonItem>();
            item2.BindTrans(gameObject2.transform);
            ItemInfo bagInfo2 = new ItemInfo();
            bagInfo2.ItemID = 2;
            bagInfo2.ItemNum = 0;
            item2.Refresh(bagInfo2, ItemOperateEnum.None);
            item2.E_ItemNumText.text = ShowNum(m2C_FubenSettlement.RewardExp);
            
            GameObject gameObject1 = UnityEngine.Object.Instantiate(prefab, self.View.E_RewardListScrollRect.transform.Find("Content").gameObject.transform);
            Scroll_Item_CommonItem item1 = self.AddChild<Scroll_Item_CommonItem>();
            item1.BindTrans(gameObject1.transform);
            ItemInfo bagInfo1 = new ItemInfo();
            bagInfo1.ItemID = 1;
            bagInfo1.ItemNum = 0;
            item1.Refresh(bagInfo1, ItemOperateEnum.None);
            item1.E_ItemNumText.text = ShowNum(m2C_FubenSettlement.RewardGold);

            string ShowNum(int num)
            {
                if (num < 1000)
                {
                    return num.ToString();
                }
                else if(num < 10000)
                {
                    return $"{num / 1000}千+";
                }
                else
                {
                    return $"{num / 10000}万+";
                }
            }

            self.View.E_Star_3_OKImage.gameObject.SetActive(m2C_FubenSettlement.StarInfos[2] == 1);
            self.View.E_Star_2_OKImage.gameObject.SetActive(m2C_FubenSettlement.StarInfos[1] == 1);
            self.View.E_Star_1_OKImage.gameObject.SetActive(m2C_FubenSettlement.StarInfos[0] == 1);

            long instanceid = self.InstanceId;
            await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            if (instanceid != self.InstanceId)
                return;
            self.View.E_Star_1_liangImage.gameObject.SetActive(m2C_FubenSettlement.StarInfos[0] == 1);
            await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            if (instanceid != self.InstanceId)
                return;
            self.View.E_Star_2_liangImage.gameObject.SetActive(m2C_FubenSettlement.StarInfos[1] == 1);
            await self.Root().GetComponent<TimerComponent>().WaitAsync(1000);
            if (instanceid != self.InstanceId)
                return;
            self.View.E_Star_3_liangImage.gameObject.SetActive(m2C_FubenSettlement.StarInfos[2] == 1);
        }
    }
}