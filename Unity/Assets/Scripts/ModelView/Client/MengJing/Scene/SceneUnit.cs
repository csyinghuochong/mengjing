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
        public string Name;
        public string Parentname;
        public string Prefabname;
        public string Tag;
        public string Layer;
        public Vector3 Position { get; set; }
        public Vector3 Rotation;
        public Vector3 Scale;
        
        public LoadState State { get; set; }
        public GameObject Go { get; set; }
        public GameObject ParentGo { get; set; }
    }
}

