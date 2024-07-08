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

        public Dictionary<int, Scroll_Item_CommonItem> ScrollItemHouseItems;
        public List<BagInfo> ShowHouseBagInfos;
        public Dictionary<int, Scroll_Item_CommonItem> ScrollItemBagItems;
        public List<BagInfo> ShowBagBagInfos;
    }
}