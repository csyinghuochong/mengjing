using System.Collections.Generic;


namespace ET.Server
{

    [ComponentOf(typeof(Scene))]
    public class UnitCacheComponent : Entity, IAwake, IDestroy
    { 
        public  Dictionary<string, UnitCache> UnitCaches = new Dictionary<string, UnitCache>();
        public List<string> UnitCacheKeyList = new List<string>();
    }
}