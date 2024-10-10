using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgCellDungeonEnterShow : Entity, IAwake, IUILogic
    {
        public DlgCellDungeonEnterShowViewComponent View { get => this.GetComponent<DlgCellDungeonEnterShowViewComponent>(); }

        public GameObject JingYingGuanKaShowSet;
        public GameObject Lab_ChapterName;
        public GameObject PostionSet;

        public Vector3 chushiVec3 = Vector3.zero;
        public bool stopMoveStart = false;
        public bool stopMoveEnd = false;
        public float timeSum = 0f;
        public bool stopMoveStatus;
        public float moveDis = 0;
        public float nowDis = 0f;
        public int NanDu;
        public GameObject ObjNanDu_1;
        public GameObject ObjNanDu_2;
        public GameObject ObjNanDu_3;
    }
}