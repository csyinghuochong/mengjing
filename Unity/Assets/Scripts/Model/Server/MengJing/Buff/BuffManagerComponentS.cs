using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Unit))]
    public class BuffManagerComponentS: Entity, IAwake, IDestroy
    {
        public long Timer;
        public int SceneType;

        public List<BuffS> m_Buffs { get; set; } = new List<BuffS>();

        public List<KeyValuePairLong> m_BuffRecord = new List<KeyValuePairLong>();  //buffid_增删_
        
        public bool Checking { get; set; }
    }
}

