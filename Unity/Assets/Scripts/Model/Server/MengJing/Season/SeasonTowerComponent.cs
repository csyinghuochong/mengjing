namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class SeasonTowerComponent : Entity, IAwake
    {
        public long BeginTime;
    }
}