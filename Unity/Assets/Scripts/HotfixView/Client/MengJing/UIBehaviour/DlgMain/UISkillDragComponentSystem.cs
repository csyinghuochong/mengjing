using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [FriendOf(typeof (UISkillDragComponent))]
    [EntitySystemOf(typeof (UISkillDragComponent))]
    public static partial class UISkillDragComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UISkillDragComponent self, int a, GameObject b)
        {
            self.SkillIndex = a;
            self.GameObject = b;
            self.Img_EventTrigger = b.transform.Find("Img_EventTrigger").gameObject;
            self.Img_EventTrigger.SetActive(false);

            self.Img_EventTrigger.GetComponent<EventTrigger>()
                    .RegisterEvent(EventTriggerType.BeginDrag, (pdata) => { self.BeginDrag_Trigger(pdata as PointerEventData); });
            self.Img_EventTrigger.GetComponent<EventTrigger>()
                    .RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Drag_Trigger(pdata as PointerEventData); });
            self.Img_EventTrigger.GetComponent<EventTrigger>()
                    .RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.EndDrag_Trigger(pdata as PointerEventData); });
            self.Img_EventTrigger.GetComponent<EventTrigger>()
                    .RegisterEvent(EventTriggerType.Cancel, (pdata) => { self.OnCancel_Trigger(pdata as PointerEventData); });
        }

        public static void BeginDrag_Trigger(this UISkillDragComponent self, PointerEventData eventData)
        {
            self.BeginDrag_TriggerHandler?.Invoke(self.SkillIndex);
        }

        public static void Drag_Trigger(this UISkillDragComponent self, PointerEventData eventData)
        {
            self.Drag_TriggerHandler?.Invoke(eventData);
        }

        public static void EndDrag_Trigger(this UISkillDragComponent self, PointerEventData eventData)
        {
            self.EndDrag_TriggerHandler?.Invoke(eventData);
        }

        public static void OnCancel_Trigger(this UISkillDragComponent self, PointerEventData eventData)
        {
            self.OnCancel_TriggerHandler?.Invoke(eventData);
        }
    }
}