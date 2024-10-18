using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class UINpcHpComponent : Entity, IAwake, IDestroy
    {
        private EntityRef<Unit> unit;
        public Unit Unit { get => this.unit; set => this.unit = value; }
        public GameObject UINpcName;
        public Vector3 OldPosition;
        public Vector3 NewPosition;
        public bool MainUnitEnter;
        public bool MainUnitExit;
        public float EnterPassTime;

        public int NpcId;
        public HeadBarUI HeadBarUI;
        public GameObject[] EffectComTask = new GameObject[2];

        public long TurtleTimer;
    }
}