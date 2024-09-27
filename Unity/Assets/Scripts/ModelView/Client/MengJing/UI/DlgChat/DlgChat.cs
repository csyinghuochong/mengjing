using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgChat: Entity, IAwake, IUILogic
    {
        public DlgChatViewComponent View
        {
            get => this.GetComponent<DlgChatViewComponent>();
        }
        
        public int CurrentChatType;
        public Dictionary<int, EntityRef<Scroll_Item_ChatItem>> ScrollItemChatItems;
        public List<ChatInfo> ShowChatInfos = new();
    }
}