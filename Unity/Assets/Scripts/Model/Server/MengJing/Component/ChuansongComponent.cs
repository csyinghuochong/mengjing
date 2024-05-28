namespace ET.Server
{
    
    
    [ComponentOf(typeof(Unit))]
    public class ChuansongComponent: Entity, IAwake
    {
        public int CellIndex { get; set; }
        public bool Triggered { get; set; }
        public int DirectionType { get; set; }
    }
    
}