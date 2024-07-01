namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgTowerOpen: Entity, IAwake, IUILogic
    {
        public DlgTowerOpenViewComponent View
        {
            get => this.GetComponent<DlgTowerOpenViewComponent>();
        }

        public long Timer;
        public float PassTime;

        public M2C_FubenSettlement M2C_FubenSettlement { get; set; }
    }
}