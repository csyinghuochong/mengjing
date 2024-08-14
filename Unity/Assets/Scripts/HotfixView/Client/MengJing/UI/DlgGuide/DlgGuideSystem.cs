using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgGuideViewComponent))]
    [FriendOf(typeof(DlgGuide))]
    public static class DlgGuideSystem
    {
        public static void RegisterUIEvent(this DlgGuide self)
        {
        }

        public static void ShowWindow(this DlgGuide self, Entity contextData = null)
        {
            self.View.EG_PositionSetRectTransform.gameObject.SetActive(false);
        }

        public static void SetPosition(this DlgGuide self, GameObject gameObject)
        {
            CommonViewHelper.SetParent(self.View.uiTransform.gameObject, gameObject);

            if (self.GuideConfig != null)
            {
                self.View.E_ShowLabSetImage.gameObject.SetActive(true);
                self.View.E_ShowLabText.text = self.GuideConfig.Text;
            }
            else
            {
                self.View.E_ShowLabSetImage.gameObject.SetActive(false);
            }
        }
    }
}