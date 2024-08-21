using System;

namespace ET.Server
{

    [FriendOf(typeof(UnitCache))]
    [FriendOf(typeof(UnitCacheComponent))]
    [EntitySystemOf(typeof(UnitCacheComponent))]
    public static partial class UnitCacheComponentSystem
    {

        [EntitySystem]
        private static void Awake(this UnitCacheComponent self)
        {
#if DOTNET
            Log.Console("UnitCacheComponent DOTNET true");
#else
            Log.Console("UnitCacheComponent DOTNET false");
#endif

            self.UnitCacheKeyList.Clear();
            foreach ((string key, Type type) in CodeTypes.Instance.GetTypes())
            {
                bool iscache = type == typeof(IUnitCache);
                bool isassig = typeof(IUnitCache).IsAssignableFrom(type);

                if ( !iscache  && isassig)
                {
                    self.UnitCacheKeyList.Add(type.FullName);
                }
            }

            foreach (string key in self.UnitCacheKeyList)
            {
                UnitCache unitCache = self.AddChild<UnitCache>();
                unitCache.SetKey( key );
                self.UnitCaches.Add(key, unitCache);
            }
        }

        [EntitySystem]
        private static void Destroy(this UnitCacheComponent self)
        {
            foreach (var item in self.UnitCaches.Values)
            {
                UnitCache unitCache = item;
                unitCache?.Dispose();
            }
            self.UnitCaches.Clear();
        }

        public static async ETTask<Entity> Get(this UnitCacheComponent self, long unitId, string key)
        {
            UnitCache unitCache = null;
            self.UnitCaches.TryGetValue(key, out EntityRef<UnitCache> refunitCache);
            unitCache = refunitCache;
            
            if (unitCache == null)
            {
                unitCache = self.AddChild<UnitCache>();
                unitCache.SetKey( key );
                self.UnitCaches.Add(key, unitCache);
            }
            return await unitCache.Get(unitId);
        }


        public static async ETTask<T> Get<T>(this UnitCacheComponent self, long unitId) where T : Entity
        {
            string key = typeof(T).Name;
            UnitCache unitCache;
            if (!self.UnitCaches.TryGetValue(key, out EntityRef<UnitCache> refunitCache))
            {
                unitCache = self.AddChild<UnitCache>();
                unitCache.key = key;
                self.UnitCaches.Add(key, unitCache);
            }
            else
            {
                unitCache = refunitCache;
            }
            return await unitCache.Get(unitId) as T;
        }

        public static async ETTask AddOrUpdate(this UnitCacheComponent self, long id, ListComponent<Entity> entityList)
        {
            using (ListComponent<Entity> list = ListComponent<Entity>.Create())
            {
                foreach (Entity entity in entityList)
                {
                    string key = entity.GetType().FullName;
                    UnitCache unitCache;
                    if (!self.UnitCaches.TryGetValue(key, out EntityRef<UnitCache> refunitCache))
                    {
                        unitCache = self.AddChild<UnitCache>();
                        unitCache.key = key;
                        self.UnitCaches.Add(key, unitCache);
                    }
                    else
                    {
                        unitCache = refunitCache;
                    }
                    
                    unitCache.AddOrUpdate(entity);
                    list.Add(entity);
                }
                if (list.Count > 0)
                {
                    await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).Save(id, list);
                }
            }
        }

        public static void Delete(this UnitCacheComponent self, long unitId)
        {
            foreach (UnitCache cache in self.UnitCaches.Values)
            {
                cache.Delete(unitId);
            }
        }
        
        public static void CheckUnitCacheList(this UnitCacheComponent self)
        {
            self.WaitDeletUnit.Clear();
            long serverTime = TimeHelper.ServerNow();
            int zone = self.Zone();

            foreach ((long unitid, long lasttime) in self.UnitCachesTime)
            {
                if (lasttime != 0 && serverTime - lasttime > TimeHelper.Hour * 4)
                {
                    if (!self.WaitDeletUnit.Contains(unitid))
                    {
                        self.WaitDeletUnit.Add(unitid);
                    }
                }
            }

            int removeNumber = 200;
            Log.Warning($"待移除缓存玩家: {self.Zone()} {self.WaitDeletUnit.Count}");
            for (int i = self.WaitDeletUnit.Count - 1; i >= 0; i--)
            {
                //Log.Console($"长期离线，移除玩家11: {zone}  {self.WaitDeletUnit[i]}");
                self.DeleteRole(self.WaitDeletUnit[i]);
                removeNumber--;
                if (removeNumber <= 0)
                {
                    break;
                }
            }
            self.WaitDeletUnit.Clear();
            self.CurHourTime = TimeHelper.ServerNow();
        }
        
        public static void DeleteRole(this UnitCacheComponent self, long unitId)
        {
            self.Delete(unitId);

           
        }
    }
}