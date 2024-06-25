namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgBuffTips: Entity, IAwake, IUILogic
    {
        public DlgBuffTipsViewComponent View
        {
            get => this.GetComponent<DlgBuffTipsViewComponent>();
        }

        public int BuffId { get; set; }
    }
}