using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (UI))]
    [FriendOf(typeof (UILoginComponent))]
    [EntitySystemOf(typeof (UILoginComponent))]
    public static partial class UILoginComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UILoginComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.UIAgeTip = rc.Get<GameObject>("UIAgeTip");
            self.AccountInF = rc.Get<GameObject>("AccountInF");
            self.PasswordInF = rc.Get<GameObject>("PasswordInF");
            self.EnterBtn = rc.Get<GameObject>("EnterBtn");

            self.UIAgeTip.SetActive(false);
            self.UIAgeTip.transform.Find("CloseBtn").GetComponent<Button>().onClick.AddListener(() => { self.OnCloseBtn_UIAgeTip(); });
            self.EnterBtn.GetComponent<Button>().onClick.AddListener(() => { self.OnLogin().Coroutine(); });
        }

        public static void OnCloseBtn_UIAgeTip(this UILoginComponent self)
        {
            self.UIAgeTip.SetActive(false);
        }

        public static async ETTask OnLogin(this UILoginComponent self)
        {
            await LoginHelper.Login(self.Root(),
                self.AccountInF.GetComponent<InputField>().text,
                self.PasswordInF.GetComponent<InputField>().text);
            await UIHelper.Create(self.Root(), UIType.UIMain);
            UIHelper.Remove(self.Root(), UIType.UILogin);
        }
    }
}