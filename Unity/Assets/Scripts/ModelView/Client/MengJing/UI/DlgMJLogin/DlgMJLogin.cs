using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgMJLogin : Entity, IAwake, IUILogic
    {
        public DlgMJLoginViewComponent View { get => this.GetComponent<DlgMJLoginViewComponent>(); }
        
        public ServerItem ServerInfo;

        public long LastLoginTime;
    }
}