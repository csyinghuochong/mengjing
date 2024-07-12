using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgWeiJingShop : Entity, IAwake, IUILogic
    {
        public DlgWeiJingShopViewComponent View
        {
            get => this.GetComponent<DlgWeiJingShopViewComponent>();
        }

        public Dictionary<int, EntityRef<Scroll_Item_WeiJingShopItem>> ScrollItemWeiJingShopItems;
        public List<StoreSellConfig> ShowStoreSellConfigs = new();
        public int SellId;
    }
}