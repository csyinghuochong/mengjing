using System;
using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgGiveTask : Entity, IAwake, IUILogic
    {
        public DlgGiveTaskViewComponent View { get => this.GetComponent<DlgGiveTaskViewComponent>(); }

        public int TaskId;

        private EntityRef<ItemInfo> bagInfo;
        public ItemInfo BagInfo { get => this.bagInfo; set => this.bagInfo = value; }
        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
        public List<EntityRef<ItemInfo>> ShowBagInfos { get; set; } = new();
        public Action OnGiveAction { get; set; }
    }
}