using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgUnionKeJiViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgUnionKeJi : Entity, IAwake, IUILogic
    {
        public DlgUnionKeJiViewComponent View { get => this.GetComponent<DlgUnionKeJiViewComponent>(); }
        public bool IsInitInfo;
        public UnionInfo UnionMyInfo { get; set; }
    }
}