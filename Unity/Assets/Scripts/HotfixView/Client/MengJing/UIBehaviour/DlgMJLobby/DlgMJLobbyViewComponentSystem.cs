namespace ET.Client
{
	[EntitySystemOf(typeof(DlgMJLobbyViewComponent))]
	[FriendOfAttribute(typeof(DlgMJLobbyViewComponent))]
	public static partial class DlgMJLobbyViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgMJLobbyViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgMJLobbyViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
