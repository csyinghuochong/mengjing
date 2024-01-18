
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgCreateRoleViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgCreateRoleViewComponent))]
	public static partial class DlgCreateRoleViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgCreateRoleViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgCreateRoleViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
