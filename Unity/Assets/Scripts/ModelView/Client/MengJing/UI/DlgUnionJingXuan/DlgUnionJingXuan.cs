namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgUnionJingXuan : Entity, IAwake, IUILogic
    {
        public DlgUnionJingXuanViewComponent View { get => this.GetComponent<DlgUnionJingXuanViewComponent>(); }

        public UnionInfo UnionInfo;
    }
}