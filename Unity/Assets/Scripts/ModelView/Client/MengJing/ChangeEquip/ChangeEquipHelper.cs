using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf]
    public class ChangeEquipHelper : Entity, IAwake, IDestroy
    {
        //找到满足新贴图大小最合适的值,是2的倍数,这里限制了贴图分辨率最大为2的10次方,即1024*1024
        public int Occ;

        public bool UseLayer;

        public int EquipIndex { get; set; }

        public int WeaponId { get; set; }

        public bool LoadCompleted;

        public Mesh NewMesh;

        public Transform trparent;

        public Transform trparentbone;

        public Texture2D newDiffuseTexture;

        public string WeaponAsset;

        public GameObject WeaponObject;

        public Transform WeaponParent;
        public bool RimLight;

        public List<GameObject> gameObjects = new List<GameObject>();

        public List<GameObject> oldFashions = new   List<GameObject>(); 
        
        public List<string> objectNames = new List<string>();

        public Dictionary<int, int> FashionBase = new Dictionary<int, int>();

        public List<SkinnedMeshRenderer> skinnedMeshRenderers = new List<SkinnedMeshRenderer>();
    }
}