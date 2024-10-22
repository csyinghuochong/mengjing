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

        private EntityRef<ItemInfo> mainBagInfo;
        public ItemInfo MainBagInfo { get => this.mainBagInfo; set => this.mainBagInfo = value; }
        public List<long> CostIds = new();
        public int MaxAdd;
        public int MinAdd;
        public List<EntityRef<ItemInfo>> ShowBagInfos { get; set; } = new();
        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
    }
}