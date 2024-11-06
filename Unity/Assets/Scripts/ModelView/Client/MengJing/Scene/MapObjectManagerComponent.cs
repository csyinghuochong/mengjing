using System.Collections.Generic;
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
    
    public class GameObjectTransInfo : Entity
    {
        public int aoi_x;
        public int aoi_z;
        public int aoi_index;
        
        private string name;
        private string parentname;
        private string prefabname;
        private string tag;
        private string layer;
        private Vector3 position;
        private Vector3 rotation;
        private Vector3 scale;
        
        public LoadState state { get; set; }
        public GameObject go { get; set; }
        public GameObject parentGo { get; set; }

        public GameObjectTransInfo( string name, string parentname, string prefabname, string tag, string layer, Vector3 pos, Vector3 rot, Vector3 scale)
        {
            this.name = name;
            this.parentname = parentname;
            this.prefabname = prefabname;
            this.tag = tag;
            this.layer = layer;
            this.position = pos;
            this.rotation = rot;
            this.scale = scale;

            this.state = LoadState.None;
            this.go = null;
            this.parentGo = null;
        }
    }

    
    [ComponentOf(typeof (Scene))]
    public class MapObjectManagerComponent: Entity, IAwake
    {
        
    }
}