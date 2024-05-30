using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgChouKaWarehouse: Entity, IAwake, IUILogic
    {
        public DlgChouKaWarehouseViewComponent View
        {
            get => this.GetComponent<DlgChouKaWarehouseViewComponent>();
        }

        public Dictionary<int, Scroll_Item_CommonItem> ScrollItemHouseItems;
        public List<BagInfo> ShowHouseBagInfos = new();
        public Dictionary<int, Scroll_Item_CommonItem> ScrollItemBagItems;
        public List<BagInfo> ShowBagBagInfos = new();
    }
}