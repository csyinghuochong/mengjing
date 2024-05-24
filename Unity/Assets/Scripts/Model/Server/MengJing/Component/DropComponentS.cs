using System.Collections.Generic;

namespace ET.Server
{
    
    [ComponentOf(typeof(Unit))]
    public class DropComponentS : Entity, IAwake
    {
        public int ItemID { get; set; }
        public int ItemNum;
        public int DropType{ get; set; } //0 公共掉落    1私人掉落 2 保护掉落 3 归属掉落

        public int CellIndex { get; set; } //喜从天降格子位

        public long OwnerId;
        public long ProtectTime;

        public long BeKillId{ get; set; }
        
        public int IfDamgeDrop;
        public List<long> BeAttackPlayerList = new List<long>();
        
        public DropInfo DropInfo;
    }
    
}