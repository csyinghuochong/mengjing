namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgItemExpBox : Entity, IAwake, IUILogic
    {
        public DlgItemExpBoxViewComponent View { get => this.GetComponent<DlgItemExpBoxViewComponent>(); }

        public BagInfo BagInfo;
        public int WorldPlayerLv;
        public int Price;
        public int UseNum;
        public bool IsHoldDown;
    }
}