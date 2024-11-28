using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgSkill : Entity, IAwake, IUILogic
    {
        public DlgSkillViewComponent View { get => this.GetComponent<DlgSkillViewComponent>(); }
    }
}