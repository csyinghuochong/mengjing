using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgTaskGet: Entity, IAwake, IUILogic
    {
        public DlgTaskGetViewComponent View
        {
            get => this.GetComponent<DlgTaskGetViewComponent>();
        }

        public List<string> AssetList { get; set; } = new();
        
        public int NpcID;
        public int TaskId;
        public List<int> ShowTaskId = new();
        public List<ItemInfo> ShowBagInfos { get; set; } = new();
        
        public ETCancellationToken CancellationToken;

        public Dictionary<int, EntityRef<Scroll_Item_TaskGetItem>> ScrollItemTaskGetItems = new();
        public Dictionary<int, EntityRef<Scroll_Item_TaskFubenItem>> ScrollItemTaskFubenItems = new();
        public Dictionary<int, EntityRef<Scroll_Item_TaskRewardItem>> ScrollItemTaskRewardItems;
    }
}