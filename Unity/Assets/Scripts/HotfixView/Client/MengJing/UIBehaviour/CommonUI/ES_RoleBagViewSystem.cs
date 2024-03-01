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
            scrollItemBagItem.Refresh(self.ShowBagInfos[index]);
        }

        private static void OnItemTypeSet(this ES_RoleBag self, int index)
        {
            Log.Debug($"按下Toggle：{index}");
            self.Root().GetComponent<FlyTipComponent>().SpawnFlyTip($"按下Toggle：{index}");

            self.SetToggleShow(self.E_AllToggle.gameObject, index == 0);
            self.SetToggleShow(self.E_EquipToggle.gameObject, index == 1);
            self.SetToggleShow(self.E_CaiLiaoToggle.gameObject, index == 2);
            self.SetToggleShow(self.E_XiaoHaoToggle.gameObject, index == 3);

            self.CurrentItemType = index;
            self.Refresh();
        }

        private static void SetToggleShow(this ES_RoleBag self, GameObject gameObject, bool isShow)
        {
            gameObject.transform.Find("Background/XuanZhong").gameObject.SetActive(isShow);
            gameObject.transform.Find("Background/WeiXuanZhong").gameObject.SetActive(!isShow);
        }

        private static void Refresh(this ES_RoleBag self)
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

            self.ShowBagInfos.AddRange(bagComponentClient.GetItemsByType(itemTypeEnum));
            self.AddUIScrollItems(ref self.ScrollItemBagItems, self.ShowBagInfos.Count);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }
    }
}