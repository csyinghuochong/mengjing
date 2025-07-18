namespace ET.Client
{
    [FriendOf(typeof (DlgFirstWinReward))]
    public static class DlgFirstWinRewardSystem
    {
        public static void RegisterUIEvent(this DlgFirstWinReward self)
        {
            self.View.E_Button_Get_1Button.AddListener(() => { self.RequestGetFirstWinSelf(1).Coroutine(); });
            self.View.E_Button_Get_2Button.AddListener(() => { self.RequestGetFirstWinSelf(2).Coroutine(); });
            self.View.E_Button_Get_3Button.AddListener(() => { self.RequestGetFirstWinSelf(3).Coroutine(); });
            self.View.E_ImageButtonButton.AddListener(
                () => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_FirstWinReward); });
            
            self.View.E_Button_Get_3Button.gameObject.SetActive(false);
            self.View.E_Button_Get_2Button.gameObject.SetActive(false);
            self.View.E_Button_Get_1Button.gameObject.SetActive(false);
            self.View.E_Button_Complete_3Image.gameObject.SetActive(false);
            self.View.E_Button_Complete_2Image.gameObject.SetActive(false);
            self.View.E_Button_Complete_1Image.gameObject.SetActive(false);
        }

        public static void ShowWindow(this DlgFirstWinReward self, Entity contextData = null)
        {
        }

        public static void OnUpdateUI(this DlgFirstWinReward self, int firstWinId)
        {
            self.FristWinId = firstWinId;
            self.View.E_TextTip_TitleText.text = "首胜奖励";
            self.View.E_Button_Get_3Button.gameObject.SetActive(false);
            self.View.E_Button_Get_2Button.gameObject.SetActive(false);
            self.View.E_Button_Get_1Button.gameObject.SetActive(false);
            self.View.E_Button_Complete_3Image.gameObject.SetActive(false);
            self.View.E_Button_Complete_3Image.gameObject.SetActive(false);
            self.View.E_Button_Complete_3Image.gameObject.SetActive(false);

            FirstWinConfig firstWin = FirstWinConfigCategory.Instance.Get(firstWinId);
            self.View.ES_RewardList_1.Refresh(firstWin.RewardList_1, 0.9f);
            self.View.ES_RewardList_2.Refresh(firstWin.RewardList_2, 0.9f);
            self.View.ES_RewardList_3.Refresh(firstWin.RewardList_3, 0.9f);

            self.View.E_TextHintTipsText.gameObject.SetActive(true);
        }

        public static async ETTask RequestGetFirstWinSelf(this DlgFirstWinReward self, int diff)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (!userInfoComponent.IsHaveFristWinReward(self.FristWinId, diff))
            {
                FlyTipComponent.Instance.ShowFlyTip("对应难度的领主怪物未被击败，请先击败对应怪物。");
                return;
            }

            await ActivityNetHelper.FirstWinSelfReward(self.Root(), self.FristWinId, diff);

            self.OnUpdateUISelf(self.FristWinId);
        }

        public static void OnUpdateUISelf(this DlgFirstWinReward self, int firstWinId)
        {
            self.FristWinId = firstWinId;
            self.View.E_TextTip_TitleText.text = "个人奖励";

            FirstWinConfig firstWin = FirstWinConfigCategory.Instance.Get(firstWinId);

            self.View.ES_RewardList_1.Refresh(firstWin.RewardList_1, 0.9f);
            self.View.ES_RewardList_2.Refresh(firstWin.RewardList_2, 0.9f);
            self.View.ES_RewardList_3.Refresh(firstWin.RewardList_3, 0.9f);

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();

            self.View.E_Button_Complete_1Image.gameObject.SetActive(userInfoComponent.IsReceivedFristWinReward(firstWinId, 1));
            self.View.E_Button_Complete_2Image.gameObject.SetActive(userInfoComponent.IsReceivedFristWinReward(firstWinId, 2));
            self.View.E_Button_Complete_3Image.gameObject.SetActive(userInfoComponent.IsReceivedFristWinReward(firstWinId, 3));
            self.View.E_Button_Get_1Button.gameObject.SetActive(!self.View.E_Button_Complete_1Image.gameObject.activeSelf);
            self.View.E_Button_Get_2Button.gameObject.SetActive(!self.View.E_Button_Complete_2Image.gameObject.activeSelf);
            self.View.E_Button_Get_3Button.gameObject.SetActive(!self.View.E_Button_Complete_3Image.gameObject.activeSelf);

            self.View.E_TextHintTipsText.gameObject.SetActive(false);
        }
    }
}
