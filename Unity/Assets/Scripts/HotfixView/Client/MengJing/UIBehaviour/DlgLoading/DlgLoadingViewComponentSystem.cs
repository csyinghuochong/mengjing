
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgLoadingViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgLoadingViewComponent))]
	public static partial class DlgLoadingViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgLoadingViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgLoadingViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
