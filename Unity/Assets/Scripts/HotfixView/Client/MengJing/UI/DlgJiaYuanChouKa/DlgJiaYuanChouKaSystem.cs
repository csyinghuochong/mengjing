namespace ET.Client
{
    [FriendOf(typeof (DlgJiaYuanChouKa))]
    public static class DlgJiaYuanChouKaSystem
    {
        public static void RegisterUIEvent(this DlgJiaYuanChouKa self)
        {
            self.View.E_Btn_ChouKaOneButton.AddListener(() => self.ChouKa(1));
            self.View.E_Btn_ChouKaTenButton.AddListener(() => self.ChouKa(10));
        }

        public static void ShowWindow(this DlgJiaYuanChouKa self, Entity contextData = null)
        {
        }

        //抽卡
        public static void ChouKa(this DlgJiaYuanChouKa self, int chouKaNum)
        {
        }

        public static void ShowChouKaReward(this DlgJiaYuanChouKa self)
        {
            string rewardListStr = "10036001;1@10036035;1";
            self.View.ES_RewardList.Refresh(rewardListStr, 0.8f);
        }
    }
}
