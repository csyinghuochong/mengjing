using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgUnionJingXuan : Entity, IAwake, IUILogic
    {
        public DlgUnionJingXuanViewComponent View { get => this.GetComponent<DlgUnionJingXuanViewComponent>(); }

        public UnionInfo UnionInfo;

        public Dictionary<int, EntityRef<Scroll_Item_JingXuanItem>> ScrollItemJingXuanItems;
        public List<(int, UnionPlayerInfo)> UnionPlayerInfos = new();
    }
}