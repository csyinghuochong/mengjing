using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgGuideViewComponent))]
    [FriendOf(typeof(DlgGuide))]
    public static class DlgGuideSystem
    {
        public static void RegisterUIEvent(this DlgGuide self)
        {
            self.View.EG_PositionSetRectTransform.gameObject.SetActive(false);
        }

        public static void ShowWindow(this DlgGuide self, Entity contextData = null)
        {
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