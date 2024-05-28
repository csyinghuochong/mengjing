namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class JiaYuanDungeonComponent: Entity, IAwake, IDestroy
    {
        public long MasterId { get; set; } = 0;
    }
}