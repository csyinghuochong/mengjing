using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgTeamDungeonCreate: Entity, IAwake, IUILogic
    {
        public DlgTeamDungeonCreateViewComponent View
        {
            get => this.GetComponent<DlgTeamDungeonCreateViewComponent>();
        }

        public int FubenId;
        public List<int> FubenIdList = new();
        public List<Transform> ButtonList = new();
    }
}