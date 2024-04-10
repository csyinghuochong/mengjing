using System.Collections.Generic;

namespace ET.Client
{

    [ComponentOf(typeof(Unit))]
    public class BuffManagerComponentC: Entity, IAwake, IDestroy
    {
        public long Timer;
        public int SceneType;
        
        public List<KeyValuePair> t_Buffs = new List<KeyValuePair>();
        public List<BuffC> m_Buffs { get; set; } = new List<BuffC>();
    }
    
}