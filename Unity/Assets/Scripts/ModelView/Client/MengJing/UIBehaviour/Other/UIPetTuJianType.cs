using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [ChildOf]
    public class UIPetTuJianType : Entity, IAwake<GameObject, GameObject>
    {
        public GameObject GameObject;
        public GameObject UIChengJiuShowChapterItemListNode;
        public GameObject ImageButton;
        public GameObject TaskTypeName;

        public int ChengJiuType { get; set; }
        public Action<int> OnTypeAction;
        public Action<int> OnChapterAction;
        public List<EntityRef<UIPetTuJianItem>> UIPetTuJianItems { get; set; } = new();
    }
}