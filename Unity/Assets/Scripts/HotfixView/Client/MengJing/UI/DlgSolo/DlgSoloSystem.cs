using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgSolo))]
    public static class DlgSoloSystem
    {
        public static void RegisterUIEvent(this DlgSolo self)
        {
            self.View.E_ButtonMatchButton.AddListenerAsync(self.OnButtonMatch);
        }

        public static void ShowWindow(this DlgSolo self, Entity contextData = null)
        {
            self.View.EG_UISoloResultShowRectTransform.gameObject.SetActive(false);
            self.Init();
        }

        public static void Init(this DlgSolo self)
        {
            self.ShowZhanJi().Coroutine();
            self.ShowPiPeiTime().Coroutine();
        }

        public static async ETTask OnButtonMatch(this DlgSolo self)
        {
            if (self.PipeiStatus && self.Root().GetComponent<BattleMessageComponent>().SoloPiPeiStartTime > 0)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("已经匹配，请耐心等候...");
                return;
            }

            int errorCode = await ActivityNetHelper.SoloMatch(self.Root());
            if (errorCode == 0)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("开始匹配，请耐心等候...");
                self.PipeiStatus = true;
            }

            self.Root().GetComponent<BattleMessageComponent>().SoloPiPeiStartTime = TimeHelper.ServerNow();

            self.ShowPiPeiTime().Coroutine();
        }

        public static async ETTask ShowZhanJi(this DlgSolo self)
        {
            S2C_SoloMyInfoResponse response = await ActivityNetHelper.SoloMyInfo(self.Root());
            if (response.Error == ErrorCode.ERR_Success)
            {
                self.View.E_Text_ResultText.text = $"{response.WinTime}胜{response.FailTime}败";
                self.View.E_Text_IntegraListText.text = $"积分:{response.MathTime}";
            }

            // 测试数据
            response.SoloPlayerResultInfoList.Add(new SoloPlayerResultInfo() { Name = "测试角色1", Occ = 1, Combat = 3000 });
            response.SoloPlayerResultInfoList.Add(new SoloPlayerResultInfo() { Name = "测试角色2", Occ = 2, Combat = 2000 });
            response.SoloPlayerResultInfoList.Add(new SoloPlayerResultInfo() { Name = "测试角色3", Occ = 1, Combat = 1000 });

            for (int i = 0; i < response.SoloPlayerResultInfoList.Count; i++)
            {
                GameObject gameObject = UnityEngine.Object.Instantiate(self.View.EG_UISoloResultShowRectTransform.gameObject);
                CommonViewHelper.SetParent(gameObject, self.View.EG_SoloResultListNodeRectTransform.gameObject);
                gameObject.SetActive(true);
                ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();
                rc.Get<GameObject>("Text_Name").GetComponent<Text>().text = response.SoloPlayerResultInfoList[i].Name;
                rc.Get<GameObject>("Text_Rank").GetComponent<Text>().text = (i + 1).ToString();
                rc.Get<GameObject>("Text_Combat").GetComponent<Text>().text =
                        $"{response.SoloPlayerResultInfoList[i].WinNum}胜{response.SoloPlayerResultInfoList[i].FailNum}败";
                rc.Get<GameObject>("Text_JiFen").GetComponent<Text>().text = response.SoloPlayerResultInfoList[i].Combat.ToString();
                rc.Get<GameObject>("ImageHeadIcon").GetComponent<Image>().sprite =
                        self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(
                            ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, response.SoloPlayerResultInfoList[i].Occ.ToString()));
            }
        }

        public static async ETTask ShowPiPeiTime(this DlgSolo self)
        {
            if (self.Root().GetComponent<BattleMessageComponent>().SoloPiPeiStartTime == 0)
            {
                self.View.E_Text_MatchText.text = $"点击下方开始匹配对手";
                return;
            }

            long startTime = self.Root().GetComponent<BattleMessageComponent>().SoloPiPeiStartTime;

            DateTime startDateTime = TimeInfo.Instance.ToDateTime(startTime);

            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (!self.IsDisposed)
            {
                DateTime nowDateTime = TimeInfo.Instance.ToDateTime(TimeHelper.ClientNow());

                TimeSpan timeCha = nowDateTime - startDateTime;

                self.View.E_Text_MatchText.text = $"匹配时间:{timeCha.Minutes}分{timeCha.Seconds}秒";

                await timerComponent.WaitAsync(1000);
                if (self.IsDisposed)
                {
                    break;
                }
            }
        }
    }
}