using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (Unit))]
    public class UIDropComponent: Entity, IAwake, IDestroy
    {
        public Unit MyUnit { get; set; }
        public int PositionIndex; //曲线点的索引
        public Vector3 StartPoint;
        public Vector3 EndPoint;
        public Vector3[] LinepointList;
        public GameObject HeadBar;
        public Transform UIPosition;
        public Camera UICamera;
        public Camera MainCamera;
        public MeshRenderer ModelMesh; //AI材质
        public int Resolution;
        public float LastTime;
        public HeadBarUI HeadBarUI;
        public long Timer;
        public bool IfPlayEffect;

        public long CreatTime;

        public List<string> AssetPath = new List<string>();
    }
}