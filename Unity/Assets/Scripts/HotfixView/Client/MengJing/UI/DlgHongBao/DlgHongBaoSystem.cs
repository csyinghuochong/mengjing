using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgHongBao))]
    public static class DlgHongBaoSystem
    {
        public static void RegisterUIEvent(this DlgHongBao self)
        {
            self.View.E_Button_OpenButton.AddListenerAsync(self.OnButton_Open);
            self.View.E_Button_BackButton.AddListener(() => { self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_HongBao); });
        }

        public static void ShowWindow(this DlgHongBao self, Entity contextData = null)
        {
        }

        public static async ETTask OnButton_Open(this DlgHongBao self)
        {
            M2C_HongBaoOpenResponse response = await ActivityNetHelper.HongBaoOpen(self.Root());

            self.View.EG_JiaGeSetRectTransform.gameObject.SetActive(true);
            self.View.E_Text_AmountText.text = response.HongbaoAmount.ToString();
            self.View.E_Button_OpenButton.gameObject.SetActive(false);
        }
    }
}