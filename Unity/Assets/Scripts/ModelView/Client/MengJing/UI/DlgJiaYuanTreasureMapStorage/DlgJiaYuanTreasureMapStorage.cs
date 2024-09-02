using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgJiaYuanTreasureMapStorage: Entity, IAwake, IUILogic
    {
        public DlgJiaYuanTreasureMapStorageViewComponent View
        {
            get => this.GetComponent<DlgJiaYuanTreasureMapStorageViewComponent>();
        }

        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemHouseItems;
        public List<ItemInfo> ShowHouseBagInfos { get; set; }
        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemBagItems;
        public List<ItemInfo> ShowBagBagInfos { get; set; }
    }
}