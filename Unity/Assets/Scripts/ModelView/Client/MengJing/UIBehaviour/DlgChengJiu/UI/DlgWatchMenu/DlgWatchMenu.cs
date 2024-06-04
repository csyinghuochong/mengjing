namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgWatchMenu: Entity, IAwake, IUILogic
    {
        public DlgWatchMenuViewComponent View
        {
            get => this.GetComponent<DlgWatchMenuViewComponent>();
        }

        public long UserId;
        public long TeamId;
        public string UserName;
    }
}