using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_CommonItem))]
    [FriendOf(typeof (Scroll_Item_CommonItem))]
    [EntitySystemOf(typeof (ES_RoleGem))]
    [FriendOfAttribute(typeof (ES_RoleGem))]
    public static partial class ES_RoleGemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleGem self, Transform transform)
        {
            self.uiTransform = transform;

            self.GemHoleList.Add(self.ES_RoleGemHole_0);
            self.GemHoleList.Add(self.ES_RoleGemHole_1);
            self.GemHoleList.Add(self.ES_RoleGemHole_2);
            self.GemHoleList.Add(self.ES_RoleGemHole_3);

            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.E_AllToggle.IsSelected(true);
            self.XiangQianIndex = -1;
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleGem self)
        {
            self.DestroyWidget();
        }

        private static void OnItemTypeSet(this ES_RoleGem self, int index)
        {
            UICommonHelper.SetToggleShow(self.E_AllToggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.E_EquipToggle.gameObject, index == 1);
            UICommonHelper.SetToggleShow(self.E_CaiLiaoToggle.gameObject, index == 2);
            UICommonHelper.SetToggleShow(self.E_XiaoHaoToggle.gameObject, index == 3);

            self.CurrentItemType = index;
            self.RefreshBagItems();
        }

        private static void OnBagItemsRefresh(this ES_RoleGem self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(index < self.ShowBagInfos.Count? self.ShowBagInfos[index] : null, ItemOperateEnum.Bag, self.UpdateSelect);
        }

        public static void RefreshBagItems(this ES_RoleGem self)
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
            self.AddUIScrollItems(ref self.ScrollItemCommonItems, maxCount);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, maxCount);
        }

        private static void UpdateSelect(this ES_RoleGem self, BagInfo bagInfo)
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

        private static void ResetHole(this ES_RoleGem self)
        {
            for (int i = 0; i < self.GemHoleList.Count; i++)
            {
                self.GemHoleList[i].OnUpdateUI(0, 0, -1);
            }
        }

        public static void OnUpdateUI(this ES_RoleGem self)
        {
            self.XiangQianItem = null;
            self.XiangQianIndex = -1;
            self.ResetHole();
            self.RefreshBagItems();
            self.ES_CommonItem.uiTransform.gameObject.SetActive(false);
        }

        public static void OnClickXiangQianItem(this ES_RoleGem self, BagInfo info)
        {
            self.XiangQianItem = info;
            if (info == null)
            {
                self.ResetHole();
                return;
            }

            self.ES_CommonItem.uiTransform.gameObject.SetActive(true);
            self.ES_CommonItem.UpdateItem(info, ItemOperateEnum.None);

            info.GemHole = string.IsNullOrEmpty(info.GemHole)? "" : info.GemHole;
            info.GemIDNew = string.IsNullOrEmpty(info.GemIDNew)? "" : info.GemIDNew;
            string[] gemHoles = info.GemHole.Split('_');
            string[] gemIds = info.GemIDNew.Split('_');

            for (int i = 0; i < 4; i++)
            {
                int gemHoleId = (gemHoles.Length > i && gemHoles[i] != "")? int.Parse(gemHoles[i]) : 0;
                int gemId = (gemIds.Length > i && gemIds[i] != "")? int.Parse(gemIds[i]) : 0;

                self.GemHoleList[i].OnUpdateUI(gemHoleId, gemId, i);
                self.GemHoleList[i].SetClickHandler(self.OnSetHoleIndex);
            }
        }

        public static void OnSetHoleIndex(this ES_RoleGem self, int index)
        {
            self.XiangQianIndex = index;
            for (int i = 0; i < self.GemHoleList.Count; i++)
            {
                self.GemHoleList[i].SetSelected(i == index);
            }
        }
    }
}