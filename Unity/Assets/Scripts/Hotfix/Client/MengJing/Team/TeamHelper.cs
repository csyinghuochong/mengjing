namespace ET.Client
{
    public static class TeamHelper
    {
        public static int CheckTimesAndLevel(Unit unit, TeamInfo teamInfo)
        {
            return CheckTimesAndLevel(unit, teamInfo.FubenType, teamInfo.SceneId, teamInfo.TeamId, teamInfo.SceneType);
        }

        public static int CheckTimesAndLevel(Unit unit, int fubenType, int fubenid, long teamid, int sceneType)
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
                int totalTimes = GlobalValueConfigCategory.Instance.MaxTeamDungeonsPerDay;
                int times = unit.GetTeamDungeonTimes();
                if (totalTimes - times <= 0)
                {
                    return ErrorCode.ERR_TimesIsNot;
                }
            }
            else
            {
                int totalTimes = GlobalValueConfigCategory.Instance.MaxTeamDungeonsPerDay;
                int times = unit.GetTeamDungeonTimes();

                int totalTimes_2 = GlobalValueConfigCategory.Instance.MaxDailyXieZhuFubens;
                int times_2 = unit.GetTeamDungeonXieZhu();

                if (totalTimes - times <= 0 && totalTimes_2 - times_2 <= 0)
                {
                    return ErrorCode.ERR_TimesIsNot;
                }
            }

            switch (sceneType)
            {
                case MapTypeEnum.TeamDungeon:
                    SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(fubenid);
                    if (userInfoComponent.UserInfo.Lv < sceneConfig.CreateLv)
                    {
                        return ErrorCode.ERR_LevelIsNot;
                    }

                    break;
            }
           
            return ErrorCode.ERR_Success;
        }
    }
}