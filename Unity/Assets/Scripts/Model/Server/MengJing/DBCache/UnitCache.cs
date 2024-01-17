using System.Collections.Generic;

namespace ET.Server
{

    public interface IUnitCache
    {

    }

    [ChildOf(typeof(UnitCacheComponent))] 
    public class UnitCache : Entity, IAwake, IDestroy
    {
        public string key {  get; set; }

        public Dictionary<long, Entity> CacheCompoenntsDictionary = new Dictionary<long, Entity>();
    }
}