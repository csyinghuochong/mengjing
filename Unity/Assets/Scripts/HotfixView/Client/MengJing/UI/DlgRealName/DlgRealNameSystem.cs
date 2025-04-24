namespace ET.Client
{
	[FriendOf(typeof(DlgRealName))]
	public static  class DlgRealNameSystem
	{

		public static void RegisterUIEvent(this DlgRealName self)
		{
			self.View.E_RealName_BtnButton.AddListenerAsync(self.OnRealName_Btn);
		}

		public static void ShowWindow(this DlgRealName self, Entity contextData = null)
		{
			
			DlgMJLogin dlg =  self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMJLogin>();
			dlg.HideLoadingView();
			
		}

		public static async ETTask OnRealName_Btn(this DlgRealName self)
		{
			string name = self.View.E_InputFieldNameInputField.text;
			string idcard =  self.View.E_InputFieldIDCardInputField.text;

			if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(idcard))
			{
				return;
			}

			if (name.Length >100 || idcard.Length > 100)
			{
				return;
			}

			int errorCode = await LoginHelper.RealName(self.Root(), name, idcard);
            
			//实名认证成功再登陆。
			if (errorCode != ErrorCode.ERR_Success)
			{
				return;
			}
			
			DlgMJLogin dlg =  self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMJLogin>();
			dlg.OnLoginButton().Coroutine();

			self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RealName);
		}

	}
}
