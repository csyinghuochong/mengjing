using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgHuoBiSet: Entity, IAwake, IUILogic
    {
        public DlgHuoBiSetViewComponent View
        {
            get => this.GetComponent<DlgHuoBiSetViewComponent>();
        }
        
        public Sprite DefaultTitleIconSprite;
    }
}