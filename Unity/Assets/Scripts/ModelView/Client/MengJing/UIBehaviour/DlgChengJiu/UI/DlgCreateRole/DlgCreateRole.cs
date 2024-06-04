namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgCreateRole: Entity, IAwake, IUILogic
    {
        public DlgCreateRoleViewComponent View
        {
            get => this.GetComponent<DlgCreateRoleViewComponent>();
        }

        public int Occ;
    }
}