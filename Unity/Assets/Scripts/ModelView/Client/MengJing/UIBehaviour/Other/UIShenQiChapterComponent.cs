using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ChildOf]
    public class UIShenQiChapterComponent: Entity, IAwake<GameObject>
    {
        public float Height;
        public bool IsExpand;
        public GameObject Button_Click;
        public GameObject Checkmark;
        public GameObject ItemNode;
        public GameObject Text_Name;
        public GameObject GameObject;
        public Action<int> ActionClick;

        public List<EntityRef<Scroll_Item_MakeItem>> MakeListUI = new();
    }
}