namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgYinSi : Entity, IAwake, IUILogic
    {
        public DlgYinSiViewComponent View { get => this.GetComponent<DlgYinSiViewComponent>(); }

        public int AgreeNumber = 0;
    }
}