using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class UIJiaYuanPlanComponent : Entity, IAwake, IDestroy
    {
        public GameObject GameObject;
        public Camera UICamera;
        public Camera MainCamera;
        public Transform UIPosition;
        public HeadBarUI HeadBarUI;
        public NumericComponentC NumericComponent { get; set; }

        public int PlanStage = -1;
        public long Timer;
    }
}