namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgTuZhiMake : Entity, IAwake, IUILogic
    {
        public DlgTuZhiMakeViewComponent View { get => this.GetComponent<DlgTuZhiMakeViewComponent>(); }

        private EntityRef<ItemInfo> bagInfo;
        public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
        public int MakeId;
    }
}