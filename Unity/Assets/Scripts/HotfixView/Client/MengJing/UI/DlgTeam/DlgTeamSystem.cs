namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_TeamUpdate_DlgTeamRefresh : AEvent<Scene, RecvTeamUpdate>
    {
        protected override async ETTask Run(Scene scene, RecvTeamUpdate args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgTeam>()?.OnTeamUpdate();
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(ES_TeamItem))]
    [FriendOf(typeof(DlgTeam))]
    public static class DlgTeamSystem
    {
        public static void RegisterUIEvent(this DlgTeam self)
        {
            self.UITeamNodeList[2] = self.View.ES_TeamItem_3.uiTransform.gameObject;
            self.UITeamNodeList[1] = self.View.ES_TeamItem_2.uiTransform.gameObject;
            self.UITeamNodeList[0] = self.View.ES_TeamItem_1.uiTransform.gameObject;

            self.TeamUIList.Add(self.View.ES_TeamItem_1);
            self.TeamUIList.Add(self.View.ES_TeamItem_2);
            self.TeamUIList.Add(self.View.ES_TeamItem_3);

            self.View.E_ButtonLeaveButton.AddListener(() => { self.On_ButtonLeave(); });
            self.View.E_ButtonApplyListButton.AddListener(() => { self.On_ButtonApplyList(); });
            
            self.OnUpdateUI();
            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.RegisterReddot(ReddotType.TeamApply, self.Reddot_TeamApply);
        }

        public static void ShowWindow(this DlgTeam self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgTeam self)
        {
            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.UnRegisterReddot(ReddotType.TeamApply, self.Reddot_TeamApply);
        }

        public static void Reddot_TeamApply(this DlgTeam self, int num)
        {
            self.View.E_ButtonApplyListButton.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void OnTeamUpdate(this DlgTeam self)
        {
            self.OnUpdateUI();
        }

        public static void OnUpdateUI(this DlgTeam self)
        {
            TeamInfo teamInfo = self.Root().GetComponent<TeamComponentC>().GetSelfTeam();
            ES_TeamItem item0 = self.TeamUIList[0];
            ES_TeamItem item1 = self.TeamUIList[1];
            ES_TeamItem item2 = self.TeamUIList[2];
            item0.OnUpdateItem(null);
            item1.OnUpdateItem(null);
            item2.OnUpdateItem(null);

            if (teamInfo == null)
            {
                return;
            }

            for (int i = 0; i < teamInfo.PlayerList.Count; i++)
            {
                ES_TeamItem esTeamItem = self.TeamUIList[i];
                esTeamItem.OnUpdateItem(teamInfo.PlayerList[i]);
            }
        }

        public static void SendLeaveRequest(this DlgTeam self)
        {
            TeamNetHelper.SendLeaveRequest(self.Root()).Coroutine();
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Team);
        }

        public static void On_ButtonApplyList(this DlgTeam self)
        {
            ReddotComponentC redPointComponent = self.Root().GetComponent<ReddotComponentC>();
            redPointComponent.RemoveReddont(ReddotType.TeamApply);

            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TeamApplyList).Coroutine();
        }

        public static void On_ButtonLeave(this DlgTeam self)
        {
            bool isLeader = self.Root().GetComponent<TeamComponentC>().IsTeamLeader();

            PopupTipHelp.OpenPopupTip(self.Root(), "我的队伍", isLeader ? "是否解散队伍" : "是否离开队伍？", () => { self.SendLeaveRequest(); }).Coroutine();
        }
    }
}
