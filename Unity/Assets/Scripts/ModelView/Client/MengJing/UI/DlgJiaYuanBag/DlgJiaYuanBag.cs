using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgJiaYuanBag: Entity, IAwake, IUILogic
    {
        public DlgJiaYuanBagViewComponent View
        {
            get => this.GetComponent<DlgJiaYuanBagViewComponent>();
        }

        public BagInfo BagInfo;
        public List<BagInfo> ShowBagInfos = new();
        public Dictionary<int, Scroll_Item_CommonItem> ScrollItemCommonItems;
    }
}