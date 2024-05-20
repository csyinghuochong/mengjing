
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRoleZodiacViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgRoleZodiacViewComponent))]
	public static partial class DlgRoleZodiacViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRoleZodiacViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRoleZodiacViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
