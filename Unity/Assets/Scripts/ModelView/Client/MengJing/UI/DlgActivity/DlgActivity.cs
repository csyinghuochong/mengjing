using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgActivity : Entity, IAwake, IUILogic
    {
        public DlgActivityViewComponent View { get => this.GetComponent<DlgActivityViewComponent>(); }
    }
}