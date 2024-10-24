using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgChouKaWarehouse : Entity, IAwake, IUILogic
    {
        public DlgChouKaWarehouseViewComponent View
        {
            get => this.GetComponent<DlgChouKaWarehouseViewComponent>();
        }

        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemHouseItems;
        public List<EntityRef<ItemInfo>> ShowHouseBagInfos { get; set; } = new();
        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemBagItems;
        public List<EntityRef<ItemInfo>> ShowBagBagInfos { get; set; } = new();
    }
}