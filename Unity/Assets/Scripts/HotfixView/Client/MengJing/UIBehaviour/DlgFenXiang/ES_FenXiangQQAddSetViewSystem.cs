using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_FenXiangQQAddSet))]
    [FriendOfAttribute(typeof (ES_FenXiangQQAddSet))]
    public static partial class ES_FenXiangQQAddSetSystem
    {
        [EntitySystem]
        private static void Awake(this ES_FenXiangQQAddSet self, Transform transform)
        {
            self.uiTransform = transform;

            self.ES_RewardList.Refresh(ActivityConfigCategory.Instance.Get(34002).Par_3);

            self.E_Button_AddQQButton.AddListener(self.OnButton_AddQQButton);

            if (GlobalHelp.GetPlatform() == 5 || GlobalHelp.GetPlatform() == 6)
            {
                self.E_Button_AddQQButton.gameObject.SetActive(false);
            }
            else
            {
                self.E_Button_AddQQButton.gameObject.SetActive(true);
            }
        }

        [EntitySystem]
        private static void Destroy(this ES_FenXiangQQAddSet self)
        {
            self.DestroyWidget();
        }

        public static void OnButton_AddQQButton(this ES_FenXiangQQAddSet self)
        {
            Application.OpenURL(
                "http://qm.qq.com/cgi-bin/qm/qr?_wv=1027&k=QWL7Ed6RtjIIB0Z1U1LUFvOeD71i_M2j&authKey=1glgSHXDGzy9gsSHwqOu2RqEX7lGY2g8V9VSljhHTHeqtg5AMZNMM8889wRFep1J&noverify=0&group_code=473268983");
        }
    }
}
