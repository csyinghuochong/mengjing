using System;
using System.Collections.Generic;

namespace ET.Server
{

    public static class UnitCacheHelper
    {
        /// <summary>
        /// 获取玩家缓存
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public static async ETTask<Unit> GetUnitCache(Scene scene, long unitId)
        {
            int zone = scene.Zone();
            Scene root = scene.Root();
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetUnitCacheConfig(zone);
            Other2UnitCache_GetUnit message = Other2UnitCache_GetUnit.Create();
            message.UnitId = unitId;

            UnitCache2Other_GetUnit queryUnit =
                    (UnitCache2Other_GetUnit)await root.GetComponent<MessageSender>().Call(startSceneConfig.ActorId, message);
            if (queryUnit.Error != ErrorCode.ERR_Success )
            {
                return null;
            }

            Unit unit = null;
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            if (queryUnit.EntityList.Count > 0)
            {
                 int indexOf = queryUnit.ComponentNameList.IndexOf(typeof(Unit).FullName);
                 unit = MongoHelper.Deserialize<Unit>(queryUnit.EntityList[indexOf]);
                 unitComponent.AddChild(unit);
            }
            else
            {  
                unit = unitComponent.AddChildWithId<Unit, int>(unitId, 1001);
            }

            // if (unit == null)
            // {
            //     unit =  unitComponent.AddChildWithId<Unit, int>(unitId, 1001);
            // }
            // else
            // {
            //     unitComponent.AddChild(unit);
            // }
            foreach (var bytess in queryUnit.EntityList)
            {
                Entity entity = MongoHelper.Deserialize<Entity>(bytess);
                if (entity == null || entity is Unit)
                {
                    continue;
                }

                unit.AddComponent(entity);
            }

            return unit;
        }

        /// <summary>
        /// 获取玩家组件缓存
        /// </summary>
        /// <param name="unitId"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async ETTask<T> GetComponentCache<T>(Scene root,  long unitId) where T : Entity
        {
            int zone = root.Zone();
            ActorId dbCacheId = GetDbCacheId(zone);

            Other2UnitCache_GetComponent other2UnitCacheGetComponent = Other2UnitCache_GetComponent.Create();
            other2UnitCacheGetComponent.UnitId = unitId;
            other2UnitCacheGetComponent.Component = typeof(T).FullName;
            
            bool iscache =  typeof(IUnitCache).IsAssignableFrom(typeof(T));
            if (!iscache)
            {
                Log.Error($"GetComponentCacheError： {typeof(T).FullName}");
            }
            
            UnitCache2Other_GetComponent d2GGetUnit = (UnitCache2Other_GetComponent)await root.GetComponent<MessageSender>().Call(dbCacheId,
                other2UnitCacheGetComponent);

            if (d2GGetUnit.Error == ErrorCode.ERR_Success && d2GGetUnit.Component != null)
            {
                return  MongoHelper.Deserialize<T>(d2GGetUnit.Component);
            }
            return null;
        }
        
        /// <summary>
        /// 保存玩家组件缓存
        public static async ETTask SaveComponentCache(Scene root,  Entity entity)
        {
            int zone = root.Zone();
            Other2UnitCache_AddOrUpdateUnit addOrUpdateUnit = Other2UnitCache_AddOrUpdateUnit.Create();
            addOrUpdateUnit.UnitId = entity.Id;
            addOrUpdateUnit.EntityTypes.Add(entity.GetType().FullName);
            addOrUpdateUnit.EntityBytes.Add(entity.ToBson());
            
            bool iscache = typeof(IUnitCache).IsAssignableFrom(entity.GetType());
            if (!iscache)
            {
                Log.Error($"SaveComponentCacheError： {entity.GetType().FullName}");
            }

            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetUnitCacheConfig(zone);
            await root.GetComponent<MessageSender>().Call(startSceneConfig.ActorId, addOrUpdateUnit);
        }
            
        /// <summary>
        /// 保存非玩家组件缓存
        /// </summary>
        /// <param name="root"></param>
        /// <param name="unitId"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async ETTask<T> GetComponent<T>(Scene root, long unitId, int zone) where T : Entity
        {
            DBManagerComponent dbManagerComponent = root.GetComponent<DBManagerComponent>();
            DBComponent dbComponent = dbManagerComponent.GetZoneDB(zone);
            
            bool iscache = typeof(IUnitCache).IsAssignableFrom(typeof(T));
            if (iscache)
            {
                Log.Error($"GetComponentError： {typeof(T).FullName}");
            }
            
            List<T> resulets = await dbComponent.Query<T>(root.Zone(), d => d.Id == unitId);
            if (resulets == null || resulets.Count == 0)
            {
                return null;
            }

            return resulets[0];
        }
        
        
        /// <summary>
        /// 保存非玩家组件缓存
        /// </summary>
        /// <param name="root"></param>
        /// <param name="unitId"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async ETTask<T> GetComponent<T>(Scene root, long unitId) where T : Entity
        {
            int zone = root.Zone();
            DBManagerComponent dbManagerComponent = root.GetComponent<DBManagerComponent>();
            DBComponent dbComponent = dbManagerComponent.GetZoneDB(zone);
            
            bool iscache = typeof(IUnitCache).IsAssignableFrom(typeof(T));
            if (iscache)
            {
                Log.Error($"GetComponentError： {typeof(T).FullName}");
            }
            
            List<T> resulets = await dbComponent.Query<T>(root.Zone(), d => d.Id == unitId);
            if (resulets == null || resulets.Count == 0)
            {
                return null;
            }

            return resulets[0];
        }

        public static async ETTask SaveComponent(Scene root, long unitId, Entity entity, int zone)
        {
            bool iscache =typeof(IUnitCache).IsAssignableFrom(entity.GetType());
            if (iscache)
            {
                Log.Error($"GetComponentError： {entity.GetType().FullName}");
            }
            DBManagerComponent dbManagerComponent = root.GetComponent<DBManagerComponent>();
            DBComponent dbComponent = dbManagerComponent.GetZoneDB(zone);
            await dbComponent.Save(root.Zone(), entity);
        }
        
        public static async ETTask SaveComponent(Scene root, long unitId, Entity entity)
        {
            int zone = root.Zone();
            
            bool iscache =typeof(IUnitCache).IsAssignableFrom(entity.GetType());
            if (iscache)
            {
                Log.Error($"GetComponentError： {entity.GetType().FullName}");
            }
            DBManagerComponent dbManagerComponent = root.GetComponent<DBManagerComponent>();
            DBComponent dbComponent = dbManagerComponent.GetZoneDB(zone);
            await dbComponent.Save(root.Zone(), entity);
        }
        

        /// <summary>
        /// 删除玩家缓存
        /// </summary>
        /// <param name="unitId"></param>
        public static async ETTask DeleteUnitCache(Scene scene, long unitId)
        {
            int zone = scene.Zone();
            Scene root = scene.Root();
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetUnitCacheConfig(zone);
            Other2UnitCache_DeleteUnit message = Other2UnitCache_DeleteUnit.Create();
            message.UnitId = unitId;
            await root.GetComponent<MessageSender>().Call(startSceneConfig.ActorId, message);
        }


        /// <summary>
        /// 保存Unit及Unit身上组件到缓存服及数据库中
        /// </summary>
        /// <param name="unit"></param>
        public static void AddOrUpdateUnitAllCache(Unit unit)
        {
            int zone = unit.Zone();
            Other2UnitCache_AddOrUpdateUnit message = Other2UnitCache_AddOrUpdateUnit.Create();
            message.UnitId = unit.Id;

            message.EntityTypes.Add(unit.GetType().FullName);
            message.EntityBytes.Add(unit.ToBson());

            foreach ((long id, Entity entity) in unit.Components)
            {
                Type key = entity.GetType();
                if (!typeof(IUnitCache).IsAssignableFrom(key))
                {
                    continue;
                }

                message.EntityTypes.Add(key.FullName);
                message.EntityBytes.Add(entity.ToBson());
            }

            Scene root = unit.Root();
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetUnitCacheConfig(zone);
            root.GetComponent<MessageSender>().Call(startSceneConfig.ActorId, message).Coroutine();
        }

        public static ActorId GetDbCacheId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.DBCache.ToString()).ActorId;
        }
        
        public static ActorId GetChatServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, "Chat").ActorId;
        }

        public static ActorId GetActivityServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Activity.ToString()).ActorId;
        }

        public static ActorId GetTeamServerId(int zone)
        { 
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Team.ToString()).ActorId;
        }

        public static ActorId GetRechargeCenter()
        {
            return StartSceneConfigCategory.Instance.RechargeConfig.ActorId;
        }

        public static ActorId GetLoginCenterId()
        {
            return StartSceneConfigCategory.Instance.LoginCenterConfig.ActorId;
        }

        
        public static ActorId GetQueueServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Queue.ToString()).ActorId;
        }

        public static ActorId GetFriendServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Friend.ToString()).ActorId;
        }
        
        public static ActorId GetChatId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Chat.ToString()).ActorId;
        }
        
        public static ActorId GetPaiMaiServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.PaiMai.ToString()).ActorId;
        }
        
        public static ActorId GetRankServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Rank.ToString()).ActorId;
        }
        
        public static ActorId GetFubenCenterId(int zone, int index = 1)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, "FubenCenter" + index).ActorId;
        }
        
        public static ActorId GetUnionServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Union.ToString()).ActorId;
        }
        
        public static ActorId GetPetMatchServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.PetMatch.ToString()).ActorId;
        }
        
        public static ActorId GetSoloServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Solo.ToString()).ActorId;
        }

        public static ActorId GetPopularizeServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Popularize.ToString()).ActorId;
        }
        
        public static ActorId MainCityServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, $"Map101").ActorId;
        }
        
        public static ActorId GetMailServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.EMail.ToString()).ActorId;
        }
        
        public static ActorId GetRobotServerId()
        {
            ActorId robotSceneId = StartSceneConfigCategory.Instance.RobotManagerConfig.ActorId;
            return robotSceneId;
        }

        public static ActorId GetJiaYuanServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.JiaYuan.ToString()).ActorId;
        }
        
        public static List<ActorId> GetGateServerId(int zone)
        {
            List<ActorId> actorIds = new List<ActorId>();
            actorIds.Add(StartSceneConfigCategory.Instance.GetBySceneName(zone, "Gate1").ActorId);
            actorIds.Add(StartSceneConfigCategory.Instance.GetBySceneName(zone, "Gate2").ActorId);
            return actorIds;
        }

        public static async ETTask<List<long>> GetOnLineUnits(Scene root,  int zone)
        {           
            await ETTask.CompletedTask;
            List<long> onlines = new List<long>();
            List<ActorId> allactorids = GetGateServerId(zone);

            for (int i = 0; i < allactorids.Count; i++)
            {
                A2G_GetOnLineUnit a2GGetOnLineUnit = A2G_GetOnLineUnit.Create();
                G2A_GetOnLineUnit aGetOnLineUnit = (G2A_GetOnLineUnit)await root.GetComponent<MessageSender>().Call(allactorids[i], a2GGetOnLineUnit);
                onlines.AddRange(aGetOnLineUnit.OnLineUnits);
            }
            
            return onlines;
        }
    }
}