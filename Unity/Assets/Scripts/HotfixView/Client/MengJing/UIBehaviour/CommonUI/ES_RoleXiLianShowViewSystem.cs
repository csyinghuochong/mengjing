using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_EquipSet))]
    [EntitySystemOf(typeof (ES_RoleXiLianShow))]
    [FriendOfAttribute(typeof (ES_RoleXiLianShow))]
    public static partial class ES_RoleXiLianShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleXiLianShow self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            BagInfo bagInfo = bagComponent.GetEquipBySubType(ItemLocType.ItemLocEquip, (int)ItemSubTypeEnum.Wuqi);
            self.ES_EquipSet.PlayerLv(userInfo.Lv);
            self.ES_EquipSet.PlayerName(userInfo.Name);
            self.ES_EquipSet.ShowPlayerModel(bagInfo, userInfo.Occ, unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.EquipIndex),
                bagComponent.FashionEquipList);
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleXiLianShow self)
        {
            self.DestroyWidget();
        }

        private static void OnItemTypeSet(this ES_RoleXiLianShow self, int index)
        {
            UICommonHelper.SetToggleShow(self.E_1Toggle.gameObject, index == 0);
            UICommonHelper.SetToggleShow(self.E_2Toggle.gameObject, index == 1);

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            switch (index)
            {
                case 0:
                    self.ES_EquipSet.uiTransform.gameObject.SetActive(true);
                    self.E_EquipItemsLoopVerticalScrollRect.gameObject.SetActive(false);

                    self.ES_EquipSet.PlayShowIdelAnimate(null);
                    self.ES_EquipSet.RefreshEquip(bagComponent.GetItemsByLoc(ItemLocType.ItemLocEquip),
                        bagComponent.GetItemsByLoc(ItemLocType.ItemLocEquip_2), userInfoComponent.UserInfo.Occ, ItemOperateEnum.Juese);
                    self.ES_EquipSet.SetCallBack(self.OnSelectItem);

                    break;
                case 1:
                    self.ES_EquipSet.uiTransform.gameObject.SetActive(false);
                    self.E_EquipItemsLoopVerticalScrollRect.gameObject.SetActive(true);

                    break;
            }

            self.CurrentItemType = index;
        }

        private static void OnSelectItem(this ES_RoleXiLianShow self, BagInfo bagInfo)
        {
            self.XilianBagInfo = bagInfo;

            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item == null)
                {
                    continue;
                }

                item.UpdateSelectStatus(bagInfo);
            }

            self.OnUpdateXinLian();
        }

        private static void OnUpdateXinLian(this ES_RoleXiLianShow self)
        {
        }
    }
}