using UnityEngine;
using UnityEngine.UI;


namespace ET.Client
{
    
    [ChildOf(typeof(FallingFontComponent))]
    public class FallingFontShowComponent: Entity, IAwake, IDestroy
    {
        public Unit Unit { get; set; }
        public int FontType;
        public long TargetValue;
        public Transform Transform;
        public GameObject GameObject;
        public GameObject ObjFlyText;
        public float DamgeFlyTimeSum = 0;
        public GameObject HeadBar;
    }
    
}