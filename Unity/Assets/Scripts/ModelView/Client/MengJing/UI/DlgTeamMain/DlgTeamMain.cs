using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgTeamMain : Entity, IAwake, IUILogic
    {
        public DlgTeamMainViewComponent View
        {
            get => this.GetComponent<DlgTeamMainViewComponent>();
        }

        public long Timer;
        public int LeftTime;
        public EntityRef<Unit> CurDrop;
        public List<EntityRef<Unit>> DropInfos = new();
    }
}