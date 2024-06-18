using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgSeasonJingHeZhuru: Entity, IAwake, IUILogic
    {
        public DlgSeasonJingHeZhuruViewComponent View
        {
            get => this.GetComponent<DlgSeasonJingHeZhuruViewComponent>();
        }

        public BagInfo MainBagInfo;
        public List<long> CostIds = new();
        public int MaxAdd;
        public int MinAdd;
        public List<BagInfo> ShowBagInfos = new();
        public Dictionary<int, Scroll_Item_CommonItem> ScrollItemCommonItems;
    }
}