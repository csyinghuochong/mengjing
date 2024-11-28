using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgFenXiangViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgFenXiang : Entity, IAwake, IUILogic
    {
        public DlgFenXiangViewComponent View { get => this.GetComponent<DlgFenXiangViewComponent>(); }
    }
}