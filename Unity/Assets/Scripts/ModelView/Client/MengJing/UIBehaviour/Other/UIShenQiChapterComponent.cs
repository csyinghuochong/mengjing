using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ChildOf]
    public class UIShenQiChapterComponent: Entity, IAwake<GameObject>
    {
        public GameObject ItemNode;
        public GameObject Text_Name;
        public GameObject GameObject;
        public Action<int> ActionClick;

        public List<Scroll_Item_MakeItem> MakeListUI = new();
    }
}