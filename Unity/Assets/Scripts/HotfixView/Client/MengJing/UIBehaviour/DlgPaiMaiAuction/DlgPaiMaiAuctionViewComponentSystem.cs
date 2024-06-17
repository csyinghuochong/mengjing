
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPaiMaiAuctionViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPaiMaiAuctionViewComponent))]
	public static partial class DlgPaiMaiAuctionViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPaiMaiAuctionViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPaiMaiAuctionViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
