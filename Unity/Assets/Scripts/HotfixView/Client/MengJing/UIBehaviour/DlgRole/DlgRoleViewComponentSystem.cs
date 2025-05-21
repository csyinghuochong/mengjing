
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRoleViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgRoleViewComponent))]
	public static partial class DlgRoleViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRoleViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRoleViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
