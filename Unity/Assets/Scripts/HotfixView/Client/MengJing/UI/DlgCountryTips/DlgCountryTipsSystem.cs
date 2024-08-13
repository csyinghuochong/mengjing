using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (DlgCountryTips))]
    public static class DlgCountryTipsSystem
    {
        public static void RegisterUIEvent(this DlgCountryTips self)
        {
            self.View.E_ImageButtonButton.AddListener(self.OnImageButtonButton);
        }

        public static void ShowWindow(this DlgCountryTips self, Entity contextData = null)
        {
        }

        public static void OnImageButtonButton(this DlgCountryTips self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CountryTips);
        }
        
        public static void OnUpdateUI(this DlgCountryTips self, string rewards, Vector3 vector3, int showType = 0)
        {
            self.View.ES_RewardList.Refresh(rewards);
            string[] rewardItems = rewards.Split('@');
            int width = 50 + rewardItems.Length * 130 + (rewardItems.Length - 1) * 10;
            float halfwidth = Screen.width * 0.5f;

            int r = rewardItems.Length / 5 + 1;
            if (rewardItems.Length % 5 == 0)
            {
                r -= 1;
            }

            self.View.E_Img_backImage.GetComponent<RectTransform>().sizeDelta = new Vector2(width, 100 + r * 130);

            //宠物布阵
            if (showType == 1)
            {
                vector3.y += 200;
                self.View.EG_PositionNodeRectTransform.localPosition = vector3;
                return;
            }

            if (vector3.x + width >= halfwidth)
            {
                vector3.x = halfwidth - width;
                self.View.EG_PositionNodeRectTransform.localPosition = vector3;
            }
            else
            {
                vector3.x += 300f;
                self.View.EG_PositionNodeRectTransform.localPosition = vector3;
            }

            if (vector3.y < -340)
            {
                float offsetup = vector3.y * -1f - 260f;
                self.View.EG_PositionNodeRectTransform.localPosition = vector3 + new Vector3(0, offsetup, 0);
            }
            else
            {
                self.View.EG_PositionNodeRectTransform.localPosition = vector3;
            }
        }
    }
}
