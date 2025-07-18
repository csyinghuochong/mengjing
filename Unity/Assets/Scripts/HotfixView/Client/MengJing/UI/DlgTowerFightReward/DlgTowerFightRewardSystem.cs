namespace ET.Client
{
    [FriendOf(typeof(DlgTowerFightReward))]
    public static class DlgTowerFightRewardSystem
    {
        public static void RegisterUIEvent(this DlgTowerFightReward self)
        {
            self.View.E_Btn_ReturnButton.AddListener(self.OnBtn_Return);
        }

        public static void ShowWindow(this DlgTowerFightReward self, Entity contextData = null)
        {
        }

        public static void OnUpdateUI(this DlgTowerFightReward self, M2C_FubenSettlement message)
        {
            if (self.View.E_Text_ResultText == null)
            {
                return;
            }

            if (self.Root() == null || self.Root().CurrentScene() == null)
            {
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit == null)
            {
                return;
            }

            int towerId = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.TowerId);
            if (!TowerConfigCategory.Instance.Contain(towerId))
            {
                return;
            }

            TowerConfig towerConfig = TowerConfigCategory.Instance.Get(towerId);
            if (message.BattleResult == CombatResultEnum.Fail)
            {
                self.View.E_Text_ResultText.text = "挑战失败";
            }
            else
            {
                using (zstring.Block())
                {
                    self.View.E_Text_ResultText.text = zstring.Format("你当前成功完成挑战{0}波，获得奖励如下:", towerConfig.CengNum);
                }
            }

            using (zstring.Block())
            {
                string rewardList = zstring.Format("1;{0}@2;{1}", message.RewardGold, message.RewardExp);
                self.View.ES_RewardList.Refresh(rewardList);
            }
        }

        public static void OnBtn_Return(this DlgTowerFightReward self)
        {
            EnterMapHelper.RequestQuitFuben(self.Root());
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TowerFightReward);
        }
    }
}
