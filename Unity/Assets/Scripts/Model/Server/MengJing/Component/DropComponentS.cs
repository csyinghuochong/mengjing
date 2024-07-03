using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof (Unit))]
    public class DropComponentS: Entity, IAwake
    {
        public int ItemID { get; set; }
        public int ItemNum { get; set; }
        public int DropType { get; set; } //0 公共掉落    1私人掉落 2 保护掉落 3 归属掉落

        public int CellIndex { get; set; } //喜从天降格子位

        public long OwnerId { get; set; }
        public long ProtectTime { get; set; }

        public long BeKillId { get; set; }

        public int IfDamgeDrop { get; set; }
        public List<long> BeAttackPlayerList { get; set; } = new List<long>();

        public DropInfo DropInfo;
    }
}