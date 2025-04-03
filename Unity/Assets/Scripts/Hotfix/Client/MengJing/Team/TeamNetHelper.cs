namespace ET.Client
{
    public static class TeamNetHelper
    {
        public static async ETTask<int> RequestTeamDungeonList(Scene root, int sceneType)
        {
            C2T_TeamDungeonInfoRequest request = C2T_TeamDungeonInfoRequest.Create();
            request.UserId = root.GetComponent<UserInfoComponentC>().UserInfo.UserId;
            request.SceneType = sceneType;

            T2C_TeamDungeonInfoResponse response = (T2C_TeamDungeonInfoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            root.GetComponent<TeamComponentC>().TeamList = response.TeamList;
            return response.Error;
        }

        public static async ETTask<int> TeamDungeonApplyRequest(Scene root, long teamId, int fubenId, int fubenType, int leaderLv, bool checkfuben, int sceneType)
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
                    userInfo.UserId, sceneType);
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

            C2T_TeamDungeonApplyRequest request = C2T_TeamDungeonApplyRequest.Create();
            request.TeamId = teamId;
            request.TeamPlayerInfo = UnitHelper.GetSelfTeamPlayerInfo(root);

            T2C_TeamDungeonApplyResponse response = (T2C_TeamDungeonApplyResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response.Error;
        }

        public static async ETTask<int> RequestTeamDungeonCreate(Scene root, int fubenId, int fubenType, int sceneType)
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

            int errorCode = ErrorCode.ERR_Success;

            switch (sceneType)
            {
                case MapTypeEnum.TeamDungeon:
                    errorCode =
                            TeamHelper.CheckTimesAndLevel(UnitHelper.GetMyUnitFromClientScene(root), fubenType, fubenId, userInfo.UserId,sceneType);
                    if (errorCode != ErrorCode.ERR_Success)
                    {
                        return errorCode;
                    }

                    SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(fubenId);
                    if (fubenType == TeamFubenType.XieZhu && sceneConfig.EnterLv > userInfo.Lv - 10)
                    {
                        return ErrorCode.Err_TeamDungeonXieZhu;
                    }

                    errorCode = teamComponent.CheckCanOpenFuben(fubenId, fubenType);
                    if (errorCode != ErrorCode.ERR_Success)
                    {
                        return errorCode;
                    }
                    break;
                case MapTypeEnum.DragonDungeon:
                    break;
                default:
                    break;
            }
            C2M_TeamDungeonCreateRequest request = C2M_TeamDungeonCreateRequest.Create();
            request.FubenId = fubenId;
            request.FubenType = fubenType;
            request.SceneType = sceneType;
            request.TeamPlayerInfo = UnitHelper.GetSelfTeamPlayerInfo(root);

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

        public static async ETTask<int> TeamRobotRequest(Scene root, int sceneType)
        {
            C2T_TeamRobotRequest request = C2T_TeamRobotRequest.Create();
            request.UnitId = UnitHelper.GetMyUnitFromClientScene(root).Id;
            request.SceneType = sceneType;
            T2C_TeamRobotResponse response = (T2C_TeamRobotResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask SendLeaveRequest(Scene root)
        {
            MapComponent mapComponent = root.GetComponent<MapComponent>();
            if (mapComponent.MapType == (int)MapTypeEnum.TeamDungeon 
                || mapComponent.MapType == (int)MapTypeEnum.DragonDungeon )
            {
                HintHelp.ShowHint(root, "副本中不能离开队伍");
                return;
            }

            C2T_TeamLeaveRequest request = C2T_TeamLeaveRequest.Create();
            request.UserId = root.GetComponent<UserInfoComponentC>().UserInfo.UserId;

            T2C_TeamLeaveResponse response = (T2C_TeamLeaveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
        }

        public static async ETTask<int> RequestTeamDungeonOpen(Scene root, int sceneType)
        {
            TeamComponentC teamComponent = root.GetComponent<TeamComponentC>();
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            TeamInfo teamInfo = teamComponent.GetSelfTeam();

            int errorCode = ErrorCode.ERR_Success;

            switch (sceneType)
            {
                case MapTypeEnum.TeamDungeon:
                    errorCode = TeamHelper.CheckTimesAndLevel(UnitHelper.GetMyUnitFromClientScene(root), teamInfo);
                    if (errorCode != ErrorCode.ERR_Success)
                    {
                        return errorCode;
                    }

                    errorCode = teamComponent.CheckCanOpenFuben(teamInfo.SceneId, teamInfo.FubenType);
                    if (errorCode != ErrorCode.ERR_Success)
                    {
                        return errorCode;
                    }

                    SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(teamInfo.SceneId);
                    if (teamInfo.PlayerList.Count < sceneConfig.PlayerLimit)
                    {
                        return ErrorCode.ERR_PlayerIsNot;
                    }
                    break;
                case MapTypeEnum.DragonDungeon: 
                    if (teamInfo.PlayerList.Count < 1)  //地下城组队人数限制
                    {
                        return ErrorCode.ERR_PlayerIsNot;
                    }
                    break;
                default:
                    break;
            }
            
            C2M_TeamDungeonOpenRequest request = C2M_TeamDungeonOpenRequest.Create();
            request.UserID = userInfoComponent.UserInfo.UserId;
            request.FubenType = teamComponent.FubenType;
            request.SceneType = sceneType;
            M2C_TeamDungeonOpenResponse response = (M2C_TeamDungeonOpenResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            teamInfo.FubenType = response.FubenType;
            teamComponent.ApplyList.Clear();
            return response.Error;
        }

        public static async ETTask<int> TeamDungeonAgreeRequest(Scene root, TeamPlayerInfo m2C_Team, int code)
        {
            TeamComponentC teamComponent = root.GetComponent<TeamComponentC>();

            for (int i = teamComponent.ApplyList.Count - 1; i >= 0; i--)
            {
                if (teamComponent.ApplyList[i].UserID == m2C_Team.UserID)
                {
                    teamComponent.ApplyList.RemoveAt(i);
                    break;
                }
            }

            if (code == 0)
            {
                return ErrorCode.ERR_Success;
            }

            C2T_TeamDungeonAgreeRequest request = C2T_TeamDungeonAgreeRequest.Create();
            request.TeamId = root.GetComponent<UserInfoComponentC>().UserInfo.UserId;
            request.TeamPlayerInfo = m2C_Team;

            T2C_TeamDungeonAgreeResponse repose = (T2C_TeamDungeonAgreeResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return repose.Error;
        }

        public static void TeamPickRequest(Scene root, Unit dropInfo, int need)
        {
            C2M_TeamPickRequest request = C2M_TeamPickRequest.Create();
            request.DropItem = dropInfo.Id;
            request.Need = need;

            root.GetComponent<ClientSenderCompnent>().Send(request);
        }

        public static async ETTask AgreeTeamInvite(Scene root, M2C_TeamInviteResult m2C_Team)
        {
            C2T_TeamAgreeRequest request = C2T_TeamAgreeRequest.Create();

            request.TeamPlayerInfo_1 = m2C_Team.TeamPlayerInfo;
            request.TeamPlayerInfo_2 = UnitHelper.GetSelfTeamPlayerInfo(root);

            T2C_TeamAgreeResponse response = (T2C_TeamAgreeResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
        }

        public static async ETTask<int> TeamDungeonPrepareRequest(Scene root, TeamInfo teamInfo, int prepare)
        {
            C2M_TeamDungeonPrepareRequest request = C2M_TeamDungeonPrepareRequest.Create();
            request.TeamInfo = teamInfo;
            request.Prepare = prepare;

            M2C_TeamDungeonPrepareResponse response = (M2C_TeamDungeonPrepareResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<M2C_TeamDungeonBoxRewardResponse> TeamDungeonBoxRewardRequest(Scene root, int boxIndex, RewardItem rewardItem)
        {
            C2M_TeamDungeonBoxRewardRequest request = C2M_TeamDungeonBoxRewardRequest.Create();
            request.BoxIndex = boxIndex;
            request.RewardItem = rewardItem;

            M2C_TeamDungeonBoxRewardResponse response =
                    (M2C_TeamDungeonBoxRewardResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            return response;
        }

        public static async ETTask TeamKickOutRequest(Scene root, long userId)
        {
            MapComponent mapComponent = root.GetComponent<MapComponent>();
            if (mapComponent.MapType == (int)MapTypeEnum.TeamDungeon)
            {
                HintHelp.ShowHint(root, "副本中不能踢人");
                return;
            }

            C2T_TeamKickOutRequest request = C2T_TeamKickOutRequest.Create();
            request.UserId = userId;
            T2C_TeamKickOutResponse response = (T2C_TeamKickOutResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
        }

        public static async ETTask TeamInviteRequest(Scene root, long userID, TeamPlayerInfo teamPlayerInfo)
        {
            C2T_TeamInviteRequest request = C2T_TeamInviteRequest.Create();
            request.UserID = userID;
            request.TeamPlayerInfo = teamPlayerInfo;
            T2C_TeamInviteResponse response = (T2C_TeamInviteResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
        }

        public static async ETTask<M2C_TeamerPositionResponse> TeamerPositionRequest(Scene root)
        {
            C2M_TeamerPositionRequest request = C2M_TeamerPositionRequest.Create();

            M2C_TeamerPositionResponse response = (M2C_TeamerPositionResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }
    }
}