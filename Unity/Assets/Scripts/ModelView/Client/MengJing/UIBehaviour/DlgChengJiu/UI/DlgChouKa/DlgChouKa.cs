namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgChouKa: Entity, IAwake, IUILogic
    {
        public DlgChouKaViewComponent View
        {
            get => this.GetComponent<DlgChouKaViewComponent>();
        }

        public int TakeCardId;
        public long Timer;
    }
}