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
    }
}