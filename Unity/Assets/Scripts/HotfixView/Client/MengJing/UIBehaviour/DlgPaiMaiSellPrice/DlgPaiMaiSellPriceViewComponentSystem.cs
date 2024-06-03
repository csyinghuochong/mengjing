
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPaiMaiSellPriceViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPaiMaiSellPriceViewComponent))]
	public static partial class DlgPaiMaiSellPriceViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPaiMaiSellPriceViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPaiMaiSellPriceViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
