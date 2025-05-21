
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPopupTipViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPopupTipViewComponent))]
	public static partial class DlgPopupTipViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPopupTipViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPopupTipViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
