using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgOccTwo : Entity, IAwake, IUILogic
    {
        public DlgOccTwoViewComponent View
        {
            get => this.GetComponent<DlgOccTwoViewComponent>();
        }

        public List<GameObject> Button_ZhiYe_List = new();
        public int OccTwoId;

        public Dictionary<int, string> showType = new()
        {
            { 1, "剑类" },
            { 2, "刀类" },
            { 3, "法杖" },
            { 4, "魔法书" },
            { 5, "弓箭" },
            { 11, "布甲" },
            { 12, "轻甲" },
            { 13, "重甲" },
        };
    }
}