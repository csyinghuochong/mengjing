using System.Collections.Generic;

namespace ET.Server
{

    [ComponentOf(typeof(Scene))]
    public class UnitCacheComponent : Entity, IAwake, IDestroy
    {  
        
        public long CurHourTime;      
        public List<long> WaitDeletUnit = new List<long>(); 
        public Dictionary<long, long> UnitCachesTime = new Dictionary<long, long>();                     //缓存时间
        
        public  Dictionary<string, EntityRef<UnitCache>> UnitCaches = new Dictionary<string, EntityRef<UnitCache>>();
        public List<string> UnitCacheKeyList = new List<string>();
    }
}