using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
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
            Scroll_Item_BagItem scrollItemBagItem = self.ScrollItemBagItems[index].BindTrans(transform);
            scrollItemBagItem.Refresh(index < self.ShowBagInfos.Count? self.ShowBagInfos[index] : null, ItemOperateEnum.Bag, self.UpdateSelect);
        }

        private static void OnItemTypeSet(this ES_RoleBag self, int index)
        {
            UICommonHelper.SetToggleShow(self.E_AllToggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.E_EquipToggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.E_CaiLiaoToggle.gameObject, index == 2);
            UICommonHelper.SetToggleShow(self.E_XiaoHaoToggle.gameObject, index == 3);

            self.CurrentItemType = index;
            self.Refresh();
        }

        public static void Refresh(this ES_RoleBag self)
        {
            self.RefreshBagItems();
        }

        private static void RefreshBagItems(this ES_RoleBag self)
        {
            BagComponentClient bagComponentClient = self.Root().GetComponent<BagComponentClient>();

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
            self.ShowBagInfos.AddRange(bagComponentClient.GetItemsByType(itemTypeEnum));
            self.AddUIScrollItems(ref self.ScrollItemBagItems, maxCount);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, maxCount);
        }

        private static void UpdateSelect(this ES_RoleBag self, BagInfo bagInfo)
        {
            for (int i = 0; i < self.ScrollItemBagItems.Keys.Count - 1; i++)
            {
                self.ScrollItemBagItems[i].UpdateSelectStatus(bagInfo);
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