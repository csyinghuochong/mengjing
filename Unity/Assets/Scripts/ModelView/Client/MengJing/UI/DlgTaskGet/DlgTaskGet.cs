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

        public int NpcID;
        public int TaskId;
        public List<int> ShowTaskId = new();
        
        public Dictionary<int, Scroll_Item_TaskGetItem> ScrollItemTaskGetItems;
        public Dictionary<int, Scroll_Item_TaskFubenItem> ScrollItemTaskFubenItems;
    }
}