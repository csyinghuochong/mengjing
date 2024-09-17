namespace ET.Client
{
    [FriendOf(typeof(DlgTowerOfSealCost))]
    public static class DlgTowerOfSealCostSystem
    {
        public static void RegisterUIEvent(this DlgTowerOfSealCost self)
        {
            self.View.E_CloseBtnButton.AddListener(self.OnCloseBtn);
            self.View.E_CostDiamondBtnButton.AddListener(self.OnCostDiamondBtn);
            self.View.E_CostTicketBtnButton.AddListener(self.OnCostTicketBtn);
        }

        public static void ShowWindow(this DlgTowerOfSealCost self, Entity contextData = null)
        {
        }

        public static void OnCloseBtn(this DlgTowerOfSealCost self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TowerOfSealCost);
        }

        public static void OnCostDiamondBtn(this DlgTowerOfSealCost self)
        {
            // 客户端先判断一边道具数量是否足够
            GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(89);
            int needGold = int.Parse(globalValueConfig.Value);
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.Diamond < needGold)
            {
                FlyTipComponent.Instance.ShowFlyTip("钻石数量不够");
                return;
            }

            // 摇骰子
            TowerOfSealHelpr.StartPlayDice(self.Root(), 0).Coroutine();

            // 隐藏开始挑战按钮
            DlgTowerOfSealMain dlgTowerOfSealMain = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgTowerOfSealMain>();
            dlgTowerOfSealMain.View.E_StartBtnButton.gameObject.SetActive(false);

            self.OnCloseBtn();
        }

        public static void OnCostTicketBtn(this DlgTowerOfSealCost self)
        {
            // 客户端先判断一边道具数量是否足够
            GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(90);
            int itemConfigID = int.Parse(globalValueConfig.Value);
            long itemNum = self.Root().GetComponent<BagComponentC>().GetItemNumber(itemConfigID);
            if (itemNum <= 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("凭证数量不够");
                return;
            }

            // 摇骰子
            TowerOfSealHelpr.StartPlayDice(self.Root(), 1).Coroutine();

            // 隐藏开始挑战按钮
            DlgTowerOfSealMain dlgTowerOfSealMain = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgTowerOfSealMain>();
            dlgTowerOfSealMain.View.E_StartBtnButton.gameObject.SetActive(false);

            self.OnCloseBtn();
        }
    }
}