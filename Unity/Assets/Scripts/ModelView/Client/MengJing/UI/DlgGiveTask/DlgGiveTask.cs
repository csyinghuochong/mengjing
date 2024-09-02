using System;
using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgGiveTask : Entity, IAwake, IUILogic
    {
        public DlgGiveTaskViewComponent View { get => this.GetComponent<DlgGiveTaskViewComponent>(); }

        public int TaskId;

        public ItemInfo BagInfo { get; set; }
        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
        public List<ItemInfo> ShowBagInfos { get; set; } = new();
        public Action OnGiveAction { get; set; }
    }
}