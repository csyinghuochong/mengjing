using System.Collections.Generic;

namespace ET.Client
{
    [FriendOf(typeof(DlgTuZhiMake))]
    public static class DlgTuZhiMakeSystem
    {
        public static void RegisterUIEvent(this DlgTuZhiMake self)
        {
            self.View.E_Btn_CloseUIButton.AddListener(self.OnCloseMake);
            self.View.E_Btn_MakeButton.AddListener(self.OnBtn_Make);
        }

        public static void ShowWindow(this DlgTuZhiMake self, Entity contextData = null)
        {
        }

        public static void OnInitUI(this DlgTuZhiMake self, ItemInfo bagInfo)
        {
            self.BagInfo = bagInfo;
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfo.ItemID);
            self.MakeId = int.Parse(itemConfig.ItemUsePar);
            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(self.MakeId);
            ItemInfo bagInfoNew = new ItemInfo();
            bagInfoNew.ItemID = equipMakeConfig.MakeItemID;
            self.View.ES_CommonItem.UpdateItem(bagInfoNew, ItemOperateEnum.MakeItem);
            self.View.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
            self.OnBagItemUpdate();
        }

        public static void OnCloseMake(this DlgTuZhiMake self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TuZhiMake);
        }

        public static void OnBtn_Make(this DlgTuZhiMake self)
        {
            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(self.MakeId);
            List<RewardItem> costItems = new List<RewardItem>();
            string neadItems = equipMakeConfig.NeedItems;
            string[] needList = neadItems.Split('@');
            for (int i = 0; i < needList.Length; i++)
            {
                string[] itemInfo = needList[i].Split(';');
                int itemId = int.Parse(itemInfo[0]);
                int itemNum = int.Parse(itemInfo[1]);
                costItems.Add(new RewardItem() { ItemID = itemId, ItemNum = itemNum });
            }

            if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.Vitality < equipMakeConfig.CostVitality)
            {
                FlyTipComponent.Instance.ShowFlyTip("活力不足！");
                return;
            }

            bool success = self.Root().GetComponent<BagComponentC>().CheckNeedItem(costItems);
            if (!success)
            {
                FlyTipComponent.Instance.ShowFlyTip("材料不足！");
                return;
            }

            //检测装备宝石
            bool haveGem = false;
            string tip = " ";
            for (int i = 0; i < costItems.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(costItems[i].ItemID);
                if (itemConfig.ItemType != ItemTypeEnum.Equipment)
                {
                    continue;
                }

                ItemInfo bagInfo = self.Root().GetComponent<BagComponentC>().GetBagInfo(costItems[i].ItemID);
                string[] gemids = bagInfo.GemIDNew.Split('_');

                for (int g = 0; g < gemids.Length; g++)
                {
                    if (gemids[g] != "0")
                    {
                        haveGem = true;
                        tip += itemConfig.ItemName + " ";
                        break;
                    }
                }
            }

            if (haveGem)
            {
                using (zstring.Block())
                {
                    PopupTipHelp.OpenPopupTip(self.Root(), "系统提示",
                        zstring.Format("制造道具的装备材料中{0}镶嵌宝石，制造会导致<color='#55FF00'>宝石消失!</color>请问是否继续制造此道具。", tip),
                        () => { self.RequestEquipMake().Coroutine(); }, null).Coroutine();
                }
            }
            else
            {
                self.RequestEquipMake().Coroutine();
            }
        }

        public static async ETTask RequestEquipMake(this DlgTuZhiMake self)
        {
            await BagClientNetHelper.RequestEquipMake(self.Root(), self.BagInfo.BagInfoID, self.MakeId, 1);
            self.OnBagItemUpdate();
            //关闭制造界面
            self.OnCloseMake();
        }

        public static void OnBagItemUpdate(this DlgTuZhiMake self)
        {
            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(self.MakeId);

            string needItems = equipMakeConfig.NeedItems;
            self.View.ES_CostList.Refresh(needItems);

            // 显示名称
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equipMakeConfig.MakeItemID);
            string itemName = itemConfig.ItemName;

            self.View.E_Lab_MakeNameText.text = itemName;
            self.View.E_Lab_MakeNameText.color = FunctionUI.QualityReturnColorDi(itemConfig.ItemQuality);

            self.View.E_Lab_MakeNumText.text = equipMakeConfig.MakeEquipNum.ToString();

            // 显示消耗活力
            self.View.E_Lab_HuoLiText.text = equipMakeConfig.CostVitality.ToString();
            using (zstring.Block())
            {
                self.View.E_Text_CurrentText.text = zstring.Format("当前活力:  {0}", self.Root().GetComponent<UserInfoComponentC>().UserInfo.Vitality);
            }
        }
    }
}
