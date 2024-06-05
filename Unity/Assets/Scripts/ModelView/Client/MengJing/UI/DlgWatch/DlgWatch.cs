namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgWatch: Entity, IAwake, IUILogic
    {
        public DlgWatchViewComponent View
        {
            get => this.GetComponent<DlgWatchViewComponent>();
        }

        public F2C_WatchPlayerResponse F2C_WatchPlayerResponse;
        public bool CanClick;
    }
}