using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgGuide : Entity, IAwake, IUILogic, IUpdate
    {
        public DlgGuideViewComponent View { get => this.GetComponent<DlgGuideViewComponent>(); }

        public GuideConfig GuideConfig { get; set; }

        public GameObject Target;
        public long Timer;
    }
}