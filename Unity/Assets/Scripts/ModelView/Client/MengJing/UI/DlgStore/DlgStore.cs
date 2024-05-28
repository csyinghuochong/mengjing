using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgStore: Entity, IAwake, IUILogic
    {
        public DlgStoreViewComponent View
        {
            get => this.GetComponent<DlgStoreViewComponent>();
        }

        public List<int> ShowStores = new();
        public Dictionary<int, Scroll_Item_StoreItem> ScrollItemStoreItems;
    }
}