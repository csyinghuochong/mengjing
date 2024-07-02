using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof (UIBaseWindow))]
    public class DlgDemonMain: Entity, IAwake, IUILogic
    {
        public DlgDemonMainViewComponent View
        {
            get => this.GetComponent<DlgDemonMainViewComponent>();
        }

        public long EndTime;
        public long ReadyTime;
        public List<GameObject> Rankings = new();
    }
}