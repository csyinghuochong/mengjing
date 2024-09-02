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

        public ItemInfo BagInfo { get; set; }
        public Vector2 Img_backVector2;
        public float Lab_ItemNameWidth;
        public ItemOperateEnum ItemOperateEnum;
        public int CurrentHouse;
    }
}