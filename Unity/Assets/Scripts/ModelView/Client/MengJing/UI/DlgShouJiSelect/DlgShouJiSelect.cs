using System;
using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgShouJiSelect: Entity, IAwake, IUILogic
    {
        public DlgShouJiSelectViewComponent View
        {
            get => this.GetComponent<DlgShouJiSelectViewComponent>();
        }

        public int ShouJIId;
        public Action UpdateRedDotAction;
        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
        public List<EntityRef<ItemInfo>> ShowBagInfos { get; set; } = new();
    }
}