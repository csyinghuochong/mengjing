using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgMystery : Entity, IAwake, IUILogic
    {
        public DlgMysteryViewComponent View
        {
            get => this.GetComponent<DlgMysteryViewComponent>();
        }

        public Dictionary<int, EntityRef<Scroll_Item_MysteryItem>> ScrollItemMysteryItems;
        public List<MysteryItemInfo> MysteryItemInfos = new();
    }
}