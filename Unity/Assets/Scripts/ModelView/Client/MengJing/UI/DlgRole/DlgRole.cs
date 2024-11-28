using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgRoleViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgRole : Entity, IAwake, IUILogic
    {
        public DlgRoleViewComponent View
        {
            get => this.GetComponent<DlgRoleViewComponent>();
        }

        public int Position;
        public int Index;
    }
}