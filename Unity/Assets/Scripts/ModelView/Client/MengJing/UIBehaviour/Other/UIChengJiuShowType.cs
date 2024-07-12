using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ChildOf]
    public class UIChengJiuShowType: Entity, IAwake<GameObject, GameObject>
    {
        public GameObject GameObject;
        public GameObject UIChengJiuShowChapterItemListNode;
        public GameObject ImageButton;
        public GameObject TaskTypeName;

        public int ChengJiuType;
        public Action<int> OnTypeAction;
        public Action<int, int> OnChapterAction;
        public List<EntityRef<UIChengJiuShowChapterItem>> UIChengJiuShowChapterItems = new();
    }
}