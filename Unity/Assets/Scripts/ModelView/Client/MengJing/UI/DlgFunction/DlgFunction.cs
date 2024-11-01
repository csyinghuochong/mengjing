namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgFunction : Entity, IAwake, IUILogic
    {
        public DlgFunctionViewComponent View { get => this.GetComponent<DlgFunctionViewComponent>(); }

        public bool ExitCamera;
    }
}