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

            PopupTipHelp.OpenPopupTip(scene, "组队邀请", $"{args.m2C_TeamInviteResult.TeamPlayerInfo.PlayerName}邀请你组队",
                () => { TeamNetHelper.AgreeTeamInvite(scene, args.m2C_TeamInviteResult).Coroutine(); }).Coroutine();

            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class Team_OnTeamDungeonOpen : AEvent<Scene, RecvTeamDungeonOpen>
    {
        protected override async ETTask Run(Scene scene, RecvTeamDungeonOpen args)
        {
            if (scene.GetComponent<MapComponent>().SceneType == SceneTypeEnum.TeamDungeon)
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
                tip = "<color=#FDFB47>队伍内有人机,副本掉率将降低!</color>\n建议:和其他玩家组队爆率将获得大幅度提升\n";
            }

            RecvTeamDungeonPrepare(scene, args).Coroutine();

            await ETTask.CompletedTask;
        }

        private async ETTask RecvTeamDungeonPrepare(Scene scene, RecvTeamDungeonOpen args)
        {
            // UI uI = await UIHelper.Create(zoneScene, UIType.UITeamDungeonPrepare);
            // uI.GetComponent<UITeamDungeonPrepareComponent>().OnUpdateUI(args.TeamInfo, ErrorCode.Err_HaveNotPrepare);
            FlyTipComponent.Instance.ShowFlyTip("未创建 UITeamDungeonPrepareComponent");
            await ETTask.CompletedTask;
        }
    }

    [Event(SceneType.Demo)]
    public class Team_OnTeamDungeonSettlement : AEvent<Scene, TeamDungeonSettlement>
    {
        protected override async ETTask Run(Scene scene, TeamDungeonSettlement args)
        {
            await scene.GetComponent<TimerComponent>().WaitAsync(3000);

            // if (UIHelper.GetUI(args.ZoneScene, UIType.UITeamDungeonSettlement) != null)
            //     return;

            int sceneTypeEnum = scene.GetComponent<MapComponent>().SceneType;
            if (sceneTypeEnum == (int)SceneTypeEnum.MainCityScene)
            {
                return;
            }

            FlyTipComponent.Instance.ShowFlyTip("未创建 UITeamDungeonSettlement");
            // UI ui = await UIHelper.Create(args.ZoneScene, UIType.UITeamDungeonSettlement);
            // ui.GetComponent<UITeamDungeonSettlementComponent>().OnUpdateUI(args.m2C_FubenSettlement);
        }
    }

    [Event(SceneType.Demo)]
    public class Team_OnTeamDungeonBoxReward : AEvent<Scene, TeamDungeonBoxReward>
    {
        protected override async ETTask Run(Scene scene, TeamDungeonBoxReward args)
        {
            FlyTipComponent.Instance.ShowFlyTip("未创建 UITeamDungeonSettlement");

            // UI ui = UIHelper.GetUI(scene, UIType.UITeamDungeonSettlement);
            // if (ui != null)
            // {
            //     ui.GetComponent<UITeamDungeonSettlementComponent>().OnTeamDungeonBoxReward(args.m2C_FubenSettlement);
            // }

            await ETTask.CompletedTask;
        }
    }
}