using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_CommonItem))]
    [FriendOf(typeof (ES_CommonItem))]
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
            self.E_EquipItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.E_XiLianButtonButton.AddListener(() => { self.OnXiLianButton(1).Coroutine(); });
            self.E_XiLianTenButton.AddListener(() => { self.OnXiLianButton(5).Coroutine(); });
            self.E_Btn_XiLianNumRewardButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_RoleXiLianNumReward).Coroutine();
            });
            self.E_Btn_XiLianExplainButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_RoleXiLianExplain).Coroutine();
            });

            self.E_NeedDiamondText.text = GlobalValueConfigCategory.Instance.Get(73).Value;

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            BagInfo bagInfo = bagComponent.GetEquipBySubType(ItemLocType.ItemLocEquip, (int)ItemSubTypeEnum.Wuqi);
            self.ES_EquipSet.PlayerLv(userInfo.Lv);
            self.ES_EquipSet.PlayerName(userInfo.Name);
            self.ES_EquipSet.ShowPlayerModel(bagInfo, userInfo.Occ, unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.EquipIndex),
                bagComponent.FashionEquipList);

            self.ES_CommonItem.uiTransform.gameObject.SetActive(false);
            self.ES_CommonItem_Cost.uiTransform.gameObject.SetActive(false);
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleXiLianShow self)
        {
            self.DestroyWidget();
        }

        private static void OnItemTypeSet(this ES_RoleXiLianShow self, int index)
        {
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

                    self.ShowBagInfos.Clear();
                    List<BagInfo> equipInfos = bagComponent.GetItemsByType(ItemTypeEnum.Equipment);
                    for (int i = 0; i < equipInfos.Count; i++)
                    {
                        if (equipInfos[i].IfJianDing)
                        {
                            continue;
                        }

                        ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equipInfos[i].ItemID);
                        if (itemConfig.EquipType == 101 || itemConfig.EquipType == 201)
                        {
                            continue;
                        }

                        self.ShowBagInfos.Add(equipInfos[i]);
                    }

                    self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
                    self.E_EquipItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);

                    if (self.XilianBagInfo != null)
                    {
                        self.OnSelectItem(self.XilianBagInfo);
                    }
                    else if (self.ShowBagInfos.Count > 0)
                    {
                        if (self.ScrollItemCommonItems[0].uiTransform != null)
                        {
                            self.ScrollItemCommonItems[0].ES_CommonItem.OnClickUIItem();
                        }
                    }

                    break;
            }

            self.CurrentItemType = index;
        }

        public static void OnUpdateUI(this ES_RoleXiLianShow self)
        {
            self.XilianBagInfo = null;
            self.OnItemTypeSet(0);
        }

        private static void OnBagItemsRefresh(this ES_RoleXiLianShow self, Transform transform, int index)
        {
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);
            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.ItemXiLian, self.OnSelectItem);
        }

        private static void OnSelectItem(this ES_RoleXiLianShow self, BagInfo bagInfo)
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

                    item.UpdateSelectStatus(bagInfo);
                }
            }

            self.OnUpdateXinLian();
        }

        public static void UpdateAttribute(this ES_RoleXiLianShow self, BagInfo bagInfo)
        {
            UICommonHelper.DestoryChild(self.EG_EquipBaseSetListRectTransform.gameObject);
            if (bagInfo == null)
            {
                return;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            ItemViewHelp.ShowBaseAttribute(bagComponent.GetEquipList(), bagInfo, self.E_Obj_EquipPropertyTextText.gameObject,
                self.EG_EquipBaseSetListRectTransform.gameObject);
        }

        private static void OnUpdateXinLian(this ES_RoleXiLianShow self)
        {
            BagInfo bagInfo = self.XilianBagInfo;
            self.ES_CommonItem_Cost.uiTransform.gameObject.SetActive(bagInfo != null);
            self.UpdateAttribute(bagInfo);
            if (bagInfo == null)
            {
                return;
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            self.ES_CommonItem.uiTransform.gameObject.SetActive(true);
            self.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
            self.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);
            self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);

            //洗炼消耗
            int[] itemCost = itemConfig.XiLianStone;
            if (itemCost == null || itemCost.Length < 2)
            {
                self.ES_CommonItem_Cost.uiTransform.gameObject.SetActive(false);
                return;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            BagInfo bagInfoNeed = new BagInfo() { ItemID = itemCost[0], ItemNum = itemCost[1] };
            self.ES_CommonItem_Cost.UpdateItem(bagInfoNeed, ItemOperateEnum.None);
            self.ES_CommonItem_Cost.E_ItemNumText.gameObject.SetActive(false);

            self.E_Text_CostValueText.text = $"{bagComponent.GetItemNumber(itemCost[0])}/{itemCost[1]}";
            self.E_Text_CostValueText.color = bagComponent.GetItemNumber(itemCost[0]) >= itemCost[1]? Color.green : Color.red;

            self.E_Text_CostNameText.text = ItemConfigCategory.Instance.Get(bagInfoNeed.ItemID).ItemName;
            self.E_Text_CostNameText.color = FunctionUI.QualityReturnColorDi((int)ItemConfigCategory.Instance.Get(bagInfoNeed.ItemID).ItemQuality);
            if (bagComponent.GetItemNumber(itemCost[0]) >= itemCost[1])
            {
                self.E_Text_CostValueText.color = Color.green;
            }
        }

        private static async ETTask OnXiLianButton(this ES_RoleXiLianShow self, int times)
        {
            if (self.XilianBagInfo == null)
            {
                return;
            }

            BagInfo bagInfo = self.XilianBagInfo;
            if (times == 1)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
                List<RewardItem> costItems = new List<RewardItem>();
                int[] itemCost = itemConfig.XiLianStone;
                if (itemCost != null && itemCost.Length >= 2)
                {
                    costItems.Add(new RewardItem() { ItemID = itemCost[0], ItemNum = itemCost[1] * times });
                }

                if (!self.Root().GetComponent<BagComponentC>().CheckNeedItem(costItems))
                {
                    FlyTipComponent.Instance.ShowFlyTipDi("材料不足！");
                    return;
                }
            }

            if (times > 1)
            {
                int needDimanond = int.Parse(GlobalValueConfigCategory.Instance.Get(73).Value.Split('@')[0]);
                int itemXiLianNumber = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>()
                        .GetAsInt(NumericType.ItemXiLianNumber);
                string[] set = GlobalValueConfigCategory.Instance.Get(116).Value.Split(';');
                float discount;
                if (itemXiLianNumber < int.Parse(set[0]))
                {
                    discount = 1;
                }
                else
                {
                    discount = float.Parse(set[1]);
                }

                if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.Diamond < (int)(needDimanond * discount))
                {
                    HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_DiamondNotEnoughError);
                    return;
                }
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int oldXiLianDu = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.ItemXiLianDu);

            M2C_ItemXiLianResponse response = await BagClientNetHelper.RquestItemXiLian(self.Root(), bagInfo.BagInfoID, times);
            if (response.Error != 0)
            {
                return;
            }

            if (times == 1)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("洗炼道具成功");
                self.OnXiLianReturn();
                self.ShowXiLianEffect().Coroutine();
            }

            if (times > 1)
            {
                int newXiLianDu = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.ItemXiLianDu);
                FlyTipComponent.Instance.ShowFlyTipDi($"获得{newXiLianDu - oldXiLianDu}洗炼经验");

                await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_RoleXiLianTen);
                DlgRoleXiLianTen dlgRoleXiLianTen = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgRoleXiLianTen>();
                dlgRoleXiLianTen.OnInitUI(bagInfo, response.ItemXiLianResults);
                self.OnXiLianReturn();
            }

            //记录tap数据
            //             PlayerComponent playerComponent = self.Root().GetComponent<PlayerComponent>();
            //             string serverName = playerComponent.ServerName;
            //             UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            // #if UNITY_ANDROID
            //             TapSDKHelper.UpLoadPlayEvent(userInfo.Name, serverName, userInfo.Lv, 2, times);
            // #endif
        }

        public static void OnXiLianReturn(this ES_RoleXiLianShow self)
        {
            self.XilianBagInfo = self.Root().GetComponent<BagComponentC>().GetBagInfo(self.XilianBagInfo.BagInfoID);
            self.OnUpdateXinLian();
            self.OnItemTypeSet(self.CurrentItemType);
        }

        private static async ETTask ShowXiLianEffect(this ES_RoleXiLianShow self)
        {
            self.ETCancellationToken?.Cancel();
            self.ETCancellationToken = null;
            self.ETCancellationToken = new ETCancellationToken();
            long instance = self.InstanceId;
            self.EG_XiLianEffectRectTransform.gameObject.SetActive(false);
            self.EG_XiLianEffectRectTransform.gameObject.SetActive(true);
            await self.Root().GetComponent<TimerComponent>().WaitAsync(2000, self.ETCancellationToken);
            if (instance != self.InstanceId)
            {
                return;
            }

            self.EG_XiLianEffectRectTransform.gameObject.SetActive(false);
        }
    }
}