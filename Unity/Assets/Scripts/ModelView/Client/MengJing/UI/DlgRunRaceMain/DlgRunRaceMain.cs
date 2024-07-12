using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgRunRaceMain: Entity, IAwake, IUILogic
    {
        public DlgRunRaceMainViewComponent View
        {
            get => this.GetComponent<DlgRunRaceMainViewComponent>();
        }

        public long NextTransformTime;
        public long EndTime;
        public long ReadyTime;
        public List<GameObject> Rankings = new();

        public List<EntityRef<ES_SkillGrid>> UISkillGrids = new();

        public int Index = 0;
    }
}