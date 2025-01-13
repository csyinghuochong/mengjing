using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof(TeamSceneComponent))]
    [FriendOf(typeof(TeamSceneComponent))]
    public static partial class TeamSceneComponentSystem
    {
        [EntitySystem]
        private static void Awake(this TeamSceneComponent self)
        {
        }

        public static TeamInfo GetTeamInfo(this TeamSceneComponent self, long userId)
        {
            TeamInfo teamInfo = null;
            for (int i = 0; i < self.TeamList.Count; i++)
            {
                TeamInfo tempTeampInfo = self.TeamList[i];
                if (tempTeampInfo.TeamId == userId)
                {
                    teamInfo = tempTeampInfo;
                    break;
                }

                for (int k = tempTeampInfo.PlayerList.Count - 1; k >= 0; k--)
                {
                    if (tempTeampInfo.PlayerList[k].UserID == userId)
                    {
                        teamInfo = tempTeampInfo;
                        break;
                    }
                }
            }

            return teamInfo;
        }

        public static long GetTeamInfoId(this TeamSceneComponent self, long userId)
        {
            TeamInfo teamInfo = self.GetTeamInfo(userId);
            return teamInfo != null ? teamInfo.TeamId : 0;
        }

        public static TeamInfo CreateTeamInfo(this TeamSceneComponent self, TeamPlayerInfo teamPlayerInfo, int fubenId, int sceneType)
        {
            TeamInfo teamInfo = self.GetTeamInfo(teamPlayerInfo.UserID);
            if (teamInfo != null)
            {
                Log.Error($"teamInfo != null {teamPlayerInfo.UserID}");
                return teamInfo;
            }

            teamInfo = TeamInfo.Create();
            teamInfo.TeamId = teamPlayerInfo.UserID;
            teamInfo.SceneId = fubenId;
            teamInfo.SceneType = sceneType;

            teamInfo.PlayerList.Add(teamPlayerInfo);
            self.TeamList.Add(teamInfo);
            return teamInfo;
        }

        public static void SyncTeamInfo(this TeamSceneComponent self, TeamInfo teamInfo, List<TeamPlayerInfo> userIds)
        {
            M2C_TeamUpdateResult m2C_HorseNoticeInfo = M2C_TeamUpdateResult.Create();
            m2C_HorseNoticeInfo.TeamInfo = teamInfo;
            T2M_TeamUpdateRequest t2M_TeamUpdateRequest = T2M_TeamUpdateRequest.Create();

            for (int i = 0; i < userIds.Count; i++)
            {
                long userId = userIds[i].UserID;
                t2M_TeamUpdateRequest.TeamId = self.GetTeamInfoId(userId);

                self.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession).Send(userId, m2C_HorseNoticeInfo);
                self.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(userId, t2M_TeamUpdateRequest);
            }
        }

        /// <summary>
        /// 离开队伍
        /// </summary>
        /// <param name="self"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static void OnRecvUnitLeave(this TeamSceneComponent self, long userId, bool exitgame = false)
        {
            Log.Debug($"TeamSceneComponent Leave {userId} {exitgame}");
            TeamInfo teamInfo = self.GetTeamInfo(userId);
            if (teamInfo == null)
            {
                return;
            }

            //玩家Id
            List<TeamPlayerInfo> userIDList = new List<TeamPlayerInfo>();
            userIDList.AddRange(teamInfo.PlayerList);
            for (int i = userIDList.Count - 1; i >= 0; i--)
            {
                if (exitgame && userIDList[i].UserID == userId)
                {
                    userIDList.RemoveAt(i);
                }
            }

            for (int k = teamInfo.PlayerList.Count - 1; k >= 0; k--)
            {
                if (teamInfo.PlayerList[k].UserID == userId)
                {
                    teamInfo.PlayerList.RemoveAt(k);
                    break;
                }
            }

            if (teamInfo.PlayerList.Count == 0 || teamInfo.TeamId == userId)
            {
                teamInfo.PlayerList.Clear(); //队伍解算
                self.TeamList.Remove(teamInfo);
            }

            self.SyncTeamInfo(teamInfo, userIDList);
        }
        
}
}