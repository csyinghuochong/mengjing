namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_SelectRewardItem))]
	public static partial class Scroll_Item_SelectRewardItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_SelectRewardItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_SelectRewardItem self )
		{
			self.DestroyWidget();
		}
	}
}
