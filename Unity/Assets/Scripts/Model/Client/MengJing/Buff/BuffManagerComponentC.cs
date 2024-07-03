using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class BuffManagerComponentC: Entity, IAwake, IDestroy
    {
        public long Timer;
        public int SceneType;

        public List<KeyValuePair> t_Buffs { get; set; } = new();
        public List<BuffC> m_Buffs { get; set; } = new();
    }
}