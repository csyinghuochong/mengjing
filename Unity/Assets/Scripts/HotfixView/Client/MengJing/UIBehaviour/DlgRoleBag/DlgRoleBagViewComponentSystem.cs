
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRoleBagViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgRoleBagViewComponent))]
	public static partial class DlgRoleBagViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRoleBagViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRoleBagViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
