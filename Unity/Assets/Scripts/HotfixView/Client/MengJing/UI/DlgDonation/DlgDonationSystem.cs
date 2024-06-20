using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (ES_DonationShow))]
    [FriendOf(typeof (ES_DonationUnion))]
    [FriendOf(typeof (DlgDonation))]
    public static class DlgDonationSystem
    {
        public static void RegisterUIEvent(this DlgDonation self)
        {
            self.View.E_FunctionSetBtnToggleGroup.AddListener(self.OnFunctionSetBtn);
        }

        public static void ShowWindow(this DlgDonation self, Entity contextData = null)
        {
            self.View.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
        }

        private static void OnFunctionSetBtn(this DlgDonation self, int index)
        {
            UICommonHelper.HideChildren(self.View.EG_SubViewRectTransform);
            switch (index)
            {
                case 0:
                    self.View.ES_DonationShow.uiTransform.gameObject.SetActive(true);
                    break;
                case 1:
                    self.View.ES_DonationUnion.uiTransform.gameObject.SetActive(true);
                    break;
                case 2:
                    break;
            }
        }
    }
}