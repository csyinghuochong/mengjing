
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRoleBagSplitViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgRoleBagSplitViewComponent))]
	public static partial class DlgRoleBagSplitViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRoleBagSplitViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRoleBagSplitViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
