using System;
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

                Console.WriteLine($"TeamSceneComponent SyncTeamInfo {userId} { t2M_TeamUpdateRequest.TeamId}");
                
                self.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession).Send(userId, m2C_HorseNoticeInfo);
                self.Root().GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(userId, t2M_TeamUpdateRequest);
            }
        }

        /// <summary>
        /// 离开队伍 [主动离开 或者被踢]
        /// </summary>
        /// <param name="self"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static void OnRecvUnitLeave(this TeamSceneComponent self, long userId, bool exitgame = false)
        {
            Console.WriteLine($"TeamSceneComponent OnRecvUnitLeave {userId} {exitgame}");
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

            //已经移除的玩家不通知
            self.SyncTeamInfo(teamInfo, userIDList);
        }
        
        public static void OnDungeonOver(this TeamSceneComponent self, long teamId)
        {
            TeamInfo teamInfo = self.GetTeamInfo(teamId);
            
            Console.WriteLine($"OnTeamDungeonOver: {teamInfo}");
            if (teamInfo != null)
            {
                for (int i = 0;i < teamInfo.PlayerList.Count; i++)
                {
                    teamInfo.PlayerList[i].Damage = 0;
                }
                teamInfo.FubenUUId = 0;
                teamInfo.FubenInstanceId = 0;
                teamInfo.FubenActorId = default;
            }
        }
        
        /// <summary>
        /// 组队副本返回主城  退出副本也通知机器人退出， 玩家离开队伍才下线机器人。
        /// </summary>
        /// <param name="self"></param>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public static void  OnUnitReturn(this TeamSceneComponent self, Scene fubnescene, long unitId)
        {
            C2M_TransferMap actor_Transfer = C2M_TransferMap.Create();
            actor_Transfer.SceneType = MapTypeEnum.MainCityScene;
            List<Unit> allunits = UnitHelper.GetUnitList(fubnescene, UnitType.Player);
            for (int i = 0; i < allunits.Count; i++)
            {
                if (!allunits[i].IsRobot())
                {
                    continue;
                }
                TransferHelper.TransferUnit(allunits[i], actor_Transfer).Coroutine();
            }
            Console.WriteLine($"OnUnitReturn:  {unitId}    {allunits.Count}   {fubnescene.Name}");
            
            if (allunits.Count > 0)
            {
                return;
            }
            self.OnDungeonOver(unitId);
            TransferHelper.NoticeFubenCenter(fubnescene, 2).Coroutine();
            fubnescene.Dispose();
        }
        
        /// <summary>
        /// 玩家离线， unit已经移除了
        /// </summary>
        /// <param name="self"></param>
        /// <param name="unitId"></param>c
        /// <returns></returns>
        public static void  OnUnitDisconnect(this TeamSceneComponent self, Scene fubnescene, int sceneTypeEnum, long unitId)
        {
            Console.WriteLine($"OnUnitDisconnect11: IsHavePlayer: {UnitHelper.IsHavePlayer(fubnescene)}");

            TeamInfo teamInfo = self.GetTeamInfo(unitId);
            if (teamInfo == null)
            {
                return;
            }
            
            if (UnitHelper.IsHavePlayer(fubnescene))
            {
                return;
            }
    
            self.OnDungeonOver(teamInfo.TeamId);
            TransferHelper.NoticeFubenCenter(fubnescene, 2).Coroutine();
            fubnescene.Dispose();
        }
        
        #region TeamDungeon

        public static void OnTeamDungeonOver(this TeamSceneComponent self, long teamid)
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
            mapComponent.SetMapInfo((int)MapTypeEnum.TeamDungeon, teamInfo.SceneId, 0);
            mapComponent.NavMeshId = sceneConfig.MapID;
            teamDungeonComponent.EnterTime = TimeHelper.ServerNow();
            teamDungeonComponent.FubenType = teamInfo.FubenType;
            teamDungeonComponent.BossDeadPosition =
                    new float3(sceneConfig.InitPos[0] * 0.01f, sceneConfig.InitPos[1] * 0.01f, sceneConfig.InitPos[2] * 0.01f);

            //Game.Scene.GetComponent<RecastPathComponent>().Update(mapComponent.NavMeshId);
            FubenHelp.CreateMonsterList(fubnescene, SceneConfigCategory.Instance.Get(teamInfo.SceneId).CreateMonsterPosi);

            if (teamInfo.FubenType == TeamFubenType.ShenYuan)
            {
                int postionid = ConfigData.ShenYuanCreateConfig[teamInfo.SceneId];
                FubenHelp.CreateMonsterList(fubnescene, postionid);
            }

            //TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
            teamInfo.FubenActorId = fubnescene.GetActorId();
        }

        #endregion


        #region DragonDungeon
        public static void CreateDragonDungeon(this TeamSceneComponent self, TeamInfo teamInfo)
        {
            //动态创建副本
            long fubenid = IdGenerater.Instance.GenerateId();
            long fubenInstanceId = IdGenerater.Instance.GenerateInstanceId();
            Scene fubnescene = GateMapFactory.Create(self, fubenid, fubenInstanceId, "DragonDungeon" + fubenid.ToString());
            DragonDungeonComponentS dragonDungeonComponentS = fubnescene.AddComponent<DragonDungeonComponentS>();
            dragonDungeonComponentS.EnterTime = TimeHelper.ServerNow();
            dragonDungeonComponentS.FubenType = teamInfo.FubenType;
            dragonDungeonComponentS.InitFubenCell(teamInfo.SceneId);
            dragonDungeonComponentS.InitFirstCell();
            //Game.Scene.GetComponent<RecastPathComponent>().Update(mapComponent.NavMeshId);
            //TransferHelper.NoticeFubenCenter(fubnescene, 1).Coroutine();
            teamInfo.FubenActorId = fubnescene.GetActorId();
        }

        #endregion
    }
}