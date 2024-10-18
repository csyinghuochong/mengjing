using UnityEngine;

namespace ET.Client
{
    [ChildOf(typeof(FallingFontComponent))]
    public class FallingFontShowComponent : Entity, IAwake, IDestroy
    {
        private EntityRef<Unit> unit;
        public Unit Unit { get => this.unit; set => this.unit = value; }
        public string ShowText;
        public FallingFontType FontType;
        public Vector3 StartScale;
        public BloodTextLayer BloodTextLayer;
        public FallingFontExecuteType FallingFontExecuteType;
        public string FallingFontPath;
        public Transform Transform;
        public GameObject GameObject;
        public GameObject ObjFlyText;
        public float DamgeFlyTimeSum = 0;
        public GameObject HeadBar;
        public float Fly_Y_Sum = 0;
    }
}