using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [ChildOf]
    public class UISkillDragComponent: Entity, IAwake<int, GameObject>
    {
        public int SkillIndex { get; set; }
        public GameObject Img_EventTrigger { get; set; }
        public GameObject GameObject { get; set; }

        public Action<int> BeginDrag_TriggerHandler { get; set; }
        public Action<PointerEventData> Drag_TriggerHandler { get; set; }
        public Action<PointerEventData> EndDrag_TriggerHandler { get; set; }
        public Action<PointerEventData> OnCancel_TriggerHandler { get; set; }
    }
}