namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgJiaYuanMenu: Entity, IAwake, IUILogic
    {
        public DlgJiaYuanMenuViewComponent View
        {
            get => this.GetComponent<DlgJiaYuanMenuViewComponent>();
        }

        public long UnitId;
        public int OperateType;
    }
}