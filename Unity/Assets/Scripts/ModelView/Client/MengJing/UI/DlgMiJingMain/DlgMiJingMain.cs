using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgMiJingMain: Entity, IAwake, IUILogic
    {
        public DlgMiJingMainViewComponent View
        {
            get => this.GetComponent<DlgMiJingMainViewComponent>();
        }

        public List<EntityRef<Scroll_Item_MainTeamItem>> TeamUIList = new();
    }
}