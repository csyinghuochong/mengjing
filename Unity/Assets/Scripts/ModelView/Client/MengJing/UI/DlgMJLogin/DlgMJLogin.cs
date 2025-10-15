using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgMJLogin : Entity, IAwake, IUILogic
    {
        public DlgMJLoginViewComponent View { get => this.GetComponent<DlgMJLoginViewComponent>(); }
        
        public ServerItem ServerInfo;

        public long LastLoginTime;

        public Vector2 YinsixieyiPostion;
    }
}