using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgCellDungeonEnterShow : Entity, IAwake, IUILogic
    {
        public DlgCellDungeonEnterShowViewComponent View { get => this.GetComponent<DlgCellDungeonEnterShowViewComponent>(); }

        public Vector3 chushiVec3 = Vector3.zero;
        public bool stopMoveStart = false;
        public bool stopMoveEnd = false;
        public float timeSum = 0f;
        public bool stopMoveStatus;
        public float moveDis = 0;
        public float nowDis = 0f;
        public int NanDu;
        public long Timer;
    }
}