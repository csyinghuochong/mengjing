using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgJiaYuanMain: Entity, IAwake, IUILogic
    {
        public DlgJiaYuanMainViewComponent View
        {
            get => this.GetComponent<DlgJiaYuanMainViewComponent>();
        }

        public int CellIndex { get; set; }

        public int LastPasureIndex;
        public int LastCellIndex;

        public GameObject SelectEffect;

        public long GatherTime;

        // public UIJiaYuanVisitComponent UIJiaYuaVisitComponent;
        public Dictionary<int, GameObject> JianYuanPlanUIs = new();
        public Dictionary<int, EntityRef<JiaYuanPlanLockComponent>> JiaYuanPlanLocks = new();

        public long PetTimer;
        public JiaYuanPet JiaYuanPet;

        public bool MyJiaYuan;
        public int JiaYuanLv;
        public List<string> AssetPath = new();

        public float GatherRange = 6f;
    }
}