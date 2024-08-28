using System.Collections;
using System.Collections.Generic;
using System;
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
            self.View.E_Map0Button.AddListener(() => { self.Enlarge(self.View.E_Map0Button); });
            self.View.E_Map1Button.AddListener(() => { self.Enlarge(self.View.E_Map1Button); });
            self.View.E_Map2Button.AddListener(() => { self.Enlarge(self.View.E_Map2Button); });
            self.View.E_Map3Button.AddListener(() => { self.Enlarge(self.View.E_Map3Button); });
            self.View.E_Map4Button.AddListener(() => { self.Enlarge(self.View.E_Map4Button); });
            self.View.E_Map5Button.AddListener(() => { self.Enlarge(self.View.E_Map5Button); });
            self.View.E_Map6Button.AddListener(() => { self.Enlarge(self.View.E_Map6Button); });
            self.View.E_Map7Button.AddListener(() => { self.Enlarge(self.View.E_Map7Button); });
            self.View.E_Map8Button.AddListener(() => { self.Enlarge(self.View.E_Map8Button); });

            self.View.E_CloseButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_DungeonMap); });
            self.View.E_ReturnButton.AddListener(self.OnReturnButtonClick);
        }

        public static void ShowWindow(this DlgDungeonMap self, Entity contextData = null)
        {
            self.View.EG_LevelPanelRectTransform.gameObject.SetActive(false);
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

        private static void Enlarge(this DlgDungeonMap self, Button clickedButton)
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
                self.View.EG_LevelPanelRectTransform.gameObject.SetActive(true);
            };
        }

        private static void ReEnlarge(this DlgDungeonMap self)
        {
            RectTransform rectTransform = self.View.E_MapPanelImage.GetComponent<RectTransform>();
            rectTransform.DOScale(Vector3.one, self.Duration).SetEase(Ease.Linear);

            rectTransform.DOLocalMove(Vector3.zero, self.Duration).SetEase(Ease.Linear);

            self.EnableBtns(true);
        }

        private static void OnReturnButtonClick(this DlgDungeonMap self)
        {
            self.View.EG_LevelPanelRectTransform.gameObject.SetActive(false);

            self.ReEnlarge();
        }
    }
}