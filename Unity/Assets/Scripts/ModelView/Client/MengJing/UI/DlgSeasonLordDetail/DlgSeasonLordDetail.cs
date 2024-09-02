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

        public ItemInfo BagInfo { get; set; }
        public List<ItemInfo> ShowBagInfos { get; set; } = new();
        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
    }
}