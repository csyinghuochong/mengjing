namespace ET
{
    
    [ComponentOf(typeof(Scene))]
    public class MapComponent : Entity, IAwake
    {
        
        public int SceneId { set; get; }

        public int SceneType { set; get; }
    }
}

