using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetEggFuLing : Entity, IAwake, IUILogic
    {
        public DlgPetEggFuLingViewComponent View { get => this.GetComponent<DlgPetEggFuLingViewComponent>(); }

        public BagInfo BagInfo;
        public long EggId;
        public List<BagInfo> ShowBagInfos = new();
        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
    }
}