using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgItemTips: Entity, IAwake, IUILogic
    {
        public DlgItemTipsViewComponent View
        {
            get => this.GetComponent<DlgItemTipsViewComponent>();
        }

        public BagInfo BagInfo;
        public Vector2 Img_backVector2;
        public float Lab_ItemNameWidth;
    }
}