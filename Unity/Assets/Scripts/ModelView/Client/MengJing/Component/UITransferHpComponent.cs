using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Unit))]
    public class UITransferHpComponent : Entity, IAwake, IDestroy
    {
        public GameObject HeadBar;

        public Camera UICamera;
        public Camera MainCamera;

        public Transform UIPosition;

        public HeadBarUI HeadBarUI;

        public bool EnterRange;

        public long InitTime;

        public long Timer;

        public float Distance;
        public bool IsPlayerBornInArea;
        public long PlayerLeaveTime;
    }
}