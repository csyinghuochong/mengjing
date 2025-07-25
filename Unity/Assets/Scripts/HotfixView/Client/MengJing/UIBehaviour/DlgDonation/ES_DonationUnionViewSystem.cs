using System;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_DonationUnion))]
    [FriendOfAttribute(typeof(ES_DonationUnion))]
    public static partial class ES_DonationUnionSystem
    {
        [EntitySystem]
        private static void Awake(this ES_DonationUnion self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Button_SignupButton.AddListenerAsync(self.OnButton_SignupButton);
            self.E_Button_RaceButton.AddListener(self.OnButton_RaceButton);

            self.E_Button_RaceButton.gameObject.SetActive(false);
            self.OnUpdateUI().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_DonationUnion self)
        {
            self.DestroyWidget();
        }

        public static void ShowOpenTime(this ES_DonationUnion self)
        {
            long serverTime = TimeHelper.ServerNow();
            DateTime dateTime = TimeInfo.Instance.ToDateTime(serverTime);

            long opentime = FunctionHelp.GetOpenTime(1044);
            long curTime = (dateTime.Hour * 60 + dateTime.Minute) * 60 + dateTime.Second;
            bool raceopen = FunctionHelp.IsFunctionDayOpen((int)dateTime.DayOfWeek, 1044);

            if (raceopen && curTime < opentime)
            {
                using (zstring.Block())
                {
                    self.E_Text_Open_TimeText.text = zstring.Format("{0}月{1}日 21点30开启", dateTime.Month, dateTime.Day);
                }
            }
            else
            {
                long addTime = (7 - (int)dateTime.DayOfWeek) * TimeHelper.OneDay + (opentime - curTime) * TimeHelper.Second;
                serverTime += addTime;
                dateTime = TimeInfo.Instance.ToDateTime(serverTime);
                using (zstring.Block())
                {
                    self.E_Text_Open_TimeText.text = zstring.Format("{0}月{1}日 21点30开启", dateTime.Month, dateTime.Day);
                }
            }
        }

        public static void OnButton_RaceButton(this ES_DonationUnion self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();

            bool signup = false;
            for (int i = 0; i < self.UnionListItems.Count; i++)
            {
                if (self.UnionListItems[i].UnionId == numericComponent.GetAsLong(NumericType.UnionId_0))
                {
                    signup = true;
                    break;
                }
            }

            if (signup)
            {
                EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.UnionRace, 2000008).Coroutine();
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Donation);
            }
            else
            {
                FlyTipComponent.Instance.ShowFlyTip("未报名！");
            }
        }

        public static async ETTask OnButton_SignupButton(this ES_DonationUnion self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();

            if (numericComponent.GetAsLong(NumericType.UnionId_0) == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("没有公会！");
                return;
            }

            for (int i = 0; i < self.UnionListItems.Count; i++)
            {
                if (self.UnionListItems[i].UnionId == numericComponent.GetAsLong(NumericType.UnionId_0))
                {
                    FlyTipComponent.Instance.ShowFlyTip("已报名！");
                    return;
                }
            }

            U2C_UnionMyInfoResponse unionrespose = await UnionNetHelper.UnionMyInfo(self.Root());

            UnionPlayerInfo unionPlayerInfo = UnionHelper.GetUnionPlayerInfo(unionrespose.UnionMyInfo.UnionPlayerList, unit.Id);
            if (unionPlayerInfo.Position == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("没有权限！");
                return;
            }

            await UnionNetHelper.UnionSignUpRequest(self.Root(), numericComponent.GetAsLong(NumericType.UnionId_0));

            self.OnUpdateUI().Coroutine();
        }

        public static async ETTask OnUpdateUI(this ES_DonationUnion self)
        {
            U2C_UnionRaceInfoResponse response = await UnionNetHelper.UnionRaceInfoRequest(self.Root());
            self.UnionListItems = response.UnionInfoList;
            using (zstring.Block())
            {
                self.E_Text_BonusText.text = zstring.Format("累计总奖金： {0}", response.TotalDonation);
            }

            string unionnamelist = "已报名公会: ";
            for (int i = 0; i < self.UnionListItems.Count; i++)
            {
                unionnamelist = unionnamelist + self.UnionListItems[i].UnionName + "   ";
            }

            self.E_Text_Tip_5Text.text = unionnamelist;

            self.E_Button_RaceButton.gameObject.SetActive(FunctionHelp.IsInUnionRaceTime());
            self.E_Button_SignupButton.gameObject.SetActive(!FunctionHelp.IsInUnionRaceTime());

            self.ShowOpenTime();
        }
    }
}
