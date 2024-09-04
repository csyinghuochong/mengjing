using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class UIJiaYuanPastureComponent : Entity, IAwake, IDestroy
    {
        public EntityRef<Unit> MyUnit;
        public GameObject GameObject;

        public Transform UIPosition;

        public HeadBarUI HeadBarUI;

        public EntityRef<NumericComponentC> NumericComponent;

        public long Timer;

        public int PlanStage = -1;

        public bool MainUnitEnter;
        public bool MainUnitExit;
        public float EnterPassTime;
    }
}