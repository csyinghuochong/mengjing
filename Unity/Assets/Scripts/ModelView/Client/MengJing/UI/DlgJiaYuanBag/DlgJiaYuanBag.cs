using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgJiaYuanBag : Entity, IAwake, IUILogic
    {
        public DlgJiaYuanBagViewComponent View
        {
            get => this.GetComponent<DlgJiaYuanBagViewComponent>();
        }

        private EntityRef<ItemInfo> bagInfo;
        public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
        public List<EntityRef<ItemInfo>> ShowBagInfos { get; set; } = new();
        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
    }
}