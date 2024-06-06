using System.Collections.Generic;

namespace ET.Client
{
    
    [ComponentOf(typeof(Scene))]
    public class ReddotComponentC: Entity, IAwake
    {
        public List<KeyValuePair> ReddontList { get; set; } = new List<KeyValuePair>();
    }
}
