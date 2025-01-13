namespace ET.Client
{
    [FriendOf(typeof(TeamComponentC))]
    [EntitySystemOf(typeof(TeamComponentC))]
    public static partial class TeamComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this TeamComponentC self)
        {
        }

        public static TeamInfo GetTeamInfo(this TeamComponentC self, long teamId)
        {
            for (int i = 0; i < self.TeamList.Count; i++)
            {
                TeamInfo teamInfo = self.TeamList[i];
                if (teamInfo.TeamId == teamId)
                {
                    return teamInfo;
                }
            }
            return null;
        }
        
        public static TeamInfo GetSelfTeam(this TeamComponentC self)
        {
            long userId = self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId;

            for (int i = 0; i < self.TeamList.Count; i++)
            {
                TeamInfo teamInfo = self.TeamList[i];
                for (int k = 0; k < teamInfo.PlayerList.Count; k++)
                {
                    if (teamInfo.PlayerList[k].UserID == userId)
                    {
                        return teamInfo;
                    }
                }
            }

            return null;
        }

        public static bool IsHaveTeam(this TeamComponentC self)
        {
            return self.GetSelfTeam() != null;
        }

        public static bool IsTeamLeader(this TeamComponentC self)
        {
            TeamInfo teamInfo = self.GetSelfTeam();
            long myUserId = self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId;
            return teamInfo != null && teamInfo.PlayerList[0].UserID == myUserId;
        }

        public static int CheckCanOpenFuben(this TeamComponentC self, int fubenId, int fubenType)
        {
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(fubenId);
            //有队伍非队长返回
            TeamInfo teamInfo = self.GetSelfTeam();
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
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

        public static void OnRecvTeamUpdate(this TeamComponentC self, M2C_TeamUpdateResult message)
        {
            bool haveTeam = false;
            for (int i = self.TeamList.Count - 1; i >= 0; i--)
            {
                if (self.TeamList[i].TeamId != message.TeamInfo.TeamId)
                {
                    continue;
                }

                if (message.TeamInfo.PlayerList.Count == 0)
                {
                    self.TeamList.RemoveAt(i);
                }
                else
                {
                    self.TeamList[i] = message.TeamInfo;
                }

                haveTeam = true;
                break;
            }

            if (!haveTeam && message.TeamInfo.PlayerList.Count > 0)
            {
                self.TeamList.Add(message.TeamInfo);
                self.ApplyList.Clear();
            }
            
        }

        public static void OnRecvTeamApply(this TeamComponentC self, TeamPlayerInfo teamPlayerInfo)
        {
            bool have = false;
            for (int i = 0; i < self.ApplyList.Count; i++)
            {
                if (self.ApplyList[i].UserID == teamPlayerInfo.UserID)
                {
                    self.ApplyList[i] = teamPlayerInfo;
                    have = true;
                    break;
                }
            }

            if (!have && self.ApplyList.Count < 10)
            {
                self.ApplyList.Add(teamPlayerInfo);
            }

            self.Root().GetComponent<ReddotComponentC>().AddReddont(ReddotType.TeamApply);
        }
    }
}