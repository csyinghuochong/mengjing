﻿namespace ET.Client
{
	[EntitySystemOf(typeof(DlgLobbyViewComponent))]
	[FriendOfAttribute(typeof(DlgLobbyViewComponent))]
	public static partial class DlgLobbyViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgLobbyViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgLobbyViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
