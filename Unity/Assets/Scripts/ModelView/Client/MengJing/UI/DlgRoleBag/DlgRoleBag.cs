using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgRoleBag: Entity, IAwake, IUILogic
    {
        public DlgRoleBagViewComponent View
        {
            get => this.GetComponent<DlgRoleBagViewComponent>();
        }

        public Dictionary<int, Scroll_Item_BagItem> ScrollItemBagItems;
        public int CurrentItemType;
    }
}