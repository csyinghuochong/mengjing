using System;
using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgUnionApplyList : Entity, IAwake, IUILogic
    {
        public DlgUnionApplyListViewComponent View { get => this.GetComponent<DlgUnionApplyListViewComponent>(); }

        public List<UnionPlayerInfo> ApplyPlayerInfos = new();
        public Dictionary<int, EntityRef<Scroll_Item_UnionApplyListItem>> ScrollItemUnionApplyListItems;
        public Action ActionFunc { get; set; }
    }
}