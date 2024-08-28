using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgDungeonMap))]
    public static class DlgDungeonMapSystem
    {
        public static void RegisterUIEvent(this DlgDungeonMap self)
        {
            self.View.E_Map0Button.AddListener(() => { self.Enlarge(self.View.E_Map0Button, 1); });
            self.View.E_Map1Button.AddListener(() => { self.Enlarge(self.View.E_Map1Button, 2); });
            self.View.E_Map2Button.AddListener(() => { self.Enlarge(self.View.E_Map2Button, 3); });
            self.View.E_Map3Button.AddListener(() => { self.Enlarge(self.View.E_Map3Button, 4); });
            self.View.E_Map4Button.AddListener(() => { self.Enlarge(self.View.E_Map4Button, 5); });
            self.View.E_Map5Button.AddListener(() => { self.Enlarge(self.View.E_Map5Button, 6); });
            self.View.E_Map6Button.AddListener(() => { self.Enlarge(self.View.E_Map6Button, 7); });
            self.View.E_Map7Button.AddListener(() => { self.Enlarge(self.View.E_Map7Button, 8); });
            self.View.E_Map8Button.AddListener(() => { self.Enlarge(self.View.E_Map8Button, 9); });

            self.View.E_CloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_DungeonMap); });
        }

        public static void ShowWindow(this DlgDungeonMap self, Entity contextData = null)
        {
            CommonViewHelper.SetImageGray(self.Root(), self.View.E_Map0Button.gameObject, !self.CanOpen(1));
            CommonViewHelper.SetImageGray(self.Root(), self.View.E_Map1Button.gameObject, !self.CanOpen(2));
            CommonViewHelper.SetImageGray(self.Root(), self.View.E_Map2Button.gameObject, !self.CanOpen(3));
            CommonViewHelper.SetImageGray(self.Root(), self.View.E_Map3Button.gameObject, !self.CanOpen(4));
            CommonViewHelper.SetImageGray(self.Root(), self.View.E_Map4Button.gameObject, !self.CanOpen(5));
            CommonViewHelper.SetImageGray(self.Root(), self.View.E_Map5Button.gameObject, !self.CanOpen(6));
            CommonViewHelper.SetImageGray(self.Root(), self.View.E_Map6Button.gameObject, !self.CanOpen(7));
            CommonViewHelper.SetImageGray(self.Root(), self.View.E_Map7Button.gameObject, !self.CanOpen(8));
            CommonViewHelper.SetImageGray(self.Root(), self.View.E_Map8Button.gameObject, !self.CanOpen(9));
        }

        public static void BeforeUnload(this DlgDungeonMap self)
        {
            self.View.E_MapPanelImage.GetComponent<RectTransform>().DOKill();
        }

        private static bool CanOpen(this DlgDungeonMap self, int chapterId)
        {
            if (!DungeonSectionConfigCategory.Instance.Contain(chapterId))
            {
                return false;
            }

            int selfLv = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv;

            int level = 100;
            int[] chapters = DungeonSectionConfigCategory.Instance.Get(chapterId).RandomArea;
            for (int i = 0; i < chapters.Length; i++)
            {
                DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(chapters[i]);
                if (dungeonConfig.EnterLv < level)
                {
                    level = dungeonConfig.EnterLv;
                }
            }

            return selfLv >= level;
        }

        private static void EnableBtns(this DlgDungeonMap self, bool enable)
        {
            self.View.E_Map0Button.enabled = enable;
            self.View.E_Map1Button.enabled = enable;
            self.View.E_Map2Button.enabled = enable;
            self.View.E_Map3Button.enabled = enable;
            self.View.E_Map4Button.enabled = enable;
            self.View.E_Map5Button.enabled = enable;
            self.View.E_Map6Button.enabled = enable;
            self.View.E_Map7Button.enabled = enable;
            self.View.E_Map8Button.enabled = enable;
        }

        private static void Enlarge(this DlgDungeonMap self, Button clickedButton, int chapterId)
        {
            self.EnableBtns(false);

            RectTransform rectTransform = self.View.E_MapPanelImage.GetComponent<RectTransform>();
            RectTransform buttonRectTransform = clickedButton.GetComponent<RectTransform>();

            Vector3 targetScale = Vector3.one * self.ScaleFactor;
            rectTransform.DOScale(targetScale, self.Duration).SetEase(Ease.Linear);

            Vector3 buttonLocalPosition = rectTransform.InverseTransformPoint(buttonRectTransform.position);
            Vector3 targetPosition = rectTransform.localPosition - buttonLocalPosition;
            rectTransform.DOLocalMove(targetPosition, self.Duration).SetEase(Ease.Linear).onComplete = () =>
            {
                if (self.CanOpen(chapterId))
                {
                    self.ShowLevel(chapterId).Coroutine();
                }
                else
                {
                    FlyTipComponent.Instance.ShowFlyTip("未开启");
                    self.ReEnlarge();
                }
            };
        }

        private static async ETTask ShowLevel(this DlgDungeonMap self, int chapterId)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_DungeonMapLevel);
            DlgDungeonMapLevel dlgDungeonMapLevel = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgDungeonMapLevel>();
            dlgDungeonMapLevel.Init(chapterId);
        }

        public static void ReEnlarge(this DlgDungeonMap self)
        {
            RectTransform rectTransform = self.View.E_MapPanelImage.GetComponent<RectTransform>();
            rectTransform.DOScale(Vector3.one, self.Duration).SetEase(Ease.Linear);

            rectTransform.DOLocalMove(Vector3.zero, self.Duration).SetEase(Ease.Linear).onComplete = () => { self.EnableBtns(true); };
        }
    }
}