﻿namespace ET.Client
{
	[FriendOf(typeof(DlgLSLogin))]
	public static  class DlgLSLoginSystem
	{

		public static void RegisterUIEvent(this DlgLSLogin self)
		{
			self.View.ELoginBtnButton.AddListener(self.OnLogin);
					
		}

		public static void ShowWindow(this DlgLSLogin self, Entity contextData = null)
		{
		}

		 
		public static void OnLogin(this DlgLSLogin self)
		{
			
		}
	}
}
