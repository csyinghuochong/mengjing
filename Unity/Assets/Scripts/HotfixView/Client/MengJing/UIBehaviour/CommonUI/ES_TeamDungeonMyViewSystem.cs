using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_TeamItem))]
    [EntitySystemOf(typeof (ES_TeamDungeonMy))]
    [FriendOfAttribute(typeof (ES_TeamDungeonMy))]
    public static partial class ES_TeamDungeonMySystem
    {
        [EntitySystem]
        private static void Awake(this ES_TeamDungeonMy self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Button_EnterButton.AddListener(() => { self.OnButton_Enter().Coroutine(); });
            self.E_Button_CallButton.AddListener(self.OnButton_Call);
            self.E_Button_LeaveButton.AddListener(self.OnButton_Leave);
            self.E_ButtonApplyListButton.AddListener(self.OnButtonApplyList);
            self.E_Button_RobotButton.AddListener(() => { self.OnButton_Robot().Coroutine(); });

            self.UITeamNodeList[0] = self.ES_TeamItem1.uiTransform.gameObject;
            self.UITeamNodeList[1] = self.ES_TeamItem2.uiTransform.gameObject;
            self.UITeamNodeList[2] = self.ES_TeamItem3.uiTransform.gameObject;

            self.OnInitUI();

            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.RegisterReddot(ReddotType.TeamApply, self.Reddot_TeamApply);
        }

        [EntitySystem]
        private static void Destroy(this ES_TeamDungeonMy self)
        {
            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.UnRegisterReddot(ReddotType.TeamApply, self.Reddot_TeamApply);
            self.DestroyWidget();
        }

        public static void Reddot_TeamApply(this ES_TeamDungeonMy self, int num)
        {
            self.E_ButtonApplyListButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void OnInitUI(this ES_TeamDungeonMy self)
        {
            self.TeamUIList.Add(self.ES_TeamItem1);
            self.TeamUIList.Add(self.ES_TeamItem2);
            self.TeamUIList.Add(self.ES_TeamItem3);
        }

        public static async ETTask OnButton_Robot(this ES_TeamDungeonMy self)
        {
            BattleMessageComponent battleMessageComponent = self.Root().GetComponent<BattleMessageComponent>();
            long lastcallTime = battleMessageComponent.CallTeamRobotTime;
            if (TimeHelper.ServerNow() - lastcallTime < TimeHelper.Minute)
            {
                return;
            }

            await TeamNetHelper.TeamRobotRequest(self.Root());
            battleMessageComponent.CallTeamRobotTime = TimeHelper.ServerNow();
        }

        public static void OnButtonApplyList(this ES_TeamDungeonMy self)
        {
            ReddotComponentC redPointComponent = self.Root().GetComponent<ReddotComponentC>();
            redPointComponent.RemoveReddont(ReddotType.TeamApply);

            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TeamApplyList).Coroutine();
        }

        public static void OnButton_Leave(this ES_TeamDungeonMy self)
        {
            bool isLeader = TeamHelper.IsTeamLeader(self.Root());

            PopupTipHelp.OpenPopupTip(self.Root(), "我的队伍", isLeader? "是否离开队伍" : "是否离开队伍？",
                () => { TeamNetHelper.SendLeaveRequest(self.Root()).Coroutine(); }).Coroutine();
        }

        public static void OnButton_Call(this ES_TeamDungeonMy self)
        {
            TeamComponentC teamComponent = self.Root().GetComponent<TeamComponentC>();
            TeamInfo teamInfo = teamComponent.GetSelfTeam();
            if (teamInfo == null || teamInfo.SceneId == 0)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("没有副本队伍");
                return;
            }

            BattleMessageComponent battleMessageComponent = self.Root().GetComponent<BattleMessageComponent>();
            if (battleMessageComponent.CanShout())
            {
                string text =
                        $" 副本:{SceneConfigCategory.Instance.Get(teamInfo.SceneId).Name}开启冒险,现邀请你的加入！<color=#B5FF28>点击申请加入</color> <link=team_{teamInfo.TeamId}_{teamInfo.SceneId}_{teamInfo.FubenType}_{teamInfo.PlayerList[0].PlayerLv}></link>";
                ChatNetHelper.RequestSendChat(self.Root(), ChannelEnum.Word, text).Coroutine();
                FlyTipComponent.Instance.ShowFlyTipDi("已发送！");
            }
            else
            {
                FlyTipComponent.Instance.ShowFlyTipDi("喊话过于频繁！");
            }
        }

        public static async ETTask OnButton_Enter(this ES_TeamDungeonMy self)
        {
            TeamInfo teamInfo = self.Root().GetComponent<TeamComponentC>().GetSelfTeam();
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(teamInfo.SceneId);
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (teamInfo.FubenType == TeamFubenType.XieZhu && sceneConfig.EnterLv <= userInfo.Lv - 10)
            {
                int totalTimes = int.Parse(GlobalValueConfigCategory.Instance.Get(19).Value);
                int times = unit.GetTeamDungeonTimes();

                int totalTimes_2 = int.Parse(GlobalValueConfigCategory.Instance.Get(74).Value);
                int times_2 = unit.GetTeamDungeonXieZhu();

                if (totalTimes - times > 0 && totalTimes_2 - times_2 <= 0)
                {
                    PopupTipHelp.OpenPopupTip(self.Root(), "系统提示", $"帮助副本次数已尽，继续则消耗正常次数", async () =>
                    {
                        int errorCode = await TeamNetHelper.RequestTeamDungeonOpen(self.Root());
                        if (errorCode != ErrorCode.ERR_Success)
                        {
                            HintHelp.ShowErrorHint(self.Root(), errorCode);
                        }
                    }, null).Coroutine();
                    return;
                }
            }

            int errorCode = await TeamNetHelper.RequestTeamDungeonOpen(self.Root());
            if (errorCode != ErrorCode.ERR_Success)
            {
                HintHelp.ShowErrorHint(self.Root(), errorCode);
            }
        }

        public static void OnUpdateUI(this ES_TeamDungeonMy self)
        {
            TeamComponentC teamComponent = self.Root().GetComponent<TeamComponentC>();
            TeamInfo teamInfo = teamComponent.GetSelfTeam();
            self.TeamUIList[0].OnUpdateItem(null);
            self.TeamUIList[1].OnUpdateItem(null);
            self.TeamUIList[2].OnUpdateItem(null);
            if (teamInfo == null)
            {
                return;
            }

            for (int i = 0; i < teamInfo.PlayerList.Count; i++)
            {
                self.TeamUIList[i].OnUpdateItem(teamInfo.PlayerList[i]);
            }

            if (teamInfo.SceneId == 0)
            {
                return;
            }

            string addStr = "";
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(teamInfo.SceneId);
            if (teamInfo.FubenType == TeamFubenType.XieZhu)
            {
                addStr = "(帮助模式)";
            }

            if (teamInfo.FubenType == TeamFubenType.ShenYuan)
            {
                addStr = "(深渊模式)";
            }

            self.E_Lab_FuBenNameText.text = sceneConfig.Name + addStr;
            self.E_Lab_FuBenLvText.text = $"{GameSettingLanguge.LoadLocalization("等级")}: {sceneConfig.EnterLv} - 50";
        }
    }
}