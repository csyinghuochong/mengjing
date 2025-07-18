namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class Team_OnRecvTeamInvite : AEvent<Scene, RecvTeamInvite>
    {
        protected override async ETTask Run(Scene scene, RecvTeamInvite args)
        {
            bool blackroom = UnitHelper.IsBackRoom(scene);
            if (blackroom)
            {
                return;
            }

            using (zstring.Block())
            {
                PopupTipHelp.OpenPopupTip(scene, "组队邀请", zstring.Format("{0}邀请你组队", args.m2C_TeamInviteResult.TeamPlayerInfo.PlayerName),
                    () => { TeamNetHelper.AgreeTeamInvite(scene, args.m2C_TeamInviteResult).Coroutine(); }).Coroutine();
            }

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class Team_OnRecvTeamDungeonOpen : AEvent<Scene, RecvTeamDungeonOpen>
    {
        protected override async ETTask Run(Scene scene, RecvTeamDungeonOpen args)
        {
            int SceneType = scene.GetComponent<MapComponent>().MapType;
            if ( SceneType== MapTypeEnum.TeamDungeon
                || SceneType== MapTypeEnum.DragonDungeon)
            {
                return;
            }

            TeamComponentC teamComponent = scene.GetComponent<TeamComponentC>();
            TeamInfo teamInfo = teamComponent.GetSelfTeam();
            if (teamInfo == null)
            {
                return;
            }

            int robotNumber = 0;
            for (int i = 0; i < teamInfo.PlayerList.Count; i++)
            {
                if (teamInfo.PlayerList[i].RobotId > 0)
                {
                    robotNumber++;
                }
            }

            string tip = string.Empty;
            if (robotNumber > 0)
            {
                tip = "<color=#FDFB47>队伍内有人机，副本掉率将降低!</color>\n建议:和其他玩家组队爆率将获得大幅度提升。\n";
            }

            Log.Debug($"ShowWindowAsync(WindowID.WindowID_TeamDungeonPrepare)");
            await scene.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TeamDungeonPrepare);
            DlgTeamDungeonPrepare dlgTeamDungeonPrepare = scene.GetComponent<UIComponent>().GetDlgLogic<DlgTeamDungeonPrepare>();
            dlgTeamDungeonPrepare.OnUpdateUI(args.TeamInfo, ErrorCode.Err_HaveNotPrepare);
        }
    }

    [Event(SceneType.Demo)]
    public class Team_OnTeamDungeonSettlement : AEvent<Scene, TeamDungeonSettlement>
    {
        protected override async ETTask Run(Scene scene, TeamDungeonSettlement args)
        {
            await scene.GetComponent<TimerComponent>().WaitAsync(3000);

            if (scene.GetComponent<UIComponent>().GetDlgLogic<DlgTeamDungeonSettlement>() != null)
                return;

            int sceneTypeEnum = scene.GetComponent<MapComponent>().MapType;
            if (sceneTypeEnum == MapTypeEnum.MainCityScene)
            {
                return;
            }

            await scene.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_TeamDungeonSettlement);
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgTeamDungeonSettlement>().OnUpdateUI(args.m2C_FubenSettlement);
        }
    }

    [Event(SceneType.Demo)]
    public class Team_OnTeamDungeonBoxReward : AEvent<Scene, TeamDungeonBoxReward>
    {
        protected override async ETTask Run(Scene scene, TeamDungeonBoxReward args)
        {
            DlgTeamDungeonSettlement dlgTeamDungeonSettlement = scene.GetComponent<UIComponent>().GetDlgLogic<DlgTeamDungeonSettlement>();
            if (dlgTeamDungeonSettlement != null)
            {
                dlgTeamDungeonSettlement.OnTeamDungeonBoxReward(args.M2CTeamDungeonBoxRewardResult);
            }

            await ETTask.CompletedTask;
        }
    }
}
