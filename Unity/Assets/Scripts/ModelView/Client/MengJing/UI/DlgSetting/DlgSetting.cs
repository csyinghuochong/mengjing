using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgSettingViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgSetting : Entity, IAwake, IUILogic
    {
        public DlgSettingViewComponent View { get => this.GetComponent<DlgSettingViewComponent>(); }
    }
}