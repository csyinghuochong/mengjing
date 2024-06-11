namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgWorldLv: Entity, IAwake, IUILogic
    {
        public DlgWorldLvViewComponent View
        {
            get => this.GetComponent<DlgWorldLvViewComponent>();
        }

        public ServerInfo ServerInfo;
    }
}