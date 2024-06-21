using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_DonationUnion))]
    [FriendOfAttribute(typeof (ES_DonationUnion))]
    public static partial class ES_DonationUnionSystem
    {
        [EntitySystem]
        private static void Awake(this ES_DonationUnion self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Button_SignupButton.AddListenerAsync(self.OnButton_Signup);
            self.E_Button_RaceButton.AddListener(self.OnButton_Race);

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
                self.E_Text_Open_TimeText.text = $"{dateTime.Month}月{dateTime.Day}日 21点30开启";
            }
            else
            {
                long addTime = (7 - (int)dateTime.DayOfWeek) * TimeHelper.OneDay + (opentime - curTime) * TimeHelper.Second;
                serverTime += addTime;
                dateTime = TimeInfo.Instance.ToDateTime(serverTime);
                self.E_Text_Open_TimeText.text = $"{dateTime.Month}月{dateTime.Day}日 21点30开启";
            }
        }

        public static void OnButton_Race(this ES_DonationUnion self)
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
                EnterMapHelper.RequestTransfer(self.Root(), SceneTypeEnum.UnionRace, 2000008).Coroutine();
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Donation);
            }
            else
            {
                FlyTipComponent.Instance.ShowFlyTipDi("未报名！");
            }
        }

        public static async ETTask OnButton_Signup(this ES_DonationUnion self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();

            if (numericComponent.GetAsLong(NumericType.UnionId_0) == 0)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("没有家族！");
                return;
            }

            for (int i = 0; i < self.UnionListItems.Count; i++)
            {
                if (self.UnionListItems[i].UnionId == numericComponent.GetAsLong(NumericType.UnionId_0))
                {
                    FlyTipComponent.Instance.ShowFlyTipDi("已报名！");
                    return;
                }
            }

            U2C_UnionMyInfoResponse unionrespose = await UnionNetHelper.UnionMyInfo(self.Root(), numericComponent.GetAsLong(NumericType.UnionId_0));

            UnionPlayerInfo unionPlayerInfo = UnionHelper.GetUnionPlayerInfo(unionrespose.UnionMyInfo.UnionPlayerList, unit.Id);
            if (unionPlayerInfo.Position == 0)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("没有权限！");
                return;
            }

            await UnionNetHelper.UnionSignUpRequest(self.Root(), numericComponent.GetAsLong(NumericType.UnionId_0));

            self.OnUpdateUI().Coroutine();
        }

        public static async ETTask OnUpdateUI(this ES_DonationUnion self)
        {
            U2C_UnionRaceInfoResponse response = await UnionNetHelper.UnionRaceInfoRequest(self.Root());
            self.UnionListItems = response.UnionInfoList;
            self.E_Text_BonusText.text = $"累计总奖金： {response.TotalDonation}";

            string unionnamelist = "已报名家族: ";
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