using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgWorldLv))]
    public static class DlgWorldLvSystem
    {
        public static void RegisterUIEvent(this DlgWorldLv self)
        {
            self.View.E_ButtonDiHuanButton.AddListener(self.OnButtonDiHuan);
            self.View.E_Btn_CloseButton.AddListener(self.OnBtn_Close);
        }

        public static void ShowWindow(this DlgWorldLv self, Entity contextData = null)
        {
            self.OnInitUI().Coroutine();
        }

        public static async ETTask OnInitUI(this DlgWorldLv self)
        {
            R2C_WorldLvResponse response = await UserInfoNetHelper.WorldLv(self.Root());
            if (self.IsDisposed)
            {
                return;
            }

            RankingInfo rankingInfo = response.ServerInfo.RankingInfo;
            self.View.E_Text_WorldLvText.text = response.ServerInfo.WorldLv.ToString();
            self.ServerInfo = response.ServerInfo;

            if (rankingInfo != null)
            {
                self.View.E_Lab_GanDiNameText.text = $"{rankingInfo.PlayerName}({rankingInfo.PlayerLv}级)";
            }
            else
            {
                self.View.E_Lab_GanDiNameText.text = "暂无上榜";
            }

            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            self.View.E_Lab_MyLv1Text.text = $"你当前的等级：{userInfo.Lv}";
            self.View.E_Lab_MyLv2Text.text = $"你当前的等级：{userInfo.Lv}";

            float expAdd = CommonHelp.GetExpAdd(userInfo.Lv, response.ServerInfo);
            self.View.E_Lab_ExpRateText.text = $"可以获得经验加成:{(int)(expAdd * 100)}%";
            self.View.E_Lab_ExpAddProText.text = $"可以获得经验加成{(int)(expAdd * 100)}%";
            self.UpdateDuiHuanTimes();
        }

        public static void OnBtn_Close(this DlgWorldLv self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_WorldLv);
        }

        public static void OnButtonDiHuan(this DlgWorldLv self)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;

            if (userInfo.Lv < self.ServerInfo.WorldLv)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("低于世界等级无法兑换");
                return;
            }

            //低于20%经验无法兑换
            ExpConfig expCof = ExpConfigCategory.Instance.Get(userInfo.Lv);
            int costExp = (int)(expCof.UpExp * 0.2f);
            if (userInfo.Exp < costExp)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("低于20%经验无法兑换");
                return;
            }

            int sendGold = 10000 + expCof.RoseGoldPro * 10;
            PopupTipHelp.OpenPopupTip(self.Root(), "兑换金币", $"是否消耗{costExp}经验兑换{sendGold}金币", () => { self.RequestExpToGold().Coroutine(); }, null)
                    .Coroutine();
        }

        public static void UpdateDuiHuanTimes(this DlgWorldLv self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int times = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.ExpToGoldTimes);
            self.View.E_Lab_DuiHuanTimesText.text = $"今日兑换次数:{times}";
        }

        public static async ETTask RequestExpToGold(this DlgWorldLv self)
        {
            await UserInfoNetHelper.ExpToGold(self.Root(), 1);

            self.UpdateDuiHuanTimes();
        }
    }
}