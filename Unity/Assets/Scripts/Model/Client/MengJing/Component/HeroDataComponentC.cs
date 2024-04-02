namespace ET.Client
{
    
    [ComponentOf(typeof(Unit))]
    public class HeroDataComponentC: Entity, IAwake
    {
        public int ItemID;
        public int ItemNum;
        public int DropType;  //0 公共掉落    1私人掉落 2 保护掉落 3 归属掉落

        public int CellIndex;  //喜从天降格子位

        public long OwnerId;
        public long ProtectTime;

        public long BeKillId;

        public DropInfo DropInfo { get; set; }
    }
    
}
