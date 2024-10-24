﻿namespace ET.Client
{
	[FriendOf(typeof(DlgLobby))]
	public static  class DlgLobbySystem
	{

		public static void RegisterUIEvent(this DlgLobby self)
		{
			self.View.E_EnterMapButton.AddListenerAsync(self.EnterMap);
		}

		public static void ShowWindow(this DlgLobby self, Entity contextData = null)
		{
		}

		public static async ETTask EnterMap(this DlgLobby self)
		{
			Scene root = self.Root();
			await LoginHelper.LoginGameAsync(root, 0);
			root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Lobby);
		}

	}
}
