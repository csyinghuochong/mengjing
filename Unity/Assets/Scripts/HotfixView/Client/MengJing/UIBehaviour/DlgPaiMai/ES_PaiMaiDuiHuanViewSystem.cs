using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_PaiMaiDuiHuan))]
    [FriendOfAttribute(typeof (ES_PaiMaiDuiHuan))]
    public static partial class ES_PaiMaiDuiHuanSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PaiMaiDuiHuan self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_DuiHuanButton.AddListenerAsync(self.OnBtn_DuiHuanButton);
            self.E_Btn_BuyNum_jian10Button.AddListener(() => { self.OnBtn_BuyNum_jia(-1000); });
            self.E_Btn_BuyNum_jian1Button.AddListener(() => { self.OnBtn_BuyNum_jia(-100); });
            self.E_Btn_BuyNum_jia10Button.AddListener(() => { self.OnBtn_BuyNum_jia(1000); });
            self.E_Btn_BuyNum_jia1Button.AddListener(() => { self.OnBtn_BuyNum_jia(100); });
            self.E_Lab_RmbNumInputField.onValueChanged.AddListener((str) => { self.OnBtn_BuyNum_jia(0); });
            self.E_Btn_ShopButton.AddListenerAsync(self.OnBtn_ShopButton);

            self.Init().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_PaiMaiDuiHuan self)
        {
            self.DestroyWidget();
        }

        public static async ETTask Init(this ES_PaiMaiDuiHuan self)
        {
            //初始化兑换值
            R2C_DBServerInfoResponse response = await PaiMaiNetHelper.DBServerInfo(self.Root());
            if (self.IsDisposed)
            {
                return;
            }

            self.ExchangeValue = response.ServerInfo.ExChangeGold;

            self.ExchangeZuanShi = 100;
            self.E_Lab_DuiHuanGoldProShowText.text = (self.ExchangeValue * self.ExchangeZuanShi).ToString();
            self.E_Lab_DuiHuanZuanShiProShowText.text = self.ExchangeZuanShi.ToString();
            self.E_DuiHuan_GoldText.text = (self.ExchangeValue * self.ExchangeZuanShi).ToString();
            self.E_Lab_RmbNumInputField.text = self.ExchangeZuanShi.ToString();
        }

        public static async ETTask OnBtn_ShopButton(this ES_PaiMaiDuiHuan self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_WeiJingShop);
        }

        public static void OnBtn_BuyNum_jia(this ES_PaiMaiDuiHuan self, int num)
        {
            long max = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Diamond;
            long diamondsNumber = long.Parse(self.E_Lab_RmbNumInputField.text);

            if (num > 0 && diamondsNumber >= 10000)
            {
                FlyTipComponent.Instance.ShowFlyTip("兑换单次最多兑换10000钻石哦！");
                return;
            }

            diamondsNumber += num;
            if (diamondsNumber < 100)
                diamondsNumber = 100;
            if (diamondsNumber > max)
                diamondsNumber = max;
            //单次兑换最多10000
            if (diamondsNumber > 10000)
            {
                diamondsNumber = 10000;
            }

            self.E_Lab_RmbNumInputField.text = diamondsNumber.ToString();
            self.E_DuiHuan_GoldText.text = (self.ExchangeValue * diamondsNumber).ToString();
            self.E_Lab_WeiJingGoldText.text = $"{diamondsNumber / 100}";
        }

        public static async ETTask OnBtn_DuiHuanButton(this ES_PaiMaiDuiHuan self)
        {
            long diamondsNumber = long.Parse(self.E_Lab_RmbNumInputField.text);
            if (self.Root().GetComponent<UserInfoComponentC>().UserInfo.Diamond < diamondsNumber)
            {
                FlyTipComponent.Instance.ShowFlyTip("钻石不足！");
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.RechargeNumber) <= 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("为保证游戏内金币保值，充值任意额度后激活此功能！");
                return;
            }

            int error = await PaiMaiNetHelper.PaiMaiDuiHuan(self.Root(), diamondsNumber);

            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            using (zstring.Block())
            {
                FlyTipComponent.Instance.ShowFlyTipDi(zstring.Format("获得{0}金币", self.E_DuiHuan_GoldText.text));
            }
        }
    }
}
