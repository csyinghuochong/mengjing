using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_ActivityYueKa))]
    [FriendOfAttribute(typeof(ES_ActivityYueKa))]
    public static partial class ES_ActivityYueKaSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ActivityYueKa self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_OpenYueKaButton.AddListener(self.OnBtn_OpenYueKaButton);
            self.E_Btn_GetRewardButton.AddListenerAsync(self.OnBtn_GetRewardButton);

            self.OnUpdateUI();
            self.InitReward();
            self.E_Btn_GoPayButton.AddListener(self.OnBtn_GoPayButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_ActivityYueKa self)
        {
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this ES_ActivityYueKa self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.YueKaRemainTimes) > 0)
            {
                self.E_Img_JiHuoImage.gameObject.SetActive(true);
                self.EG_BtnOpenYueKaSetRectTransform.gameObject.SetActive(false);
                self.E_Btn_GetRewardButton.gameObject.SetActive(true);
                self.E_Btn_GoPayButton.gameObject.SetActive(true);
                self.E_Btn_OpenYueKaButton.gameObject.SetActive(false);

                int leftDay = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.YueKaRemainTimes);
                using (zstring.Block())
                {
                    self.E_Text_RemainingtimesText.text = zstring.Format("{0}/7", leftDay);
                }
            }
            else
            {
                self.E_Img_JiHuoImage.gameObject.SetActive(false);
                self.EG_BtnOpenYueKaSetRectTransform.gameObject.SetActive(true);
                self.E_Btn_GetRewardButton.gameObject.SetActive(false);
                self.E_Btn_GoPayButton.gameObject.SetActive(false);
                self.E_Btn_OpenYueKaButton.gameObject.SetActive(true);
                self.E_Text_RemainingtimesText.text = "0/7";
            }
        }

        public static void InitReward(this ES_ActivityYueKa self)
        {
            string reward = GlobalValueConfigCategory.Instance.Get(28).Value;
            self.ES_RewardList.Refresh(reward);
            self.ES_RewardList.ShowUIEffect( 41100001 );
            self.E_TextYueKaCostText.text = GlobalValueConfigCategory.Instance.Get(37).Value;
        }

        public static async ETTask OnBtn_GetRewardButton(this ES_ActivityYueKa self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.YueKaRemainTimes) == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("请先开启月卡！");
                return;
            }

            if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.YueKaAward) == 1)
            {
                //当天已领取
                FlyTipComponent.Instance.ShowFlyTip("当天奖励已领取！");
                return;
            }

            int maxPiLao = int.Parse(GlobalValueConfigCategory.Instance
                    .Get(unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.YueKaRemainTimes) > 0 ? 26 : 10).Value);
            long nowPiLao = self.Root().GetComponent<UserInfoComponentC>().UserInfo.PiLao;

            if (maxPiLao < nowPiLao + 20)
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "领取", "是否领取?\n领取后会有体力溢出!", async () =>
                {
                    await ActivityNetHelper.YueKaReward(self.Root());
                    self.OnUpdateUI();
                }).Coroutine();
            }
            else
            {
                await ActivityNetHelper.YueKaReward(self.Root());
                self.OnUpdateUI();
            }
        }

        public static async ETTask ReqestOnBtn_OpenYueKaButton(this ES_ActivityYueKa self)
        {
            int error = await ActivityNetHelper.YueKaOpen(self.Root());
            if (error == 0)
            {
                // 月卡开启成功
                FlyTipComponent.Instance.ShowFlyTip(LanguageComponent.Instance.LoadLocalization("月卡开启成功"));
                self.E_Img_JiHuoImage.gameObject.SetActive(true);
                self.EG_BtnOpenYueKaSetRectTransform.gameObject.SetActive(false);
                self.E_Btn_GetRewardButton.gameObject.SetActive(true);
                self.E_Btn_OpenYueKaButton.gameObject.SetActive(true);
                self.E_Btn_GoPayButton.gameObject.SetActive(true);
                self.OnUpdateUI();
            }
        }

        // 开启月卡
        public static void OnBtn_OpenYueKaButton(this ES_ActivityYueKa self)
        {
            // 判断自身是否有钻石
            string cost = GlobalValueConfigCategory.Instance.Get(37).Value;
            using (zstring.Block())
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "开启月卡", zstring.Format("是否花费{0}钻石开启月卡?", cost), () => { self.ReqestOnBtn_OpenYueKaButton().Coroutine(); },
                    null).Coroutine();
            }
        }
        public static void OnBtn_GoPayButton(this ES_ActivityYueKa self)
        {
        }
    }
}
