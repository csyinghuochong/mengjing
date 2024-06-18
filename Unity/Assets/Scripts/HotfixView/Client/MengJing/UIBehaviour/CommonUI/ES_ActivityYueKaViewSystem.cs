using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_ActivityYueKa))]
    [FriendOfAttribute(typeof (ES_ActivityYueKa))]
    public static partial class ES_ActivityYueKaSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ActivityYueKa self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_OpenYueKaButton.AddListener(self.OpenYueKa);
            self.E_Btn_GetRewardButton.AddListenerAsync(self.ReceiveReward);

            self.OnUpdateUI();
            self.InitReward();
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
                self.E_BtnBtnOpenYueKaSet.SetActive(false);
                self.Btn_GetReward.SetActive(true);
                self.Btn_GoPay.SetActive(true);
                self.Btn_OpenYueKa.SetActive(false);

                int leftDay = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.YueKaRemainTimes);
                self.Text_Remainingtimes.GetComponent<Text>().text = $"{leftDay}/7";
            }
            else
            {
                self.Img_JiHuo.SetActive(false);
                self.BtnOpenYueKaSet.SetActive(true);
                self.Btn_GetReward.SetActive(false);
                self.Btn_GoPay.SetActive(false);
                self.Btn_OpenYueKa.SetActive(true);
                self.Text_Remainingtimes.GetComponent<Text>().text = $"0/7";
            }
        }

        public static void InitReward(this ES_ActivityYueKa self)
        {
            string reward = GlobalValueConfigCategory.Instance.Get(28).Value;
            UICommonHelper.ShowItemList(reward, self.ItemListNode, self, 1f);

            self.TextYueKaCost.GetComponent<Text>().text = GlobalValueConfigCategory.Instance.Get(37).Value;
        }

        public static async ETTask ReceiveReward(this ES_ActivityYueKa self)
        {
            Unit unit = UnitHelper.GetMyUnitFromZoneScene(self.ZoneScene());
            if (!unit.IsYueKaStates())
            {
                FloatTipManager.Instance.ShowFloatTip("请先开启月卡！");
                return;
            }

            if (unit.GetComponent<NumericComponent>().GetAsInt(NumericType.YueKaAward) == 1)
            {
                //当天已领取
                FloatTipManager.Instance.ShowFloatTip("当天奖励已领取！");
                return;
            }

            int maxPiLao = unit.GetMaxPiLao();
            long nowPiLao = self.ZoneScene().GetComponent<UserInfoComponent>().UserInfo.PiLao;

            if (maxPiLao < nowPiLao + 20)
            {
                PopupTipHelp.OpenPopupTip(self.ZoneScene(), "领取", "是否领取?\n领取后会有体力溢出!", async () =>
                {
                    C2M_YueKaRewardRequest c2M_RoleYueKaRequest = new C2M_YueKaRewardRequest() { };
                    M2C_YueKaRewardResponse m2C_RoleYueKaResponse =
                            (M2C_YueKaRewardResponse)await self.DomainScene().GetComponent<SessionComponent>().Session.Call(c2M_RoleYueKaRequest);
                    self.OnUpdateUI();
                }).Coroutine();
            }
            else
            {
                C2M_YueKaRewardRequest c2M_RoleYueKaRequest = new C2M_YueKaRewardRequest() { };
                M2C_YueKaRewardResponse m2C_RoleYueKaResponse =
                        (M2C_YueKaRewardResponse)await self.DomainScene().GetComponent<SessionComponent>().Session.Call(c2M_RoleYueKaRequest);
                self.OnUpdateUI();
            }
        }

        public static async ETTask ReqestOpenYueKa(this ES_ActivityYueKa self)
        {
            C2M_YueKaOpenRequest c2M_RoleYueKaRequest = new C2M_YueKaOpenRequest() { };
            M2C_YueKaOpenResponse m2C_RoleYueKaResponse =
                    (M2C_YueKaOpenResponse)await self.DomainScene().GetComponent<SessionComponent>().Session.Call(c2M_RoleYueKaRequest);
            if (m2C_RoleYueKaResponse.Error == 0)
            {
                //月卡开启成功
                FloatTipManager.Instance.ShowFloatTipDi(GameSettingLanguge.LoadLocalization("月卡开启成功"));
                self.Img_JiHuo.SetActive(true);
                self.BtnOpenYueKaSet.SetActive(false);
                self.Btn_GetReward.SetActive(true);
                self.Btn_OpenYueKa.SetActive(true);
                self.Btn_GoPay.SetActive(true);
                self.OnUpdateUI();
            }
        }

        //开启月卡
        public static void OpenYueKa(this ES_ActivityYueKa self)
        {
            //判断自身是否有钻石
            string cost = GlobalValueConfigCategory.Instance.Get(37).Value;
            PopupTipHelp.OpenPopupTip(self.ZoneScene(), "开启月卡", $"是否花费{cost}钻石开启月卡?", () => { self.ReqestOpenYueKa().Coroutine(); }, null)
                    .Coroutine();
        }
    }
}