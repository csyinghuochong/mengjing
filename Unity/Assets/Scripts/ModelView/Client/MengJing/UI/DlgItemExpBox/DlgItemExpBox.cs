namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgItemExpBox : Entity, IAwake, IUILogic
    {
        public DlgItemExpBoxViewComponent View { get => this.GetComponent<DlgItemExpBoxViewComponent>(); }

        public ItemInfo BagInfo { get; set; }
        public int WorldPlayerLv;
        public int Price;
        public int UseNum;
        public bool IsHoldDown;
    }
}