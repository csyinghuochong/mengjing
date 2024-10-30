namespace ET.Client
{
    [FriendOf(typeof(DlgGM))]
    public static class DlgGMSystem
    {
        public static void RegisterUIEvent(this DlgGM self)
        {
            self.View.E_Button_Broadcast_1Button.AddListener(() => { self.OnButton_Broadcast_1(0).Coroutine(); });
            self.View.E_Button_Broadcast_2Button.AddListener(() => { self.OnButton_Broadcast_1(1).Coroutine(); });

            self.View.E_Button_EmailButton.AddListenerAsync(self.OnButton_EmailButton);
            self.View.E_Button_CloseButton.AddListener(self.OnButton_CloseButton);
            self.View.E_Button_ReLoadButton.AddListenerAsync(self.OnButton_ReLoadButton);
            self.View.E_Button_CommonButton.AddListenerAsync(self.OnButton_CommonButton);

            self.View.E_Text_OnLineNumberText.text = string.Empty;
            self.RequestGMInfo().Coroutine();
        }

        public static void ShowWindow(this DlgGM self, Entity contextData = null)
        {
        }

        /// <summary>
        /// boradType 0全服广播  1本服广播
        /// </summary>
        /// <param name="self"></param>
        /// <param name="boradType"></param>
        /// <returns></returns>
        public static async ETTask OnButton_Broadcast_1(this DlgGM self, int boradType)
        {
            if (self.View.E_InputField_BroadcastInputField.text.Length == 0)
            {
                return;
            }

            ChatInfo chatInfo = new();
            chatInfo.ChatMsg = self.View.E_InputField_BroadcastInputField.text;
            await ChatNetHelper.SendBroadcast(self.Root(), boradType, chatInfo);
        }

        public static async ETTask OnButton_EmailButton(this DlgGM self)
        {
            string itemlist = self.View.E_InputField_EmailItemInputField.text;
            if (string.IsNullOrEmpty(itemlist))
            {
                FlyTipComponent.Instance.ShowFlyTip("输入不能为空！");
                return;
            }

            E2C_GMEMailResponse response = await MailNetHelper.GMEMail(self.Root(), itemlist);
            if (response.Error == ErrorCode.ERR_Success)
            {
                FlyTipComponent.Instance.ShowFlyTip("邮件发送成功！");
            }
        }

        public static void OnButton_CloseButton(this DlgGM self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_GM);
        }

        public static async ETTask OnButton_CommonButton(this DlgGM self)
        {
            string content = self.View.E_InputField_CommonInputField.text;
            if (content.Length < 1)
            {
                return;
            }

            await UserInfoNetHelper.GMCommon(self.Root(), content);
        }

        public static async ETTask OnButton_ReLoadButton(this DlgGM self)
        {
            string reload = self.View.E_InputField_ReLoadValueInputField.text;
            if (reload.Length < 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("请输入热重载类型！");
                return;
            }
            
            await UserInfoNetHelper.GMCommon(self.Root(), reload);
        }

        public static async ETTask RequestGMInfo(this DlgGM self)
        {
            long instanceid = self.InstanceId;
            M2C_GM2InfoResponse response = await UserInfoNetHelper.GMInfo(self.Root());
            if (instanceid != self.InstanceId)
            {
                return;
            }

            if (response.Error == 0)
            {
                using (zstring.Block())
                {
                    self.View.E_Text_OnLineNumberText.text = zstring.Format("玩家:{0}机器人:{1}", response.OnLineNumber, response.OnLineRobot);
                }
            }
            else
            {
                self.OnButton_CloseButton();
            }
        }
    }
}