namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_LobbyRole))]
	public static partial class Scroll_Item_LobbyRoleSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_LobbyRole self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_LobbyRole self )
		{
			self.DestroyWidget();
		}
	}
}
