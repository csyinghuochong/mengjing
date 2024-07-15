namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgTurtle : Entity, IAwake, IUILogic
    {
        public DlgTurtleViewComponent View { get => this.GetComponent<DlgTurtleViewComponent>(); }

        public int SupportId;
        public long EndTime;
    }
}