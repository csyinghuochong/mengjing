using System.Collections.Generic;

namespace ET.Server
{
    
    
    [ComponentOf(typeof(Unit))]
    public class ReddotComponentServer: Entity, IAwake<long>, IDestroy
    {
        public List<KeyValuePair> ReddontList = new List<KeyValuePair>();
    }
}
