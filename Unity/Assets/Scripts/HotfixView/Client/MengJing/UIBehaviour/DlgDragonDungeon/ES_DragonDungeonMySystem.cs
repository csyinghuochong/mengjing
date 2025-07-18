using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_TeamItem))]
    [EntitySystemOf(typeof(ES_DragonDungeonMy))]
    [FriendOfAttribute(typeof(ES_DragonDungeonMy))]
    public static partial class ES_DragonDungeonMySystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ES_DragonDungeonMy self, UnityEngine.Transform transform)
        {
            self.uiTransform = transform;

            self.E_Button_EnterButton.AddListener(() => { self.OnButton_EnterButton().Coroutine(); });
            self.E_Button_CallButton.AddListener(self.OnButton_CallButton);
            self.E_Button_LeaveButton.AddListener(self.OnButton_LeaveButton);
            self.E_ButtonApplyListButton.AddListener(self.OnButtonApplyListButton);
            self.E_Button_RobotButton.AddListener(() => { self.OnButton_RobotButton().Coroutine(); });

            self.UITeamNodeList[0] = self.ES_TeamItem_1.uiTransform.gameObject;
            self.UITeamNodeList[1] = self.ES_TeamItem_2.uiTransform.gameObject;
            self.UITeamNodeList[2] = self.ES_TeamItem_3.uiTransform.gameObject;

            self.OnInitUI();

            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.RegisterReddot(ReddotType.TeamApply, self.Reddot_TeamApply);
        }
        [EntitySystem]
        private static void Destroy(this ET.Client.ES_DragonDungeonMy self)
        {
            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.UnRegisterReddot(ReddotType.TeamApply, self.Reddot_TeamApply);
            self.DestroyWidget();
        }
        
         public static void Reddot_TeamApply(this ES_DragonDungeonMy self, int num)
        {
            self.E_ButtonApplyListButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void OnInitUI(this ES_DragonDungeonMy self)
        {
            self.TeamUIList.Add(self.ES_TeamItem_1);
            self.TeamUIList.Add(self.ES_TeamItem_2);
            self.TeamUIList.Add(self.ES_TeamItem_3);
        }

        public static async ETTask OnButton_RobotButton(this ES_DragonDungeonMy self)
        {
            BattleMessageComponent battleMessageComponent = self.Root().GetComponent<BattleMessageComponent>();
            long lastcallTime = battleMessageComponent.CallTeamRobotTime;
            if (TimeHelper.ServerNow() - lastcallTime < TimeHelper.Minute)
            {
                return;
            }

            await TeamNetHelper.TeamRobotRequest(self.Root(), MapTypeEnum.DragonDungeon);
            battleMessageComponent.CallTeamRobotTime = TimeHelper.ServerNow();
        }

        public static void OnButtonApplyListButton(this ES_DragonDungeonMy self)
        {
            ReddotComponentC redPointComponent = self.Root().GetComponent<ReddotComponentC>();
            redPointComponent.RemoveReddont(ReddotType.TeamApply);

            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TeamApplyList).Coroutine();
        }

        public static void OnButton_LeaveButton(this ES_DragonDungeonMy self)
        {
            bool isLeader = self.Root().GetComponent<TeamComponentC>().IsTeamLeader();

            PopupTipHelp.OpenPopupTip(self.Root(), "我的队伍", isLeader ? "是否离开队伍" : "是否离开队伍？",
                () => { TeamNetHelper.SendLeaveRequest(self.Root()).Coroutine(); }).Coroutine();
        }

        public static void OnButton_CallButton(this ES_DragonDungeonMy self)
        {
            TeamComponentC teamComponent = self.Root().GetComponent<TeamComponentC>();
            TeamInfo teamInfo = teamComponent.GetSelfTeam();
            if (teamInfo == null || teamInfo.SceneId == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("没有副本队伍");
                return;
            }

            CellGenerateConfig cellGenerateConfig = CellGenerateConfigCategory.Instance.Get(teamInfo.SceneId);
            BattleMessageComponent battleMessageComponent = self.Root().GetComponent<BattleMessageComponent>();
            if (battleMessageComponent.CanShout())
            {
                using (zstring.Block())
                {
                    string text = zstring.Format(" 副本:{0}开启冒险,现邀请你的加入！<color=#B5FF28>点击申请加入</color> <link=team_{1}_{2}_{3}_{4}_{5}></link>",
                        cellGenerateConfig.ChapterName, teamInfo.TeamId, teamInfo.SceneId, teamInfo.FubenType,
                        teamInfo.PlayerList[0].PlayerLv, MapTypeEnum.DragonDungeon);
                    ChatNetHelper.RequestSendChat(self.Root(), ChannelEnum.Word, text).Coroutine();
                }

                FlyTipComponent.Instance.ShowFlyTip("已发送！");
            }
            else
            {
                FlyTipComponent.Instance.ShowFlyTip("喊话过于频繁！");
            }
        }

        public static async ETTask OnButton_EnterButton(this ES_DragonDungeonMy self)
        {
            TeamInfo teamInfo = self.Root().GetComponent<TeamComponentC>().GetSelfTeam();
            CellGenerateConfig sceneConfig = CellGenerateConfigCategory.Instance.Get(teamInfo.SceneId);
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (teamInfo.FubenType == TeamFubenType.XieZhu && sceneConfig.EnterLv <= userInfo.Lv - 10)
            {
                int totalTimes = GlobalValueConfigCategory.Instance.MaxTeamDungeonsPerDay;
                int times = unit.GetTeamDungeonTimes();

                int totalTimes_2 = GlobalValueConfigCategory.Instance.MaxDailyXieZhuFubens;
                int times_2 = unit.GetTeamDungeonXieZhu();

                if (totalTimes - times > 0 && totalTimes_2 - times_2 <= 0)
                {
                    PopupTipHelp.OpenPopupTip(self.Root(), "系统提示", "帮助副本次数已尽，继续则消耗正常次数。", async () =>
                    {
                        int errorCode = await TeamNetHelper.RequestTeamDungeonOpen(self.Root(), MapTypeEnum.DragonDungeon);
                        if (errorCode != ErrorCode.ERR_Success)
                        {
                            HintHelp.ShowErrorHint(self.Root(), errorCode);
                        }
                    }, null).Coroutine();
                    return;
                }
            }

            int errorCode = await TeamNetHelper.RequestTeamDungeonOpen(self.Root(), MapTypeEnum.DragonDungeon);
            if (errorCode != ErrorCode.ERR_Success)
            {
                HintHelp.ShowErrorHint(self.Root(), errorCode);
            }
        }

        public static void OnUpdateUI(this ES_DragonDungeonMy self)
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
            CellGenerateConfig sceneConfig = CellGenerateConfigCategory.Instance.Get(teamInfo.SceneId);
            if (teamInfo.FubenType == TeamFubenType.XieZhu)
            {
                addStr = "(帮助模式)";
            }

            if (teamInfo.FubenType == TeamFubenType.ShenYuan)
            {
                addStr = "(深渊模式)";
            }

            using (zstring.Block())
            {
                self.E_Lab_FuBenNameText.text = zstring.Format("{0}{1}", sceneConfig.ChapterName, addStr);
                self.E_Lab_FuBenLvText.text =
                        zstring.Format("{0}: {1} - 50", LanguageComponent.Instance.LoadLocalization("等级"), sceneConfig.EnterLv);
            }
        }
    }

}
