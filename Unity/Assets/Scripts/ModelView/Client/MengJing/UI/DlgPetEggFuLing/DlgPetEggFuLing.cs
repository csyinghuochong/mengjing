using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetEggFuLing : Entity, IAwake, IUILogic
    {
        public DlgPetEggFuLingViewComponent View { get => this.GetComponent<DlgPetEggFuLingViewComponent>(); }

        private EntityRef<ItemInfo> bagInfo;
        public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
        public long EggId;
        public List<EntityRef<ItemInfo>> ShowBagInfos { get; set; } = new();
        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
    }
}