using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof (Scene))]
    public class UnitComponent: Entity, IAwake, IDestroy
    {
        public List<EntityRef<Unit>> Units = new();
    }
}