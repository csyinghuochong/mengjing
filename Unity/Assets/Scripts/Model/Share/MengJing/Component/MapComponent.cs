namespace ET
{
    
    [ComponentOf(typeof(Scene))]
    public class MapComponent : Entity, IAwake
    {
        
        public int SceneId { set; get; }

        public int MapType { set; get; }

        public long LastQuitTime { set; get; }
        
        public int SonSceneId{ set; get; }

        public int NavMeshId { set; get; }

        public int FubenDifficulty { set; get; }
        
        public string ParamInfo{ set; get; }
    }
}

