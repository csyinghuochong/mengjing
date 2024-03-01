
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgItemSellTipViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgItemSellTipViewComponent))]
	public static partial class DlgItemSellTipViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgItemSellTipViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgItemSellTipViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
