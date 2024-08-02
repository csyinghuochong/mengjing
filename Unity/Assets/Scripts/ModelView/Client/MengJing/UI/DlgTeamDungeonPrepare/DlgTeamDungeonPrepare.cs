using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgTeamDungeonPrepare : Entity, IAwake, IUILogic
    {
        public DlgTeamDungeonPrepareViewComponent View { get => this.GetComponent<DlgTeamDungeonPrepareViewComponent>(); }

        public GameObject[] TeamPlayerItemList = new GameObject[3];
        public TeamInfo TeamInfo;
        public long Timer;
    }
}