
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgShouJiSelectViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgShouJiSelectViewComponent))]
	public static partial class DlgShouJiSelectViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgShouJiSelectViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgShouJiSelectViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
