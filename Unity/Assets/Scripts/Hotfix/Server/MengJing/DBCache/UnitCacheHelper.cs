using ET.Client;
using System;
using System.Collections.Generic;
using static System.Collections.Specialized.BitVector32;

namespace ET.Server
{

    public static class UnitCacheHelper
    {
        
        public static ActorId GetAccountCenter()
        {
            return StartSceneConfigCategory.Instance.AccountCenterConfig.ActorId;
        }
        
        /// <summary>
        /// 保存或者更新玩家缓存
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T"></typeparam>
        public static async ETTask AddOrUpdateUnitCache<T>(this T self) where T : Entity, IUnitCache
        {
            Other2UnitCache_AddOrUpdateUnit message = new Other2UnitCache_AddOrUpdateUnit() { UnitId = self.Id, };
            message.EntityTypes.Add(typeof(T).FullName);
            message.EntityBytes.Add(self.ToBson());

            Scene root = self.Root();
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetUnitCacheConfig(self.Zone());
            await root.GetComponent<MessageSender>().Call(startSceneConfig.ActorId, message);
        }

        /// <summary>
        /// 获取玩家缓存
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="unitId"></param>
        /// <returns></returns>
        public static async ETTask<Unit> GetUnitCache(Scene scene, long unitId)
        {
            Scene root = scene.Root();
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetUnitCacheConfig(scene.Zone());
            Other2UnitCache_GetUnit message = new Other2UnitCache_GetUnit() { UnitId = unitId };
            UnitCache2Other_GetUnit queryUnit = (UnitCache2Other_GetUnit)await root.GetComponent<MessageSender>().Call(startSceneConfig.ActorId, message);
            if (queryUnit.Error != ErrorCode.ERR_Success || queryUnit.EntityList.Count <= 0)
            {
                return null;
            }

            int indexOf = queryUnit.ComponentNameList.IndexOf(typeof(Unit).FullName);
             Unit unit = queryUnit.EntityList[indexOf] as Unit;
             UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
             // if (unit == null)
             // {
             //     unit =  unitComponent.AddChildWithId<Unit, int>(unitId, 1001);
             // }
             // else
             // {
             //     unitComponent.AddChild(unit);
             // }
             
             unit =  unitComponent.AddChildWithId<Unit, int>(unitId, 1001);

            foreach (Entity entity in queryUnit.EntityList)
            {
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
        public static async ETTask<T> GetUnitComponentCache<T>(Scene scene, long unitId) where T : Entity, IUnitCache
        {
            Scene root = scene.Root();
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetUnitCacheConfig(scene.Zone());

            Other2UnitCache_GetUnit message = new Other2UnitCache_GetUnit() { UnitId = unitId };
            message.ComponentNameList.Add(typeof(T).FullName);

            UnitCache2Other_GetUnit queryUnit = (UnitCache2Other_GetUnit)await root.GetComponent<MessageSender>().Call(startSceneConfig.ActorId, message);
            if (queryUnit.Error == ErrorCode.ERR_Success && queryUnit.EntityList.Count > 0)
            {
                return queryUnit.EntityList[0] as T;
            }
            return null;
        }
        
        /// 获取玩家组件缓存
        /// </summary>
        /// <param name="unitId"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async ETTask<T> GetComponentCache<T>(Scene root,  long unitId) where T : Entity
        {
            ActorId dbCacheId = UnitCacheHelper.GetDbCacheId(root.Zone());
            UnitCache2Other_GetComponent d2GGetUnit = (UnitCache2Other_GetComponent)await root.GetComponent<MessageSender>().Call(dbCacheId,
                new Other2UnitCache_GetComponent() 
                { 
                    UnitId = unitId,
                    Component = typeof(T).FullName
                });

            if (d2GGetUnit.Error == ErrorCode.ERR_Success && d2GGetUnit.Component != null)
            {
                return d2GGetUnit.Component as T;
            }
            return null;
        }
        
        public static async ETTask SaveComponentCache(Scene root,  Entity entity)
        {
            Other2UnitCache_AddOrUpdateUnit addOrUpdateUnit = new Other2UnitCache_AddOrUpdateUnit()
            {

            };
            addOrUpdateUnit.UnitId = entity.Id;
            addOrUpdateUnit.EntityTypes.Add(entity.GetType().FullName);
            addOrUpdateUnit.EntityBytes.Add(entity.ToBson());

            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetUnitCacheConfig(root.Zone());
            await root.GetComponent<MessageSender>().Call(startSceneConfig.ActorId, addOrUpdateUnit);
        }
                
        public static async ETTask<T> GetComponent<T>(Scene root, long unitId) where T : Entity
        {
            DBManagerComponent dbManagerComponent = root.GetComponent<DBManagerComponent>();
            DBComponent dbComponent = dbManagerComponent.GetZoneDB(root.Zone());
            List<T> resulets = await dbComponent.Query<T>(root.Zone(), d => d.Id == unitId);
            if (resulets == null || resulets.Count == 0)
            {
                return null;
            }

            return resulets[0];
        }

        public static async ETTask SaveComponent(Scene root, long unitId, Entity entity)
        {
            DBManagerComponent dbManagerComponent = root.GetComponent<DBManagerComponent>();
            DBComponent dbComponent = dbManagerComponent.GetZoneDB(root.Zone());
            await dbComponent.Save(root.Zone(), entity);
        }
        

        /// <summary>
        /// 删除玩家缓存
        /// </summary>
        /// <param name="unitId"></param>
        public static async ETTask DeleteUnitCache(Scene scene, long unitId)
        {
            Scene root = scene.Root();
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetUnitCacheConfig(scene.Zone());
            Other2UnitCache_DeleteUnit message = new Other2UnitCache_DeleteUnit() { UnitId = unitId };
            await root.GetComponent<MessageSender>().Call(startSceneConfig.ActorId, message);
        }


        /// <summary>
        /// 保存Unit及Unit身上组件到缓存服及数据库中
        /// </summary>
        /// <param name="unit"></param>
        public static void AddOrUpdateUnitAllCache(Unit unit)
        {
            Other2UnitCache_AddOrUpdateUnit message = new Other2UnitCache_AddOrUpdateUnit() { UnitId = unit.Id, };

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
            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.GetUnitCacheConfig(unit.Zone());
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

        public static ActorId GetActivityId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Activity.ToString()).ActorId;
        }

        public static ActorId GetTeamServerId(int zone)
        { 
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Team.ToString()).ActorId;
        }

        public static ActorId GetFriendId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Friend.ToString()).ActorId;
        }
        
        public static ActorId GetChatId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Chat.ToString()).ActorId;
        }
        
        public static ActorId GetGateServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Gate.ToString()).ActorId;
        }

        public static ActorId GetPaiMaiServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.PaiMai.ToString()).ActorId;
        }
        
        public static ActorId GetRankServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Rank.ToString()).ActorId;
        }
        
        public static ActorId GetFubenCenterId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.FubenCenter.ToString()).ActorId;
        }
        
        public static ActorId GetArenaServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Arena.ToString()).ActorId;
        }
        
        public static ActorId GetBattleServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Battle.ToString()).ActorId;
        }
        
        public static ActorId GetUnionServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Union.ToString()).ActorId;
        }
        
        public static ActorId GetSoloServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Solo.ToString()).ActorId;
        }
        
        public static ActorId GetHappyServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.Happy.ToString()).ActorId;
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
            ActorId robotSceneId = StartSceneConfigCategory.Instance.GetBySceneName(203, "Robot01").ActorId;
            return robotSceneId;
        }

        public static ActorId GetJiaYuanServerId(int zone)
        {
            return StartSceneConfigCategory.Instance.GetBySceneName(zone, SceneType.JiaYuan.ToString()).ActorId;
        }
        
    }
}