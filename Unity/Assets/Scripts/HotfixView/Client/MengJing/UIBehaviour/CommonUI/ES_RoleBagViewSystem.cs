using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof (ES_RoleBag))]
    [FriendOfAttribute(typeof (ES_RoleBag))]
    public static partial class ES_RoleBagSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleBag self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.E_ZhengLiButton.AddListenerAsync(self.OnZhengLiButton);
            self.E_AllToggle.IsSelected(true);
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleBag self)
        {
            self.DestroyWidget();
        }

        private static void OnBagItemsRefresh(this ES_RoleBag self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(index < self.ShowBagInfos.Count? self.ShowBagInfos[index] : null, ItemOperateEnum.Bag, self.UpdateSelect);
        }

        private static void OnItemTypeSet(this ES_RoleBag self, int index)
        {
            UICommonHelper.SetToggleShow(self.E_AllToggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.E_EquipToggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.E_CaiLiaoToggle.gameObject, index == 2);
            UICommonHelper.SetToggleShow(self.E_XiaoHaoToggle.gameObject, index == 3);

            self.CurrentItemType = index;
            self.RefreshBagItems();
        }

        public static void RefreshBagItems(this ES_RoleBag self)
        {
            BagComponent_C bagComponentC = self.Root().GetComponent<BagComponent_C>();

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

            int maxCount = GlobalValueConfigCategory.Instance.BagMaxCapacity;
            self.ShowBagInfos.AddRange(bagComponentC.GetItemsByType(itemTypeEnum));
            self.AddUIScrollItems(ref self.ScrollItemCommonItems, maxCount);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, maxCount);
        }

        private static void UpdateSelect(this ES_RoleBag self, BagInfo bagInfo)
        {
            for (int i = 0; i < self.ScrollItemCommonItems.Keys.Count - 1; i++)
            {
                // 滚动组件的子物体是动态从对象池里拿的，只引用看的到的
                if (self.ScrollItemCommonItems[i].uiTransform != null)
                {
                    self.ScrollItemCommonItems[i].UpdateSelectStatus(bagInfo);
                }
            }
        }

        private static async ETTask OnZhengLiButton(this ES_RoleBag self)
        {
            FlyTipComponent flyTipComponent = self.Root().GetComponent<FlyTipComponent>();
            int errorCode = await BagClientNetHelper.RequestSortByLoc(self.Root(), ItemLocType.ItemLocBag);
            if (errorCode == ErrorCode.ERR_Success)
            {
                flyTipComponent.SpawnFlyTipDi("整理完成!");
            }
        }
    }
}