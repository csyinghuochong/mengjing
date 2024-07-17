using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof (DlgWatchPaiMaiViewComponent))]
    [FriendOf(typeof (DlgWatchPaiMai))]
    public static class DlgWatchPaiMaiSystem
    {
        public static void RegisterUIEvent(this DlgWatchPaiMai self)
        {
            self.View.E_ImageBgButton.AddListener(self.OnClickImageBg);
            self.View.E_FastSearchBtnButton.AddListener(self.OnFastSearchBtn);
            self.View.E_FastSearchBtnButton.gameObject.SetActive(false);
        }

        public static void ShowWindow(this DlgWatchPaiMai self, Entity contextData = null)
        {
        }

        public static void OnClickImageBg(this DlgWatchPaiMai self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_WatchPaiMai);
        }

        public static void OnFastSearchBtn(this DlgWatchPaiMai self)
        {
            self.searchAction.Invoke();
            self.OnClickImageBg();
        }

        public static void OnUpdateUI(this DlgWatchPaiMai self, Action action)
        {
            self.View.E_FastSearchBtnButton.gameObject.SetActive(true);
            self.searchAction = action;
            self.OnUpdateDi();
            self.OnUpdatePos();
        }

        public static void OnUpdateDi(this DlgWatchPaiMai self)
        {
            int number = 0;
            for (int i = 0; i < self.View.EG_PositionSetRectTransform.childCount; i++)
            {
                if (self.View.EG_PositionSetRectTransform.GetChild(i).gameObject.activeSelf)
                {
                    number++;
                }
            }

            self.View.E_ImageDiImage.GetComponent<RectTransform>().sizeDelta = new Vector2(220, number * 70f);
        }

        public static void OnUpdatePos(this DlgWatchPaiMai self)
        {
            Vector2 localPoint;
            RectTransform canvas = self.View.uiTransform.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, Input.mousePosition, uiCamera, out localPoint);
            self.View.EG_PositionSetRectTransform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);
            self.View.E_ImageDiImage.transform.localPosition = new Vector3(localPoint.x, localPoint.y, 0f);
            self.View.E_ImageDiImage.GetComponent<RectTransform>().sizeDelta = new Vector2(220, 0f);
        }
    }
}