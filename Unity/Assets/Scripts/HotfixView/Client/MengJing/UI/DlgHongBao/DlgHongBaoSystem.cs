namespace ET.Client
{
    [FriendOf(typeof(DlgHongBao))]
    public static class DlgHongBaoSystem
    {
        public static void RegisterUIEvent(this DlgHongBao self)
        {
            self.View.E_Button_OpenButton.AddListenerAsync(self.OnButton_OpenButton);
            self.View.E_Button_BackButton.AddListener(self.OnButton_BackButton);
        }

        public static void ShowWindow(this DlgHongBao self, Entity contextData = null)
        {
        }

        public static void OnButton_BackButton(this DlgHongBao self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_HongBao);
        }

        public static async ETTask OnButton_OpenButton(this DlgHongBao self)
        {
            M2C_HongBaoOpenResponse response = await ActivityNetHelper.HongBaoOpen(self.Root());

            self.View.EG_JiaGeSetRectTransform.gameObject.SetActive(true);
            self.View.E_Text_AmountText.text = response.HongbaoAmount.ToString();
            self.View.E_Button_OpenButton.gameObject.SetActive(false);
        }
    }
}