using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(ES_CommonItem))]
    [EntitySystemOf(typeof(ES_RoleXiLianInherit))]
    [FriendOfAttribute(typeof(ES_RoleXiLianInherit))]
    public static partial class ES_RoleXiLianInheritSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleXiLianInherit self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.E_XiLianButtonButton.AddListener(() => { self.OnXiLianButton(1).Coroutine(); });

            self.ES_CommonItem_Cost.uiTransform.gameObject.SetActive(false);
            self.InitSubItemUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleXiLianInherit self)
        {
            self.DestroyWidget();
        }

        private static void OnBagItemsRefresh(this ES_RoleXiLianInherit self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.ItemXiLian, self.OnSelectItem);
        }

        public static void OnUpdateUI(this ES_RoleXiLianInherit self)
        {
            self.XilianBagInfo = null;
            self.OnEquiListUpdate();
        }

        public static void UpdateAttribute(this ES_RoleXiLianInherit self, ItemInfo bagInfo)
        {
            CommonViewHelper.DestoryChild(self.EG_EquipBaseSetListRectTransform.gameObject);
            if (bagInfo == null)
            {
                return;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            ItemViewHelp.ShowBaseAttribute(bagComponent.GetEquipList(), bagInfo, self.E_Obj_EquipPropertyTextText.gameObject,
                self.EG_EquipBaseSetListRectTransform.gameObject);
        }

        public static void OnUpdateXinLian(this ES_RoleXiLianInherit self)
        {
            ItemInfo bagInfo = self.XilianBagInfo;
            self.ES_CommonItem_Cost.uiTransform.gameObject.SetActive(bagInfo != null);
            self.UpdateAttribute(bagInfo);
            if (bagInfo == null)
            {
                return;
            }

            self.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            self.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);

            //洗炼消耗
            string[] costitem = ItemHelper.GetInheritCost(bagInfo.InheritTimes).Split(';');
            int costitemid = int.Parse(costitem[0]);
            int constitemnumber = int.Parse(costitem[1]);
            ItemInfo bagInfoNeed = new() { ItemID = costitemid, ItemNum = constitemnumber };

            self.ES_CommonItem_Cost.UpdateItem(bagInfoNeed, ItemOperateEnum.None);
            self.ES_CommonItem_Cost.E_ItemNumText.gameObject.SetActive(false);

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            using (zstring.Block())
            {
                self.E_Text_CostValueText.text = zstring.Format("{0}/{1}", bagComponent.GetItemNumber(costitemid), constitemnumber);
            }

            self.E_Text_CostValueText.color = bagComponent.GetItemNumber(int.Parse(costitem[0])) >= int.Parse(costitem[1]) ? Color.green : Color.red;

            self.E_Text_CostNameText.text = ItemConfigCategory.Instance.Get(bagInfoNeed.ItemID).ItemName;
            self.E_Text_CostNameText.color = FunctionUI.QualityReturnColorDi((int)ItemConfigCategory.Instance.Get(bagInfoNeed.ItemID).ItemQuality);
            if (bagComponent.GetItemNumber(int.Parse(costitem[0])) >= int.Parse(costitem[1]))
            {
                self.E_Text_CostValueText.color = Color.green;
            }

            int maxTimes = GlobalValueConfigCategory.Instance.ItemInheritTime;
            self.E_ProgressBarImgImage.fillAmount = bagInfo.InheritTimes * 1f / maxTimes;
            using (zstring.Block())
            {
                self.E_InheritTimesTextText.text = zstring.Format("{0}/{1}次", bagInfo.InheritTimes, maxTimes);
            }
        }

        public static void OnXiLianReturn(this ES_RoleXiLianInherit self)
        {
            self.XilianBagInfo = self.Root().GetComponent<BagComponentC>().GetBagInfo(self.XilianBagInfo.BagInfoID);
            self.OnUpdateXinLian();
            self.OnEquiListUpdate();
        }

        public static void OnEquiListUpdate(this ES_RoleXiLianInherit self)
        {
            List<ItemInfo> equipInfos = self.Root().GetComponent<BagComponentC>().GetItemsByType(ItemTypeEnum.Equipment);

            self.ShowBagInfos.Clear();
            for (int i = 0; i < equipInfos.Count; i++)
            {
                if (equipInfos[i].IfJianDing)
                {
                    continue;
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equipInfos[i].ItemID);
                if (itemConfig.EquipType == 101)
                {
                    continue;
                }

                if (itemConfig.UseLv < 60 && itemConfig.ItemQuality <= 5)
                {
                    continue;
                }

                //饰品不显示
                if (itemConfig.ItemSubType == 5)
                {
                    continue;
                }

                self.ShowBagInfos.Add(equipInfos[i]);
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);

            if (self.XilianBagInfo != null)
            {
                self.OnSelectItem(self.XilianBagInfo);
            }
            else if (self.ShowBagInfos.Count > 0)
            {
                Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[0];
                if (self.ScrollItemCommonItems != null && self.ScrollItemCommonItems.Count > 0 && scrollItemCommonItem.uiTransform != null)
                {
                    scrollItemCommonItem.OnClickUIItem();
                }
            }
        }

        public static void OnSelectItem(this ES_RoleXiLianInherit self, ItemInfo bagInfo)
        {
            self.XilianBagInfo = bagInfo;
            if (self.ScrollItemCommonItems != null)
            {
                foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.SetSelected(bagInfo);
                }
            }

            self.OnUpdateXinLian();
        }

        public static void InitSubItemUI(this ES_RoleXiLianInherit self)
        {
            self.ES_CommonItem_Cost.E_ItemNumText.gameObject.SetActive(false);
            self.ES_CommonItem_Cost.E_ItemNameText.gameObject.SetActive(false);

            ItemInfo bagInfo = self.XilianBagInfo;
            self.ES_CommonItem_Cost.uiTransform.gameObject.SetActive(bagInfo != null);
            if (bagInfo != null)
            {
                self.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
                self.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);
            }
        }

        public static async ETTask OnXiLianButton(this ES_RoleXiLianInherit self, int times)
        {
            ItemInfo bagInfo = self.XilianBagInfo;
            if (bagInfo == null)
            {
                return;
            }

            int maxInheritTimes = GlobalValueConfigCategory.Instance.ItemInheritTime;
            if (bagInfo.InheritTimes >= maxInheritTimes)
            {
                FlyTipComponent.Instance.ShowFlyTip("该装备不可再进行传承鉴定！");
                return;
            }

            string costitem = ItemHelper.GetInheritCost(bagInfo.InheritTimes);
            if (!self.Root().GetComponent<BagComponentC>().CheckNeedItem(costitem))
            {
                FlyTipComponent.Instance.ShowFlyTip("材料不足！");
                return;
            }

            M2C_ItemInheritResponse response = await BagClientNetHelper.ItemInherit(self.Root(), bagInfo.BagInfoID);
            if (response.Error != 0)
            {
                return;
            }

            self.InheritSkills = response.InheritSkills;
            int skillid = response.InheritSkills[0];
            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillid);
            // 二次确认框
            using (zstring.Block())
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "传承鉴定",
                    zstring.Format("传承鉴定效果：{0}\n传承装备只有{1}次重新鉴定传承的机会\n请问是否覆盖原始传承鉴定效果?", skillConfig.SkillDescribe, maxInheritTimes),
                    () => { self.RequestInheritSelect().Coroutine(); }, () => { self.OnXiLianReturn(); }).Coroutine();
            }
        }

        public static async ETTask RequestInheritSelect(this ES_RoleXiLianInherit self)
        {
            ItemInfo bagInfo = self.XilianBagInfo;
            if (bagInfo == null)
            {
                return;
            }

            await BagClientNetHelper.ItemInheritSelect(self.Root(), bagInfo.BagInfoID, self.InheritSkills);

            self.OnXiLianReturn();
        }
    }
}
