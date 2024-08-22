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
        public readonly M2C_UnitBuffUpdate m2C_UnitBuffUpdate = M2C_UnitBuffUpdate.Create();
        public readonly M2C_UnitBuffRemove m2C_UnitBuffRemove = M2C_UnitBuffRemove.Create();
        
        public bool Checking { get; set; }
    }
}

