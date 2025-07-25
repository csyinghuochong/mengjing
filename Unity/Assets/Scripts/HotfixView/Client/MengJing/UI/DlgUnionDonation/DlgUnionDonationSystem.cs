namespace ET.Client
{
    [FriendOf(typeof(DlgUnionDonation))]
    public static class DlgUnionDonationSystem
    {
        public static void RegisterUIEvent(this DlgUnionDonation self)
        {
            self.View.E_Button_DiamondDonationButton.AddListenerAsync(self.OnButton_DiamondDonation);
            self.View.E_Button_DonationButton.AddListenerAsync(self.OnButton_Donation);
            self.View.E_Button_RecordButton.AddListener(self.OnButton_Record);
            
            self.OnUpdateUI().Coroutine();
        }

        public static void ShowWindow(this DlgUnionDonation self, Entity contextData = null)
        {
        }

        public static async ETTask OnUpdateUI(this DlgUnionDonation self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            using (zstring.Block())
            {
                self.View.E_Text_Tip_4Text.text = zstring.Format("捐献次数： {0}/5次",
                    unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.UnionDonationNumber));
                self.View.E_Text_Tip_6Text.text = zstring.Format("捐献次数： {0}/10次",
                    unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.UnionDiamondDonationNumber));
            }

            //客户端获取公会等级
            U2C_UnionMyInfoResponse respose = await UnionNetHelper.UnionMyInfo(self.Root());
            if (respose.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            UnionConfig unionCof = UnionConfigCategory.Instance.Get(respose.UnionMyInfo.Level);

            self.UnionLevel = respose.UnionMyInfo.Level;
            using (zstring.Block())
            {
                self.View.E_Text_Tip_3Text.text = zstring.Format("消耗:{0}金币", unionCof.DonateGold);
                self.View.E_Text_Tip_5Text.text = zstring.Format("消耗:{0}钻石", unionCof.DonateDiamond);
            }
        }

        public static void OnButton_Record(this DlgUnionDonation self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_UnionDonationRecord).Coroutine();
        }

        public static async ETTask OnButton_DiamondDonation(this DlgUnionDonation self)
        {
            UnionConfig unionConfig = UnionConfigCategory.Instance.Get(self.UnionLevel);
            long selfDiamond = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Diamond;
            if (selfDiamond < unionConfig.DonateDiamond)
            {
                FlyTipComponent.Instance.ShowFlyTip("钻石数量不足！");
                return;
            }

            if (TimeHelper.ServerNow() - self.LastDonationTime < 500)
            {
                return;
            }

            self.LastDonationTime = TimeHelper.ServerNow();
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.UnionDiamondDonationNumber) >= 10)
            {
                FlyTipComponent.Instance.ShowFlyTip("捐献次数已达上限！");
                return;
            }

            C2M_UnionDonationRequest request = new() { Type = 1 };
            M2C_UnionDonationResponse response = (M2C_UnionDonationResponse)await self.Root().GetComponent<ClientSenderCompnent>().Call(request);
            self.OnUpdateUI().Coroutine();
        }

        public static async ETTask OnButton_Donation(this DlgUnionDonation self)
        {
            UnionConfig unionConfig = UnionConfigCategory.Instance.Get(self.UnionLevel);
            long selfgold = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Gold;
            if (selfgold < unionConfig.DonateGold)
            {
                FlyTipComponent.Instance.ShowFlyTip("金币数量不足！");
                return;
            }

            if (TimeHelper.ServerNow() - self.LastDonationTime < 500)
            {
                return;
            }

            self.LastDonationTime = TimeHelper.ServerNow();
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.UnionDonationNumber) >= 5)
            {
                FlyTipComponent.Instance.ShowFlyTip("捐献次数已达上限！");
                return;
            }

            await UnionNetHelper.UnionDonationRequest(self.Root(), 0);
            self.OnUpdateUI().Coroutine();
        }
    }
}