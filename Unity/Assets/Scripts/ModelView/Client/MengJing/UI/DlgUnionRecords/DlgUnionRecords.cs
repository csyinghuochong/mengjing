using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgUnionRecords: Entity, IAwake, IUILogic
    {
        public DlgUnionRecordsViewComponent View
        {
            get => this.GetComponent<DlgUnionRecordsViewComponent>();
        }

        public Dictionary<int, EntityRef<Scroll_Item_UnionRecordsItem>> ScrollItemUnionRecordsItems;
        public List<string> ShowInfo = new();
    }
}