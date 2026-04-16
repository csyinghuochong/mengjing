namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgRegister : Entity, IAwake, IUILogic
    {
        public DlgRegisterViewComponent View { get => this.GetComponent<DlgRegisterViewComponent>(); }

        public long LastRegisterTime;
    }
}