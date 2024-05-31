using System;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgWatchPaiMai: Entity, IAwake, IUILogic
    {
        public DlgWatchPaiMaiViewComponent View
        {
            get => this.GetComponent<DlgWatchPaiMaiViewComponent>();
        }

        public Action searchAction;
    }
}