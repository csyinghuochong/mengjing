using System.Collections.Generic;

namespace ET
{
    [EntitySystemOf(typeof(UnitComponent))]
    [FriendOf(typeof(UnitComponent))]
    public static partial class UnitComponentSystem
    {
        public static void Add(this UnitComponent self, Unit unit)
        {
            self.Units.Add(unit);
        }

        public static Unit Get(this UnitComponent self, long id)
        {
            Unit unit = self.GetChild<Unit>(id);
            return unit;
        }

        public static void Remove(this UnitComponent self, long id)
        {
            Unit unit = self.GetChild<Unit>(id);
            self.Units.Remove(unit);
            unit?.Dispose();
        }

        public static List<EntityRef<Unit>> GetAll(this UnitComponent self)
        {
            return self.Units;
        }

        public static List<long> GetAllIds(this UnitComponent self, int uniType)
        {
            List<long> ids = new List<long>();
            List<EntityRef<Unit>> allunits = self.GetAll();
            int allnumber = allunits.Count;
            for (int i = 0; i < allnumber; i++)
            {
                Unit unit = allunits[i];
                if (unit.Type == uniType)
                {
                    ids.Add(unit.Id);
                }
            }
            return ids;
        }
        [EntitySystem]
        private static void Awake(this UnitComponent self)
        {

        }
        [EntitySystem]
        private static void Destroy(this UnitComponent self)
        {

        }
    }
}