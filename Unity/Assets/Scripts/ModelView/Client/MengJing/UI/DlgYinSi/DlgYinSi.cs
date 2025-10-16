
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgYinSi : Entity, IAwake, IUILogic
    {
        public DlgYinSiViewComponent View { get => this.GetComponent<DlgYinSiViewComponent>(); }

        public Vector2 YonghuxieyiPostion;
        public Vector2 YinSiXieYiPostion;
        public int AgreeNumber = 0;
    }
}