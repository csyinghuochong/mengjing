using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgRoleXiLianTen: Entity, IAwake, IUILogic
    {
        public DlgRoleXiLianTenViewComponent View
        {
            get => this.GetComponent<DlgRoleXiLianTenViewComponent>();
        }

        public GameObject UIRoleXiLianTenItem;
    }
}