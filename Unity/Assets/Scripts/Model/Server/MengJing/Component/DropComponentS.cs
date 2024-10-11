using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class DropComponentS : Entity, IAwake
    {
        public long OwnerId { get; set; }
        public long ProtectTime { get; set; }

        public int IfDamgeDrop { get; set; }
        public List<long> BeAttackPlayerList { get; set; } = new List<long>();
    }
}