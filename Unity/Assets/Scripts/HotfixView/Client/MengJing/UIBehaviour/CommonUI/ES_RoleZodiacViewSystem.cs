using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof(ES_RoleZodiac))]
    [FriendOfAttribute(typeof(ES_RoleZodiac))]
    public static partial class ES_RoleZodiacSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleZodiac self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);

            self.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
            self.RefreshBagItems();
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleZodiac self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this ES_RoleZodiac self)
        {
        }

        private static void OnItemTypeSet(this ES_RoleZodiac self, int index)
        {
        }

        public static void RefreshBagItems(this ES_RoleZodiac self)
        {
            BagComponentC bagComponentC = self.Root().GetComponent<BagComponentC>();

            self.ShowBagInfos.Clear();

            int maxCount = GlobalValueConfigCategory.Instance.BagMaxCapacity;
            foreach (ItemInfo itemInfo in bagComponentC.GetItemsByLoc(ItemLocType.ItemLocBag))
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemInfo.ItemID);
                if (itemConfig.ItemType == ItemTypeEnum.Equipment && itemConfig.EquipType == 101)
                {
                    self.ShowBagInfos.Add(itemInfo);
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, maxCount);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, maxCount);
        }

        private static void OnBagItemsRefresh(this ES_RoleZodiac self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(index < self.ShowBagInfos.Count ? self.ShowBagInfos[index] : null, ItemOperateEnum.Bag,
                self.UpdateSelect);
        }

        private static void UpdateSelect(this ES_RoleZodiac self, ItemInfo bagInfo)
        {
            for (int i = 0; i < self.ScrollItemCommonItems.Keys.Count - 1; i++)
            {
                Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[i];
                if (scrollItemCommonItem.uiTransform != null)
                {
                    scrollItemCommonItem.UpdateSelectStatus(bagInfo);
                }
            }
        }
    }
}