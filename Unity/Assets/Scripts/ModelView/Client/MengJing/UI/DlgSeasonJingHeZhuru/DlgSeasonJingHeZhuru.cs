using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgSeasonJingHeZhuru : Entity, IAwake, IUILogic
    {
        public DlgSeasonJingHeZhuruViewComponent View
        {
            get => this.GetComponent<DlgSeasonJingHeZhuruViewComponent>();
        }

        public ItemInfo MainBagInfo { get; set; }
        public List<long> CostIds = new();
        public int MaxAdd;
        public int MinAdd;
        public List<ItemInfo> ShowBagInfos { get; set; } = new();
        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
    }
}