using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (DlgCountryHuoDongJieShao))]
    public static class DlgCountryHuoDongJieShaoSystem
    {
        public static void RegisterUIEvent(this DlgCountryHuoDongJieShao self)
        {
            self.View.E_BtnCloseButton.AddListener(self.OnBtn_Close);
        }

        public static void ShowWindow(this DlgCountryHuoDongJieShao self, Entity contextData = null)
        {
        }

        public static void OnBtn_Close(this DlgCountryHuoDongJieShao self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_CountryHuoDongJieShao);
        }

        public static void OnUpdateJieShao(this DlgCountryHuoDongJieShao self, string title, string jieshao)
        {
            self.View.E_TextTitleText.text = title;
            self.View.E_TextJieShaoText.text = jieshao;
        }
    }
}