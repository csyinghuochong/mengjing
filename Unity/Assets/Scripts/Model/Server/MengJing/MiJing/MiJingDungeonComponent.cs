using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class MiJingDungeonComponent: Entity, IAwake, IDestroy
    {
        public int BossId { get; set; }
        public long LastTime{ get; set; }
        public List<TeamPlayerInfo> PlayerDamageList { get; set; }= new List<TeamPlayerInfo>();
        public M2C_SyncMiJingDamage M2C_SyncMiJingDamage { get; set; } = M2C_SyncMiJingDamage.Create();
    }
    
}

