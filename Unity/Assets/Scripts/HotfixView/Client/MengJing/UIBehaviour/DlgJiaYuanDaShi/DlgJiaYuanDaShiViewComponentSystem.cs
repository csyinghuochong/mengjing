
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgJiaYuanDaShiViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgJiaYuanDaShiViewComponent))]
	public static partial class DlgJiaYuanDaShiViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgJiaYuanDaShiViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgJiaYuanDaShiViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
