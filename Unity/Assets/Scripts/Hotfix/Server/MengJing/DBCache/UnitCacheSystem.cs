
namespace ET.Server
{
    [FriendOf(typeof(UnitCache))]
    [EntitySystemOf(typeof(UnitCache))]
    public static partial class UnitCacheSystem
    {

        [EntitySystem]
        private static void Awake(this UnitCache self)
        {
            
        }

        [EntitySystem]
        private static void Destroy(this UnitCache self)
        {
            foreach (Entity entity in self.CacheCompoenntsDictionary.Values)
            {
                entity.Dispose();
            }
            self.CacheCompoenntsDictionary.Clear();
            self.key = null;
        }

        public static void SetKey(this UnitCache self, string key)
        { 
            self.key = key; 
        }

        public static void AddOrUpdate(this UnitCache self, Entity entity)
        {
            if (entity == null)
            {
                return;
            }

            if (self.CacheCompoenntsDictionary.TryGetValue(entity.Id, out EntityRef<Entity> oldEntity))
            {
                Entity oEntity = oldEntity;
                if (entity != oEntity)
                {
                    oEntity.Dispose();
                }

                self.CacheCompoenntsDictionary.Remove(entity.Id);
            }

            self.CacheCompoenntsDictionary.Add(entity.Id, entity);
        }

        public static async ETTask<Entity> Get(this UnitCache self, long unitId)
        {
            Entity entity = null;
            self.CacheCompoenntsDictionary.TryGetValue(unitId, out EntityRef<Entity> refentity);

            entity = refentity;
            if (entity == null)
            {
                entity = await self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone()).Query<Entity>(unitId, self.key);
                if (entity != null)
                {
                    self.AddOrUpdate(entity);
                }
            }
            return entity;
        }

        public static void Delete(this UnitCache self, long id)
        {
            if (self.CacheCompoenntsDictionary.TryGetValue(id, out EntityRef<Entity> refentity))
            {
                Entity entity = refentity;
                entity.Dispose();
                self.CacheCompoenntsDictionary.Remove(id);
            }
        }
    }
}