using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgSelectServer : Entity, IAwake, IUILogic
    {
        public DlgSelectServerViewComponent View { get => this.GetComponent<DlgSelectServerViewComponent>(); }

        public List<ServerItem> AllserverList;
        public Dictionary<int, EntityRef<Scroll_Item_SelectServerItem>> ScrollItemSelectServerItems1;
        public List<ServerItem> MyServers;
        public Dictionary<int, EntityRef<Scroll_Item_SelectServerItem>> ScrollItemSelectServerItems2;
    }
}