using System;

namespace ET.Client
{
	[FriendOf(typeof(DlgRealName))]
	public static  class DlgRealNameSystem
	{

		public static void RegisterUIEvent(this DlgRealName self)
		{
			self.View.E_RealName_BtnButton.AddListenerAsync(self.OnRealName_Btn);
			self.View.E_Btn_Close.AddListener( self.OnBtn_Close );
			
			self.View.E_Btn_FangChenMiTip.AddListener(() =>
			{
				self.View.EG_FangChenMiTip.gameObject.SetActive(true);
			});
			
			self.View.E_Btn_ReadOk.AddListener(() =>
			{
				self.View.EG_FangChenMiTip.gameObject.SetActive(false);
			});
		}

		public static void OnMainScene(this DlgRealName self)
		{
			self.MapType = MapTypeEnum.MainCityScene;
			self.View.E_Btn_Close.gameObject.SetActive(false);
		}

		private static void OnBtn_Close(this DlgRealName self)
		{
			//self.Root().GetComponent<PlayerInfoComponent>().CheckRealName = false;
			self.Root().GetComponent<UIComponent>().CloseWindow( WindowID.WindowID_RealName );
		}

		public static void ShowWindow(this DlgRealName self, Entity contextData = null)
		{
			
			DlgMJLogin dlg =  self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMJLogin>();
			dlg?.HideLoadingView();
			
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

			
			if (self.MapType == MapTypeEnum.MainCityScene)
			{
				int errorCode = await LoginHelper.RealName_2(self.Root(), name, idcard);
            
				//实名认证成功再登陆。
				if (errorCode != ErrorCode.ERR_Success)
				{
					return;
				}

				FangChenMiComponentC fangChenMiComponentC = self.Root().GetComponent<FangChenMiComponentC>();
				if (fangChenMiComponentC.GetPlayerAge() < 18)
				{
					DateTime dateTime = TimeHelper.DateTimeNow();
					string minute = (60 - dateTime.Minute).ToString();
					string content = HintHelp.GetErrorHint(ErrorCode.ERR_FangChengMi_Tip1);
					content = content.Replace("{0}", minute);
					
					await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_FangChengMiTip);
					DlgFangChengMiTip dlgFangChengMiTip = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgFangChengMiTip>();
					dlgFangChengMiTip.InitData("防沉迷提示", content, null);
				}
				self.Root().GetComponent<FangChenMiComponentC>().OnLogin().Coroutine();
			}
			else
			{
				int errorCode = await LoginHelper.RealName(self.Root(), name, idcard);
					
				//实名认证成功再登陆。
				if (errorCode != ErrorCode.ERR_Success)
				{
					FlyTipComponent.Instance.ShowFlyTip("实名认证失败！");
					return;
				}

				PopupTipHelp.OpenPopupTip_2(self.Root(), "认证提示", "实名认证成功!", () =>
				{
					DlgMJLogin dlg =  self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgMJLogin>();
					dlg.OnLoginButton().Coroutine();
					
					self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_RealName);
				}).Coroutine();
			}
		}
	}
}
