namespace ET.Client
{
    [FriendOf(typeof(DlgTowerOfSealJump))]
    public static class DlgTowerOfSealJumpSystem
    {
        public static void RegisterUIEvent(this DlgTowerOfSealJump self)
        {
            self.View.E_YesBtnButton.AddListenerAsync(self.OnYesBtn);
            self.View.E_NoBtnButton.AddListenerAsync(self.OnNoBtn);
        }

        public static void ShowWindow(this DlgTowerOfSealJump self, Entity contextData = null)
        {
        }

        public static void InitUI(this DlgTowerOfSealJump self, int diceResult, int costType)
        {
            self.DiceResult = diceResult;
            self.CostType = costType;

            Unit myUnit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            self.Finished = myUnit.GetComponent<NumericComponentC>().GetAsInt(NumericType.SealTowerFinished);
            using (zstring.Block())
            {
                self.View.E_TipTextText.text = zstring.Format("是否花费350钻石去到第{0}层", (self.Finished + diceResult) / 10 * 10);
            }
        }

        public static async ETTask OnYesBtn(this DlgTowerOfSealJump self)
        {
            // 客户端先判断一边道具数量是否足够
            int needGold;
            if (self.CostType == 0)
            {
                GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(89);
                needGold = int.Parse(globalValueConfig.Value) + 350;
            }
            else
            {
                needGold = 350;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.Diamond < needGold)
            {
                FlyTipComponent.Instance.ShowFlyTip("钻石数量不够");
                self.OnNoBtn().Coroutine();
                return;
            }

            int error = await ActivityNetHelper.TowerOfSealNextRequest(self.Root(), 10 - self.Finished % 10, 10 + self.CostType);

            if (error != ErrorCode.ERR_Success)
            {
                FlyTipComponent.Instance.ShowFlyTip("操作错误！！");
                return;
            }

            if (self.IsDisposed)
            {
                return;
            }

            // 更新面板信息
            DlgTowerOfSealMain dlgTowerOfSealMain = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgTowerOfSealMain>();
            dlgTowerOfSealMain.UpdateInfo();

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TowerOfSealJump);
        }

        public static async ETTask OnNoBtn(this DlgTowerOfSealJump self)
        {
            int error = await ActivityNetHelper.TowerOfSealNextRequest(self.Root(), self.DiceResult, self.CostType);

            if (error != ErrorCode.ERR_Success)
            {
                FlyTipComponent.Instance.ShowFlyTip("操作错误！！");
                return;
            }

            // 更新面板信息
            DlgTowerOfSealMain dlgTowerOfSealMain = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgTowerOfSealMain>();
            dlgTowerOfSealMain.UpdateInfo();

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TowerOfSealJump);
        }
    }
}