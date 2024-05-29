namespace ET.Server
{
    
    [ComponentOf(typeof(Scene))]
    public class RandomTowerComponent : Entity,IAwake
    {
        public int TowerId { get; set; } 
    }
}