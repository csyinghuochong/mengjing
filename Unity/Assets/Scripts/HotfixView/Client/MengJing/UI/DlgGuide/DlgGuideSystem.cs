using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgGuideViewComponent))]
    [FriendOf(typeof(DlgGuide))]
    public static class DlgGuideSystem
    {
        [Invoke(TimerInvokeType.UIGuideTimer)]
        public class UIGuideTimer : ATimer<DlgGuide>
        {
            protected override void Run(DlgGuide self)
            {
                try
                {
                    self.OnUpdate();
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
            }
        }

        public static void RegisterUIEvent(this DlgGuide self)
        {
            self.View.EG_PositionSetRectTransform.gameObject.SetActive(false);
        }

        public static void ShowWindow(this DlgGuide self, Entity contextData = null)
        {
        }

        public static void BeforeUnload(this DlgGuide self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void SetPosition(this DlgGuide self, GameObject target, GuideConfig guideConfig)
        {
            self.Target = target;
            self.GuideConfig = guideConfig;

            if (self.GuideConfig != null)
            {
                self.View.E_ShowLabSetImage.gameObject.SetActive(true);
                self.View.E_ShowLabText.text = self.GuideConfig.Text;
            }
            else
            {
                self.View.E_ShowLabSetImage.gameObject.SetActive(false);
            }

            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
            self.Timer = self.Root().GetComponent<TimerComponent>().NewFrameTimer(TimerInvokeType.UIGuideTimer, self);
        }

        private static void OnUpdate(this DlgGuide self)
        {
            if (self.Target == null)
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Guide);
                return;
            }

            if (self.Target.activeInHierarchy == false)
            {
                self.View.EG_TipRootRectTransform.gameObject.SetActive(false);
                return;
            }
            
            self.View.EG_TipRootRectTransform.gameObject.SetActive(true);

            RectTransform guideRect = self.View.EG_TipRootRectTransform;
            RectTransform targetRect = self.Target.GetComponent<RectTransform>();

            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(guideRect.parent as RectTransform,
                targetRect.position,
                null,
                out localPoint);

            Vector2 offset = Vector2.zero;
            if (self.GuideConfig.Offset.Length == 2)
            {
                offset.x = self.GuideConfig.Offset[0];
                offset.y = self.GuideConfig.Offset[1];
            }

            guideRect.anchoredPosition = localPoint + offset;
        }
    }
}