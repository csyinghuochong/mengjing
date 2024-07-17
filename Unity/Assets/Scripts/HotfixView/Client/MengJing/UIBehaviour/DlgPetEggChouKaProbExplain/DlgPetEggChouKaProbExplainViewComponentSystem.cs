namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetEggChouKaProbExplainViewComponent))]
	[FriendOfAttribute(typeof(DlgPetEggChouKaProbExplainViewComponent))]
	public static partial class DlgPetEggChouKaProbExplainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetEggChouKaProbExplainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetEggChouKaProbExplainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
