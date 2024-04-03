using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Unit))]
    public class BuffManagerComponentS: Entity, IAwake, IDestroy
    {
        public long Timer;
        public int SceneType;
        
        //public List<BuffHandler> m_Buffs = new List<BuffHandler>();
        
        public List<KeyValuePairLong> m_BuffRecord = new List<KeyValuePairLong>();  //buffid_增删_
        public readonly M2C_UnitBuffUpdate m2C_UnitBuffUpdate = new M2C_UnitBuffUpdate();
        public readonly M2C_UnitBuffRemove m2C_UnitBuffRemove = new M2C_UnitBuffRemove();   
    }
}

