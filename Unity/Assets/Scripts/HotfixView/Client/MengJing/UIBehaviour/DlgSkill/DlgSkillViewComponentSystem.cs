namespace ET.Client
{
	[EntitySystemOf(typeof(DlgSkillViewComponent))]
	[FriendOfAttribute(typeof(DlgSkillViewComponent))]
	public static partial class DlgSkillViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgSkillViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgSkillViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
