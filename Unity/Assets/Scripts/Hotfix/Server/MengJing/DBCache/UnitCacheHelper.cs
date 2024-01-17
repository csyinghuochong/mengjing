using System;

namespace ET.Server
{

    public static class UnitCacheHelper
    {

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

            int indexOf = queryUnit.ComponentNameList.IndexOf(nameof(Unit));
            Unit unit = queryUnit.EntityList[indexOf] as Unit;
            if (unit == null)
            {
                return null;
            }
            scene.GetComponent<UnitComponent>().AddChild(unit);
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
            message.ComponentNameList.Add(typeof(T).Name);
           
            UnitCache2Other_GetUnit queryUnit = (UnitCache2Other_GetUnit)await root.GetComponent<MessageSender>().Call(startSceneConfig.ActorId, message);
            if (queryUnit.Error == ErrorCode.ERR_Success && queryUnit.EntityList.Count > 0)
            {
                return queryUnit.EntityList[0] as T;
            }
            return null;
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
    }
}