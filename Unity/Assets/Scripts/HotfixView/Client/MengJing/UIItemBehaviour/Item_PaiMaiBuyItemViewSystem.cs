using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_PaiMaiBuyItem))]
    [EntitySystemOf(typeof (Scroll_Item_PaiMaiBuyItem))]
    public static partial class Scroll_Item_PaiMaiBuyItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PaiMaiBuyItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PaiMaiBuyItem self)
        {
            self.DestroyWidget();
        }

        /// <summary>
        /// 打开下拉列表
        /// </summary>
        /// <param name="self"></param>
        public static async ETTask OnOpenPDList(this Scroll_Item_PaiMaiBuyItem self)
        {
            // UI uI = await UIHelper.Create(self.DomainScene(), UIType.UIWatchPaiMai);
            // uI.GetComponent<UIWatchPaiMaiComponent>().OnUpdateUI(self.FastSeach);
        }

        public static void FastSeach(this Scroll_Item_PaiMaiBuyItem self)
        {
            // self.GetParent<UIPaiMaiBuyComponent>().InputField.GetComponent<InputField>().text = self.Text_Name.GetComponent<Text>().text;
        }

        public static async ETTask RequestBuy(this Scroll_Item_PaiMaiBuyItem self)
        {
            long instanceId = self.InstanceId;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            C2M_PaiMaiBuyRequest request = new()
            {
                PaiMaiItemInfo = self.PaiMaiItemInfo, IsRecharge = numericComponent.GetAsInt(NumericType.RechargeNumber)
            };
            M2C_PaiMaiBuyResponse response =
                    (M2C_PaiMaiBuyResponse)await self.Root().GetComponent<ClientSenderCompnent>().Call(request);
            if (instanceId != self.InstanceId)
            {
                return;
            }

            //隐藏显示

            if (response.Error == 0)
            {
                if (self.uiTransform.gameObject != null)
                {
                    self.uiTransform.gameObject.SetActive(false);
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.PaiMaiItemInfo.BagInfo.ItemID);
                self.GetParent<ES_PaiMaiBuy>().RemoveItem(itemConfig.ItemType, self.PaiMaiItemInfo);
            }
            else
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("道具已经被买走了！");
            }
        }

        public static async ETTask OnClickButtonBuy(this Scroll_Item_PaiMaiBuyItem self)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(self.PaiMaiItemInfo.BagInfo.ItemID);
            // 橙色装备不能购买
            if (itemConfig.ItemQuality >= 5 && itemConfig.ItemType == 3)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("橙色品质及以上的装备不能购买！");
                return;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (bagComponent.GetBagLeftCell() < 1)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("背包空间不足");
                return;
            }

            bool canBuy = false;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int openPaiMai = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PaiMaiOpen);
            if (openPaiMai == 1)
            {
                canBuy = true;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            int createDay = userInfoComponent.GetCreateDay();

            if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.RechargeNumber) > 0)
            {
                canBuy = true;
            }

            if (ComHelp.IsCanPaiMai_KillBoss(userInfoComponent.UserInfo.MonsterRevives, userInfoComponent.UserInfo.Lv))
            {
                canBuy = true;
            }

            int needLv = ComHelp.IsCanPaiMai_Level(createDay, userInfoComponent.UserInfo.Lv);
            if (needLv == 0)
            {
                canBuy = true;
            }

            if (!canBuy)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi($"等级需达到{needLv}级或赞助任意金额开启拍卖行购买功能！");
                return;
            }

            if (self.PaiMaiItemInfo.BagInfo.ItemNum > 1)
            {
                // UI ui = await UIHelper.Create(self.ZoneScene(), UIType.UIPaiMaiBuyTip);
                // ui.GetComponent<UIPaiMaiBuyTipComponent>()?.InitInfo(self.PaiMaiItemInfo, (int buyNum) =>
                // {
                //     if (buyNum < self.PaiMaiItemInfo.BagInfo.ItemNum)
                //     {
                //         self.PaiMaiItemInfo.BagInfo.ItemNum -= buyNum;
                //         self.OnUpdateItem(self.PaiMaiItemInfo);
                //     }
                //     else
                //     {
                //         if (self.GameObject != null)
                //         {
                //             self.GameObject.SetActive(false);
                //         }
                //
                //         ItemConfig itemConfig1 = ItemConfigCategory.Instance.Get(self.PaiMaiItemInfo.BagInfo.ItemID);
                //         self.GetParent<UIPaiMaiBuyComponent>().RemoveItem(itemConfig1.ItemType, self.PaiMaiItemInfo);
                //     }
                // });
            }
            else
            {
                if (self.PaiMaiItemInfo.Price * self.PaiMaiItemInfo.BagInfo.ItemNum >= 500000)
                {
                    PopupTipHelp.OpenPopupTip(self.Root(), "购买道具",
                        $"你购买的道具需要花费{self.PaiMaiItemInfo.Price * self.PaiMaiItemInfo.BagInfo.ItemNum}金币，是否购买？",
                        () => { self.RequestBuy().Coroutine(); },
                        null).Coroutine();
                }
                else
                {
                    self.RequestBuy().Coroutine();
                }
            }
        }

        public static void OnUpdateItem(this Scroll_Item_PaiMaiBuyItem self, PaiMaiItemInfo paiMaiItemInfo)
        {
            self.E_PDListBtnButton.AddListenerAsync(self.OnOpenPDList);
            self.E_ButtonBuyButton.AddListenerAsync(self.OnClickButtonBuy);

            self.PaiMaiItemInfo = paiMaiItemInfo;
            if (paiMaiItemInfo == null || self.ES_CommonItem == null)
                return;

            self.ES_CommonItem.UpdateItem(paiMaiItemInfo.BagInfo, ItemOperateEnum.PaiMaiBuy);
            self.E_Text_OwnerText.text = paiMaiItemInfo.PlayerName;

            //显示名称
            FunctionUI.ItemObjShowName(self.E_Text_NameText.gameObject, self.PaiMaiItemInfo.BagInfo.ItemID);

            //显示价格
            int sumPrice = paiMaiItemInfo.Price * paiMaiItemInfo.BagInfo.ItemNum;
            self.E_Text_PriceText.text = sumPrice.ToString();

            //显示时间
            self.E_Text_LeftTimeText.text = TimeHelper.TimeToShowCostTimeStr(paiMaiItemInfo.SellTime, 48);

            //装备显示等级
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(self.PaiMaiItemInfo.BagInfo.ItemID);
            if (itemCof.ItemType == 3)
            {
                self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(true);
                self.ES_CommonItem.E_ItemNumText.text = itemCof.UseLv + "级";
            }
        }
    }
}