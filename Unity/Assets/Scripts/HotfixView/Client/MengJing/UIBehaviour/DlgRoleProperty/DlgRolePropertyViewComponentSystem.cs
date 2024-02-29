
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRolePropertyViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgRolePropertyViewComponent))]
	public static partial class DlgRolePropertyViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRolePropertyViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRolePropertyViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
