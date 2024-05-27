using System.Collections.Generic;

namespace ET.Server
{
    
    
    [ComponentOf(typeof(Unit))]
    public class ReddotComponentS:         Entity, IAwake, IDestroy, ITransfer, IUnitCache
    {
        public List<KeyValuePair> ReddontList { get; set; } = new List<KeyValuePair>();
    }
}
