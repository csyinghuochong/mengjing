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

            self.AccountInF = rc.Get<GameObject>("AccountInF");
            self.PasswordInF = rc.Get<GameObject>("PasswordInF");
            self.EnterBtn = rc.Get<GameObject>("EnterBtn");

            self.EnterBtn.GetComponent<Button>().onClick.AddListener(() => { self.OnLogin().Coroutine(); });
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