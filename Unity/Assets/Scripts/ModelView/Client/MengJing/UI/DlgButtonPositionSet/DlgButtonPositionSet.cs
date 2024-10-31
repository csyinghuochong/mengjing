using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgButtonPositionSet : Entity, IAwake, IUILogic
    {
        public DlgButtonPositionSetViewComponent View { get => this.GetComponent<DlgButtonPositionSetViewComponent>(); }

        public GameObject SkillIconItemCopy;
        public List<Vector2> SkillPositionList = new();
        public List<Vector2> InitPositionList = new();
        public List<Vector2> TempPositionList = new();

        public List<EntityRef<UISkillDragComponent>> UISkillDragList = new();
        public GameObject UIMain;
        public int CurDragIndex;
    }
}