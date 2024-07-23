using System.Collections.Generic;

namespace ET.Server
{

    [ChildOf(typeof(UnitCacheComponent))] 
    public class UnitCache : Entity, IAwake, IDestroy
    {
        public string key {  get; set; }

        public Dictionary<long, EntityRef<Entity>> CacheCompoenntsDictionary = new Dictionary<long, EntityRef<Entity>>();
    }
}