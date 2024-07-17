namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_JiaYuanVisitItem))]
	public static partial class Scroll_Item_JiaYuanVisitItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_JiaYuanVisitItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_JiaYuanVisitItem self )
		{
			self.DestroyWidget();
		}
	}
}
