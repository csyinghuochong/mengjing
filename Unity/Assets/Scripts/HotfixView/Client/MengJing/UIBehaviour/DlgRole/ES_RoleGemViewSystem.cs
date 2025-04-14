using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_RoleGemHole))]
    [FriendOf(typeof(ES_CommonItem))]
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof(ES_RoleGem))]
    [FriendOfAttribute(typeof(ES_RoleGem))]
    public static partial class ES_RoleGemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleGem self, Transform transform)
        {
            self.uiTransform = transform;

            self.ItemDiList.Add(self.E_ItemDi_1Image.gameObject);
            self.ItemDiList.Add(self.E_ItemDi_2Image.gameObject);
            self.ItemDiList.Add(self.E_ItemDi_3Image.gameObject);
            self.ItemDiList.Add(self.E_ItemDi_4Image.gameObject);
            self.GemHoleList.Add(self.ES_RoleGemHole_0);
            self.GemHoleList.Add(self.ES_RoleGemHole_1);
            self.GemHoleList.Add(self.ES_RoleGemHole_2);
            self.GemHoleList.Add(self.ES_RoleGemHole_3);

            self.ES_CommonItem.uiTransform.gameObject.SetActive(false);

            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
            self.XiangQianIndex = -1;
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleGem self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this ES_RoleGem self)
        {
            self.XiangQianItem = null;
            self.XiangQianIndex = -1;
            self.ResetHole();
            self.RefreshBagItems();
            self.ES_CommonItem.uiTransform.gameObject.SetActive(false);
        }

        public static void OnUpdateLastItem(this ES_RoleGem self)
        {
            ItemInfo itemInfo = self.Root().GetComponent<BagComponentC>().GetBagInfo(self.ItemBagInfoID);
            self.OnClickXiangQianItem(itemInfo);
            self.RefreshBagItems();
        }

        private static void OnItemTypeSet(this ES_RoleGem self, int index)
        {
            self.CurrentItemType = index;
            self.RefreshBagItems();
        }

        private static void OnBagItemsRefresh(this ES_RoleGem self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(index < self.ShowBagInfos.Count ? self.ShowBagInfos[index] : null, ItemOperateEnum.XiangQianBag,
                self.UpdateSelect);
        }

        public static void RefreshBagItems(this ES_RoleGem self)
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

            int maxCount = GlobalValueConfigCategory.Instance.BagMaxCapacity;
            self.ShowBagInfos.AddRange(bagComponentC.GetItemsByType(itemTypeEnum));
            self.AddUIScrollItems(ref self.ScrollItemCommonItems, maxCount);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, maxCount);

            if (self.XiangQianItem != null)
            {
                ItemInfo bagInfo = self.Root().GetComponent<BagComponentC>().GetBagInfo(self.XiangQianItem.BagInfoID);
                self.OnClickXiangQianItem(bagInfo);
            }
        }

        private static void UpdateSelect(this ES_RoleGem self, ItemInfo bagInfo)
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

        private static void ResetHole(this ES_RoleGem self)
        {
            for (int i = 0; i < self.GemHoleList.Count; i++)
            {
                ES_RoleGemHole esRoleGemHole = self.GemHoleList[i];
                esRoleGemHole.OnUpdateUI(0, 0, -1);
            }
        }

        public static void OnClickXiangQianItem(this ES_RoleGem self, ItemInfo info)
        {
            self.XiangQianItem = null;
            self.XiangQianIndex = -1;
            self.ResetHole();

            if (info == null)
            {
                return;
            }

            self.XiangQianItem = info;
            self.ItemBagInfoID = info.BagInfoID;

            self.ES_CommonItem.uiTransform.gameObject.SetActive(true);
            self.ES_CommonItem.UpdateItem(info, ItemOperateEnum.None);
            self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
            self.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);

            info.GemHole = string.IsNullOrEmpty(info.GemHole) ? "" : info.GemHole;
            info.GemIDNew = string.IsNullOrEmpty(info.GemIDNew) ? "" : info.GemIDNew;
            string[] gemHoles = info.GemHole.Split('_');
            string[] gemIds = info.GemIDNew.Split('_');

            for (int i = 0; i < 4; i++)
            {
                int gemHoleId = (gemHoles.Length > i && gemHoles[i] != "") ? int.Parse(gemHoles[i]) : 0;
                int gemId = (gemIds.Length > i && gemIds[i] != "") ? int.Parse(gemIds[i]) : 0;

                self.ItemDiList[i].SetActive(gemHoleId == 0);

                ES_RoleGemHole esRoleGemHole = self.GemHoleList[i];
                esRoleGemHole.OnUpdateUI(gemHoleId, gemId, i);
                esRoleGemHole.SetClickHandler(self.OnSetHoleIndex);
            }
        }

        public static void OnSetHoleIndex(this ES_RoleGem self, int index)
        {
            self.XiangQianIndex = index;
            for (int i = 0; i < self.GemHoleList.Count; i++)
            {
                ES_RoleGemHole esRoleGemHole = self.GemHoleList[i];
                esRoleGemHole.SetSelected(i == index);
            }
        }
    }
}