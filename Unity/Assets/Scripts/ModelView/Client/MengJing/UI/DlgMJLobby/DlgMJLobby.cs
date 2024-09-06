using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgMJLobby: Entity, IAwake, IUILogic
    {
        public DlgMJLobbyViewComponent View
        {
            get => this.GetComponent<DlgMJLobbyViewComponent>();
        }

        public int PageIndex = 0;
        public int PageCount = 4;
        public CreateRoleInfo SeletRoleInfo;
        public Dictionary<int, EntityRef<Scroll_Item_CreateRoleItem>> ScrollItemCreateRoleItems;
        public List<CreateRoleInfo> ShowCreateRoleInfos = new();
        
        public float LastLoginTime;
    }
}