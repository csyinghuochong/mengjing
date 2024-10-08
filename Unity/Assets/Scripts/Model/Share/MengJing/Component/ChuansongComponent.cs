namespace ET
{
    
    
    [ComponentOf(typeof(Unit))]
    public class ChuansongComponent: Entity, IAwake
    {
        public int CellIndex { get; set; }
        public bool Triggered { get; set; }
        public int DirectionType { get; set; }
        
        public bool ChuanSongOpen{ get; set; }
    }
    
}