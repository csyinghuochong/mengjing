
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgWeiJingShopViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgWeiJingShopViewComponent))]
	public static partial class DlgWeiJingShopViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgWeiJingShopViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgWeiJingShopViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
