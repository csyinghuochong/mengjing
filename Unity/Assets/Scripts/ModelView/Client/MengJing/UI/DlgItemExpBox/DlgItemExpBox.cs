namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgItemExpBox : Entity, IAwake, IUILogic
    {
        public DlgItemExpBoxViewComponent View { get => this.GetComponent<DlgItemExpBoxViewComponent>(); }

        private EntityRef<ItemInfo> bagInfo;
        public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
        public int WorldPlayerLv;
        public int Price;
        public int UseNum;
        public bool IsHoldDown;
    }
}