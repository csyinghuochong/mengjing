using UnityEngine;

namespace ET.Client
{
    public enum LoadState
    {
        None,
        WillLoad,
        Loaded,
        WillDetroy,
        Detroyed
    }
    
    [ChildOf(typeof(SceneUnitManagerComponent))]
    public class SceneUnit : Entity, IAwake, IDestroy
    {
        public string Prefabname;
        public string Tag;
        public int Layer;
        public Vector3 Position { get; set; }
        public Quaternion Rotation{ get; set; }
        public Vector3 Scale{ get; set; }
        
        public LoadState State { get; set; }
        public GameObject GameObject { get; set; }
        public GameObject ParentGo { get; set; }
    }
}

