namespace ET.Client
{
    public static class TeamNetHelper
    {
        public static async ETTask<int> RequestTeamDungeonList(Scene root)
        {
            C2T_TeamDungeonInfoRequest request = new() { UserId = root.GetComponent<UserInfoComponentC>().UserInfo.UserId };
            T2C_TeamDungeonInfoResponse response = (T2C_TeamDungeonInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            root.GetComponent<TeamComponentC>().TeamList = response.TeamList;
            return response.Error;
        }

        public static async ETTask<int> SendTeamApply(Scene root, long teamId, int fubenId, int fubenType, int leaderLv, bool checkfuben)
        {
            TeamComponentC teamComponent = root.GetComponent<TeamComponentC>();

            if (checkfuben && fubenId == 0)
            {
                return ErrorCode.ERR_TeamIsFull;
            }

            TeamInfo teamInfo = teamComponent.GetSelfTeam();
            if (teamInfo != null)
            {
                HintHelp.ShowErrorHint(root, ErrorCode.ERR_IsHaveTeam);
                return ErrorCode.ERR_IsHaveTeam;
            }

            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().UserInfo;
            if (fubenId != 0)
            {
                int errorCode = TeamHelper.CheckTimesAndLevel(UnitHelper.GetMyUnitFromClientScene(root), fubenType, fubenId,
                    userInfo.UserId);
                if (errorCode != 0)
                {
                    HintHelp.ShowErrorHint(root, errorCode);
                    return errorCode;
                }
            }

            if (fubenType == TeamFubenType.XieZhu && userInfo.Lv > leaderLv)
            {
                HintHelp.ShowErrorHint(root, ErrorCode.ERR_TeamerLevelIsNot);
                return ErrorCode.ERR_TeamerLevelIsNot;
            }

            HintHelp.ShowHint(root, "已申请加入队伍！");

            C2T_TeamDungeonApplyRequest request = new() { TeamId = teamId, TeamPlayerInfo = UnitHelper.GetSelfTeamPlayerInfo(root) };
            T2C_TeamDungeonApplyResponse response = (T2C_TeamDungeonApplyResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> RequestTeamDungeonCreate(Scene root, int fubenId, int fubenType)
        {
            TeamComponentC teamComponent = root.GetComponent<TeamComponentC>();

            TeamInfo teamInfo = teamComponent.GetSelfTeam();
            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().UserInfo;
            if (teamInfo != null && teamInfo.SceneId != 0)
            {
                return ErrorCode.ERR_IsNotLeader;
            }

            if (teamInfo != null && teamInfo.TeamId != userInfo.UserId)
            {
                return ErrorCode.ERR_IsNotLeader;
            }

            int errorCode =
                    TeamHelper.CheckTimesAndLevel(UnitHelper.GetMyUnitFromClientScene(root), fubenType, fubenId, userInfo.UserId);
            if (errorCode != ErrorCode.ERR_Success)
            {
                return errorCode;
            }

            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(fubenId);
            if (fubenType == TeamFubenType.XieZhu && sceneConfig.EnterLv > userInfo.Lv - 10)
            {
                return ErrorCode.Err_TeamDungeonXieZhu;
            }

            errorCode = TeamHelper.CheckCanOpenFuben(root, fubenId, fubenType);
            if (errorCode != ErrorCode.ERR_Success)
            {
                return errorCode;
            }

            C2M_TeamDungeonCreateRequest request = new()
            {
                FubenId = fubenId, FubenType = fubenType, TeamPlayerInfo = UnitHelper.GetSelfTeamPlayerInfo(root)
            };
            //创建队伍
            M2C_TeamDungeonCreateResponse response = (M2C_TeamDungeonCreateResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            teamComponent.FubenType = response.FubenType;
            if (teamInfo != null)
            {
                teamInfo.FubenType = response.FubenType;
            }

            teamComponent.ApplyList.Clear();
            return response.Error;
        }

        public static async ETTask<int> TeamRobotRequest(Scene root)
        {
            C2T_TeamRobotRequest request = new() { UnitId = UnitHelper.GetMyUnitFromClientScene(root).Id };
            T2C_TeamRobotResponse response = (T2C_TeamRobotResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask SendLeaveRequest(Scene root)
        {
            MapComponent mapComponent = root.GetComponent<MapComponent>();
            if (mapComponent.SceneType == (int)SceneTypeEnum.TeamDungeon)
            {
                HintHelp.ShowHint(root, "副本中不能离开队伍");
                return;
            }

            C2T_TeamLeaveRequest request = new() { UserId = root.GetComponent<UserInfoComponentC>().UserInfo.UserId };
            T2C_TeamLeaveResponse response = (T2C_TeamLeaveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
        }

        public static async ETTask<int> RequestTeamDungeonOpen(Scene root)
        {
            TeamComponentC teamComponent = root.GetComponent<TeamComponentC>();
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            TeamInfo teamInfo = teamComponent.GetSelfTeam();

            int errorCode = TeamHelper.CheckTimesAndLevel(UnitHelper.GetMyUnitFromClientScene(root), teamInfo);
            if (errorCode != ErrorCode.ERR_Success)
            {
                return errorCode;
            }

            errorCode = TeamHelper.CheckCanOpenFuben(root, teamInfo.SceneId, teamInfo.FubenType);
            if (errorCode != ErrorCode.ERR_Success)
            {
                return errorCode;
            }

            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(teamInfo.SceneId);
            if (teamInfo.PlayerList.Count < sceneConfig.PlayerLimit)
            {
                return ErrorCode.ERR_PlayerIsNot;
            }

            C2M_TeamDungeonOpenRequest request = new() { UserID = userInfoComponent.UserInfo.UserId, FubenType = teamComponent.FubenType };
            M2C_TeamDungeonOpenResponse response = (M2C_TeamDungeonOpenResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            teamInfo.FubenType = response.FubenType;
            teamComponent.ApplyList.Clear();
            return response.Error;
        }
    }
}