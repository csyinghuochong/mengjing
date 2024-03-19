using System.Collections.Generic;

namespace ET.Server
{
    
    
    [ComponentOf(typeof(Unit))]
    public class ReddotComponentServer:         Entity, IAwake, IDestroy, ITransfer, IUnitCache
    {
        public List<KeyValuePair> ReddontList = new List<KeyValuePair>();
    }
}
