using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgSeasonLordDetail : Entity, IAwake, IUILogic
    {
        public DlgSeasonLordDetailViewComponent View
        {
            get => this.GetComponent<DlgSeasonLordDetailViewComponent>();
        }

        private EntityRef<ItemInfo> bagInfo;
        public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
        public List<ItemInfo> ShowBagInfos { get; set; } = new();
        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
    }
}