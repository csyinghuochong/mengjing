using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgTeam: Entity, IAwake, IUILogic
    {
        public DlgTeamViewComponent View
        {
            get => this.GetComponent<DlgTeamViewComponent>();
        }

        public GameObject[] UITeamNodeList = new GameObject[3];
        public List<ES_TeamItem> TeamUIList = new();
    }
}