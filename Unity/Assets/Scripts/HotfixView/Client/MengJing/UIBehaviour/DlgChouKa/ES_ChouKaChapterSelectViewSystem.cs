using System;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_ChouKaChapterSelect))]
    [FriendOfAttribute(typeof (ES_ChouKaChapterSelect))]
    public static partial class ES_ChouKaChapterSelectSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ChouKaChapterSelect self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_CloseButton.AddListener(self.OnBtn_CloseButton);
            self.E_Btn_ZhangJie5Button.AddListener(() => { self.OnBtn_ZhangJie5(1005); });
            self.E_Btn_ZhangJie4Button.AddListener(() => { self.OnBtn_ZhangJie5(1004); });
            self.E_Btn_ZhangJie3Button.AddListener(() => { self.OnBtn_ZhangJie5(1003); });
            self.E_Btn_ZhangJie2Button.AddListener(() => { self.OnBtn_ZhangJie5(1002); });
            self.E_Btn_ZhangJie1Button.AddListener(() => { self.OnBtn_ZhangJie5(1001); });
        }

        [EntitySystem]
        private static void Destroy(this ES_ChouKaChapterSelect self)
        {
            self.DestroyWidget();
        }

        public static void SetClickHandler(this ES_ChouKaChapterSelect self, Action<int> action)
        {
            self.ClickHandler = action;
        }

        public static void OnBtn_ZhangJie5(this ES_ChouKaChapterSelect self, int chapterid)
        {
            int level = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;
            TakeCardConfig takeCardConfig = TakeCardConfigCategory.Instance.Get(chapterid);
            if (level < takeCardConfig.RoseLvLimit)
            {
                FlyTipComponent.Instance.ShowFlyTip("等级不足！");
                return;
            }

            self.ClickHandler(chapterid);
            self.uiTransform.gameObject.SetActive(false);
        }

        public static void OnBtn_CloseButton(this ES_ChouKaChapterSelect self)
        {
            self.uiTransform.gameObject.SetActive(false);
        }
    }
}
