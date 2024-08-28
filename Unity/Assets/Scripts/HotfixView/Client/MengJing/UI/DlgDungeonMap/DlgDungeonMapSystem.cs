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
            self.View.E_Map0Button.AddListener(() => { self.Enlarge(self.View.E_Map0Button, 0); });
            self.View.E_Map1Button.AddListener(() => { self.Enlarge(self.View.E_Map1Button, 1); });
            self.View.E_Map2Button.AddListener(() => { self.Enlarge(self.View.E_Map2Button, 2); });
            self.View.E_Map3Button.AddListener(() => { self.Enlarge(self.View.E_Map3Button, 3); });
            self.View.E_Map4Button.AddListener(() => { self.Enlarge(self.View.E_Map4Button, 4); });
            self.View.E_Map5Button.AddListener(() => { self.Enlarge(self.View.E_Map5Button, 5); });
            self.View.E_Map6Button.AddListener(() => { self.Enlarge(self.View.E_Map6Button, 6); });
            self.View.E_Map7Button.AddListener(() => { self.Enlarge(self.View.E_Map7Button, 7); });
            self.View.E_Map8Button.AddListener(() => { self.Enlarge(self.View.E_Map8Button, 8); });

            self.View.E_CloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_DungeonMap); });
        }

        public static void ShowWindow(this DlgDungeonMap self, Entity contextData = null)
        {
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

        private static void Enlarge(this DlgDungeonMap self, Button clickedButton, int index)
        {
            self.EnableBtns(false);

            RectTransform rectTransform = self.View.E_MapPanelImage.GetComponent<RectTransform>();
            RectTransform buttonRectTransform = clickedButton.GetComponent<RectTransform>();

            Vector3 targetScale = Vector3.one * self.ScaleFactor;
            rectTransform.DOScale(targetScale, self.Duration).SetEase(Ease.OutBounce);

            Vector3 buttonLocalPosition = rectTransform.InverseTransformPoint(buttonRectTransform.position);
            Vector3 targetPosition = rectTransform.localPosition - buttonLocalPosition;
            rectTransform.DOLocalMove(targetPosition, self.Duration).SetEase(Ease.OutBounce).onComplete = () =>
            {
                List<DungeonSectionConfig> dungeonSectionConfigs = DungeonSectionConfigCategory.Instance.GetAll().Values.ToList();
                self.ShowLevel(dungeonSectionConfigs[index].Id).Coroutine();
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