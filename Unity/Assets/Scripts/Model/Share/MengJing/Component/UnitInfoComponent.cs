namespace ET
{
    
    [ComponentOf(typeof(Unit))]
    public class UnitInfoComponent : Entity, IAwake
    {


        public int LastDungeonId { get; set; }
    }
}