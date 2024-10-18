namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgRoleBagSplit : Entity, IAwake, IUILogic
    {
        public DlgRoleBagSplitViewComponent View
        {
            get => this.GetComponent<DlgRoleBagSplitViewComponent>();
        }

        public long Num;

        private EntityRef<ItemInfo> bagInfo;
        public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
    }
}