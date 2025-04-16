
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgStallSellPriceViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgStallSellPriceViewComponent))]
	public static partial class DlgStallSellPriceViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgStallSellPriceViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgStallSellPriceViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
