
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRechargeViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgRechargeViewComponent))]
	public static partial class DlgRechargeViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRechargeViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRechargeViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
