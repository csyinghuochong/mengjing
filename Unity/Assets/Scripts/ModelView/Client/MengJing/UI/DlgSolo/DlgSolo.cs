namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgSolo: Entity, IAwake, IUILogic
    {
        public DlgSoloViewComponent View
        {
            get => this.GetComponent<DlgSoloViewComponent>();
        }

        public bool PipeiStatus;
    }
}