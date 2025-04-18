
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPaiMaiStallBuyViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPaiMaiStallBuyViewComponent))]
	public static partial class DlgPaiMaiStallBuyViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPaiMaiStallBuyViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPaiMaiStallBuyViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
