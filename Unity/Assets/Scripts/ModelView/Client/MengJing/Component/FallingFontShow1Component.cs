using UnityEngine;

namespace ET.Client
{
    public enum FallingFont1Type
    {
        Type_0 = 0,
        Type_1 = 1,
    }

    [ChildOf(typeof(FallingFontComponent))]
    public class FallingFontShow1Component : Entity, IAwake, IDestroy
    {
        public Unit Unit { get; set; }
        public string ShowText;
        public FallingFont1Type FontType;
        public Vector3 StartScale;
        public Transform Transform;
        public GameObject GameObject;
        public GameObject ObjFlyText;
        public float DamgeFlyTimeSum = 0;
        public GameObject HeadBar;
        public float Fly_Y_Sum = 0;
    }
}