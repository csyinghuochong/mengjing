using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgSeasonLordDetail: Entity, IAwake, IUILogic
    {
        public DlgSeasonLordDetailViewComponent View
        {
            get => this.GetComponent<DlgSeasonLordDetailViewComponent>();
        }

        public BagInfo BagInfo;
        public List<BagInfo> ShowBagInfos = new();
        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
    }
}