using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgJiaYuanFoodViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgJiaYuanFood : Entity, IAwake, IUILogic
    {
        public DlgJiaYuanFoodViewComponent View { get => this.GetComponent<DlgJiaYuanFoodViewComponent>(); }
    }
}