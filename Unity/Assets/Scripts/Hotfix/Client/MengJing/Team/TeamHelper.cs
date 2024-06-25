namespace ET.Client
{
    public static class TeamHelper
    {
        public static int CheckCanOpenFuben(Scene root, int fubenId, int fubenType)
        {
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(fubenId);
            //有队伍非队长返回
            TeamInfo teamInfo = root.GetComponent<TeamComponentC>().GetSelfTeam();
            UserInfo userInfo = root.GetComponent<UserInfoComponentC>().UserInfo;
            if (teamInfo != null)
            {
                if (teamInfo != null && teamInfo.PlayerList[0].UserID != userInfo.UserId)
                {
                    return ErrorCode.ERR_IsNotLeader;
                }

                for (int i = 0; i < teamInfo.PlayerList.Count; i++)
                {
                    if (teamInfo.PlayerList[i].PlayerLv < sceneConfig.EnterLv)
                    {
                        return ErrorCode.ERR_TeamerLevelIsNot;
                    }
                }
            }

            return ErrorCode.ERR_Success;
        }

        public static int CheckTimesAndLevel(Unit unit, int fubenType, int fubenid, long teamid)
        {
            UserInfoComponentC userInfoComponent = null;
#if SERVER
            userInfoComponent = unit.GetComponent<UserInfoComponent>();
#else
            userInfoComponent = unit.Root().GetComponent<UserInfoComponentC>();
#endif
            bool leader = teamid == userInfoComponent.UserInfo.UserId;
            if (fubenType == TeamFubenType.Normal
                || fubenType == TeamFubenType.ShenYuan
                || (fubenType == TeamFubenType.XieZhu && !leader))
            {
                int totalTimes = int.Parse(GlobalValueConfigCategory.Instance.Get(19).Value);
                int times = unit.GetTeamDungeonTimes();
                if (totalTimes - times <= 0)
                {
                    return ErrorCode.ERR_TimesIsNot;
                }
            }
            else
            {
                int totalTimes = int.Parse(GlobalValueConfigCategory.Instance.Get(19).Value);
                int times = unit.GetTeamDungeonTimes();

                int totalTimes_2 = int.Parse(GlobalValueConfigCategory.Instance.Get(74).Value);
                int times_2 = unit.GetTeamDungeonXieZhu();

                if (totalTimes - times <= 0 && totalTimes_2 - times_2 <= 0)
                {
                    return ErrorCode.ERR_TimesIsNot;
                }
            }

            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(fubenid);
            if (userInfoComponent.UserInfo.Lv < sceneConfig.CreateLv)
            {
                return ErrorCode.ERR_LevelIsNot;
            }

            return ErrorCode.ERR_Success;
        }
    }
}