using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgSolo))]
    public static class DlgSoloSystem
    {
        public static void RegisterUIEvent(this DlgSolo self)
        {
            self.View.E_ButtonMatchButton.AddListenerAsync(self.OnButtonMatchButton);
            
            self.View.EG_UISoloResultShowRectTransform.gameObject.SetActive(false);
            self.Init();
        }

        public static void ShowWindow(this DlgSolo self, Entity contextData = null)
        {
        }

        public static void Init(this DlgSolo self)
        {
            self.ShowZhanJi().Coroutine();
            self.ShowPiPeiTime().Coroutine();
        }

        public static async ETTask OnButtonMatchButton(this DlgSolo self)
        {
            if (self.PipeiStatus && self.Root().GetComponent<BattleMessageComponent>().SoloPiPeiStartTime > 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("已经匹配，请耐心等候...");
                return;
            }

            int errorCode = await ActivityNetHelper.SoloMatch(self.Root());
            if (errorCode == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("开始匹配，请耐心等候...");
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
            // response.SoloPlayerResultInfoList.Add(new SoloPlayerResultInfo() { Name = "测试角色1", Occ = 1, Combat = 3000 });
            // response.SoloPlayerResultInfoList.Add(new SoloPlayerResultInfo() { Name = "测试角色2", Occ = 2, Combat = 2000 });
            // response.SoloPlayerResultInfoList.Add(new SoloPlayerResultInfo() { Name = "测试角色3", Occ = 1, Combat = 1000 });

            for (int i = 0; i < response.SoloPlayerResultInfoList.Count; i++)
            {
                GameObject gameObject = UnityEngine.Object.Instantiate(self.View.EG_UISoloResultShowRectTransform.gameObject);
                CommonViewHelper.SetParent(gameObject, self.View.EG_SoloResultListNodeRectTransform.gameObject);
                gameObject.SetActive(true);
                ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();
                rc.Get<GameObject>("Text_Name").GetComponent<Text>().text = response.SoloPlayerResultInfoList[i].Name;
                rc.Get<GameObject>("Text_Rank").GetComponent<Text>().text = (i + 1).ToString();
                using (zstring.Block())
                {
                    rc.Get<GameObject>("Text_Combat").GetComponent<Text>().text =
                            zstring.Format("{0}胜{1}败", response.SoloPlayerResultInfoList[i].WinNum, response.SoloPlayerResultInfoList[i].FailNum);
                }

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
                self.View.E_Text_MatchText.text = "点击下方开始匹配对手";
                return;
            }

            long startTime = self.Root().GetComponent<BattleMessageComponent>().SoloPiPeiStartTime;

            DateTime startDateTime = TimeInfo.Instance.ToDateTime(startTime);

            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (!self.IsDisposed)
            {
                DateTime nowDateTime = TimeInfo.Instance.ToDateTime(TimeHelper.ClientNow());

                TimeSpan timeCha = nowDateTime - startDateTime;

                using (zstring.Block())
                {
                    self.View.E_Text_MatchText.text = zstring.Format("匹配时间:{0}分{1}秒", timeCha.Minutes, timeCha.Seconds);
                }

                await timerComponent.WaitAsync(1000);
                if (self.IsDisposed)
                {
                    break;
                }
            }
        }
    }
}
