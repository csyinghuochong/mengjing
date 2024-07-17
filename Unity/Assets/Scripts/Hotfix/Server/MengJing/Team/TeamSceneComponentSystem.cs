using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof (TeamSceneComponent))]
    [FriendOf(typeof (TeamSceneComponent))]
    public static partial class TeamSceneComponentSystem
    {
        [EntitySystem]
        private static void Awake(this TeamSceneComponent self)
        {
        }

        public static void CreateTeamDungeon(this TeamSceneComponent self, TeamInfo teamInfo)
        {
            //动态创建副本
            long fubenid = IdGenerater.Instance.GenerateId();
            long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
            Scene fubnescene = GateMapFactory.Create(self, fubenid, fubenInstanceId, "TeamDungeon" + fubenid.ToString());
            TeamDungeonComponent teamDungeonComponent = fubnescene.AddComponent<TeamDungeonComponent>();
            MapComponent mapComponent = fubnescene.GetComponent<MapComponent>();
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(teamInfo.SceneId);
            mapComponent.SetMapInfo((int)SceneTypeEnum.TeamDungeon, teamInfo.SceneId, 0);
            mapComponent.NavMeshId = sceneConfig.MapID;
            teamDungeonComponent.TeamInfo = teamInfo;
            teamDungeonComponent.EnterTime = TimeHelper.ServerNow();
            teamDungeonComponent.FubenType = teamInfo.FubenType;
            teamDungeonComponent.BossDeadPosition =
                    new float3(sceneConfig.InitPos[0] * 0.01f, sceneConfig.InitPos[1] * 0.01f, sceneConfig.InitPos[2] * 0.01f);
            teamDungeonComponent.InitPlayerList();
            teamInfo.FubenInstanceId = fubenInstanceId;
            teamInfo.FubenUUId = fubenid;
            //Game.Scene.GetComponent<RecastPathComponent>().Update(mapComponent.NavMeshId);
            FubenHelp.CreateMonsterList(fubnescene, SceneConfigCategory.Instance.Get(teamInfo.SceneId).CreateMonster);
            FubenHelp.CreateMonsterList(fubnescene, SceneConfigCategory.Instance.Get(teamInfo.SceneId).CreateMonsterPosi);

            if (teamInfo.FubenType == TeamFubenType.ShenYuan)
            {
                int postionid = ConfigData.ShenYuanCreateConfig[teamInfo.SceneId];
                FubenHelp.CreateMonsterByPos(fubnescene, postionid);
            }

            TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
        }

        public static void OnDungeonOver(this TeamSceneComponent self, long teamId)
        {
            TeamInfo teamInfo = self.GetTeamInfo(teamId);
            if (teamInfo != null)
            {
                for (int i = 0; i < teamInfo.PlayerList.Count; i++)
                {
                    teamInfo.PlayerList[i].Damage = 0;
                }

                teamInfo.FubenUUId = 0;
                teamInfo.FubenInstanceId = 0;
            }
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
            return teamInfo != null? teamInfo.TeamId : 0;
        }

        public static TeamInfo CreateTeamInfo(this TeamSceneComponent self, TeamPlayerInfo teamPlayerInfo, int fubenId)
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
            
            teamInfo.PlayerList.Add(teamPlayerInfo);
            self.TeamList.Add(teamInfo);
            return teamInfo;
        }

        public static async ETTask SyncTeamInfo(this TeamSceneComponent self, TeamInfo teamInfo, List<TeamPlayerInfo> userIds)
        {
            M2C_TeamUpdateResult m2C_HorseNoticeInfo = self.m2C_TeamUpdateResult;
            m2C_HorseNoticeInfo.TeamInfo = teamInfo;
            T2M_TeamUpdateRequest t2M_TeamUpdateRequest = self.t2M_TeamUpdateRequest;

            ActorId gateServerId = UnitCacheHelper.GetGateServerId(self.Zone());
            T2G_GateUnitInfoRequest T2G_GateUnitInfoRequest = T2G_GateUnitInfoRequest.Create();
            for (int i = 0; i < userIds.Count; i++)
            {
                long userId = userIds[i].UserID;
                T2G_GateUnitInfoRequest.UserID = userId;
                G2T_GateUnitInfoResponse g2M_UpdateUnitResponse =
                        (G2T_GateUnitInfoResponse)await self.Root().GetComponent<MessageSender>().Call(gateServerId,T2G_GateUnitInfoRequest);

                if (g2M_UpdateUnitResponse.PlayerState == (int)PlayerState.Game && g2M_UpdateUnitResponse.SessionInstanceId > 0)
                {
                    t2M_TeamUpdateRequest.TeamId = self.GetTeamInfoId(userId);
                    MapMessageHelper.SendToClient(self.Root(), g2M_UpdateUnitResponse.SessionInstanceId, m2C_HorseNoticeInfo);
                    self.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(userId, t2M_TeamUpdateRequest);
                }
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

            self.SyncTeamInfo(teamInfo, userIDList).Coroutine();
        }

        /// <summary>
        /// 组队副本返回主城
        /// </summary>
        /// <param name="self"></param>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public static void OnUnitReturn(this TeamSceneComponent self, Scene fubnescene, long unitId)
        {
            List<Unit> allunits = UnitHelper.GetUnitList(fubnescene, UnitType.Player);
            for (int i = 0; i < allunits.Count; i++)
            {
                if (allunits[i].GetComponent<UserInfoComponentS>().UserInfo.RobotId == 0)
                {
                    continue;
                }

                MapMessageHelper.SendToClient(allunits[i], self.M2C_TeamDungeonQuitMessage);
            }

            if (allunits.Count > 0)
            {
                return;
            }

            self.OnDungeonOver(unitId);
            TeamDungeonComponent teamDungeonComponent = fubnescene.GetComponent<TeamDungeonComponent>();
            Log.Debug($"TeamDungeonDispose {teamDungeonComponent.TeamInfo.TeamId}{fubnescene.InstanceId}");
            TransferHelper.NoticeFubenCenter(fubnescene, 2).Coroutine();
            fubnescene.Dispose();
        }

        /// <summary>
        /// 玩家离线， unit已经移除了
        /// </summary>
        /// <param name="self"></param>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public static void OnUnitDisconnect(this TeamSceneComponent self, Scene fubnescene, long unitId)
        {
            TeamDungeonComponent teamDungeonComponent = fubnescene.GetComponent<TeamDungeonComponent>();
            TeamInfo teamInfo = teamDungeonComponent.TeamInfo;
            if (teamDungeonComponent.IsHavePlayer())
            {
                return;
            }

            self.OnDungeonOver(teamInfo.TeamId);

            Log.Debug($"TeamDungeonDispose {teamDungeonComponent.TeamInfo.TeamId}{fubnescene.InstanceId}");
            TransferHelper.NoticeFubenCenter(fubnescene, 2).Coroutine();
            fubnescene.Dispose();
        }
    }
}