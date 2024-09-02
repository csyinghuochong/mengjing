namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgRoleBagSplit: Entity, IAwake, IUILogic
    {
        public DlgRoleBagSplitViewComponent View
        {
            get => this.GetComponent<DlgRoleBagSplitViewComponent>();
        }

        public long Num;
        public ItemInfo BagInfo { get; set; }
    }
}