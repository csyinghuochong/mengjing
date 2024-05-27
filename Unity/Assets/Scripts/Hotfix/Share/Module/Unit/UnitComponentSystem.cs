using System.Collections.Generic;
using System.Linq;

namespace ET
{
    [FriendOf(typeof (UnitComponent))]
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

        public static List<Unit> GetAll(this UnitComponent self)
        {
            return self.Units;
        }
        
        public static List<long> GetAllIds(this UnitComponent self)
        {
            List<long> ids = new List<long>();
            return ids;
        }
    }
}