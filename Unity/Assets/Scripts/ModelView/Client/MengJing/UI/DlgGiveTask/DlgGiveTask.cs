using System;
using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgGiveTask : Entity, IAwake, IUILogic
    {
        public DlgGiveTaskViewComponent View { get => this.GetComponent<DlgGiveTaskViewComponent>(); }

        public int TaskId;

        public BagInfo BagInfo;
        public Dictionary<int, EntityRef<Scroll_Item_CommonItem>> ScrollItemCommonItems;
        public List<BagInfo> ShowBagInfos = new();
        public Action OnGiveAction { get; set; }
    }
}