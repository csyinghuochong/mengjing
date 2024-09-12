using UnityEngine;

namespace ET.Client
{
    public enum FallingFontType
    {
        Normal = 0,
        Self = 1,
        Target = 2,
        Add = 3,
        Special = 4
    }

    [ChildOf(typeof(FallingFontComponent))]
    public class FallingFontShowComponent : Entity, IAwake, IDestroy
    {
        public string ShowText;
        public FallingFontType FontType;
        public Vector3 StartScale;
        public Transform Transform;
        public GameObject GameObject;
        public GameObject ObjFlyText;
        public float DamgeFlyTimeSum = 0;
        public GameObject HeadBar;
        public Unit Unit { get; set; }
    }
}