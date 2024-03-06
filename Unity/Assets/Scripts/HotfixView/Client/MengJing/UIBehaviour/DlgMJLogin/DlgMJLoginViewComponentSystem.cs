
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgMJLoginViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgMJLoginViewComponent))]
	public static partial class DlgMJLoginViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgMJLoginViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgMJLoginViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
