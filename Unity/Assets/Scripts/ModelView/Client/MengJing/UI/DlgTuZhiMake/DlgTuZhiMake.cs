namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgTuZhiMake : Entity, IAwake, IUILogic
    {
        public DlgTuZhiMakeViewComponent View { get => this.GetComponent<DlgTuZhiMakeViewComponent>(); }

        public ItemInfo BagInfo { get; set; }
        public int MakeId;
    }
}