using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgNewYearViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgNewYear : Entity, IAwake, IUILogic
    {
        public DlgNewYearViewComponent View { get => this.GetComponent<DlgNewYearViewComponent>(); }
    }
}