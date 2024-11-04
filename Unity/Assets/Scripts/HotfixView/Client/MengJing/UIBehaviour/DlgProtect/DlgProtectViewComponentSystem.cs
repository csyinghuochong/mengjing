
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgProtectViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgProtectViewComponent))]
	public static partial class DlgProtectViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgProtectViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgProtectViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
