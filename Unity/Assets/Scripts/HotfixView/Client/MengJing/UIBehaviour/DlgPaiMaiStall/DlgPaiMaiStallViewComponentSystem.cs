
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPaiMaiStallViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPaiMaiStallViewComponent))]
	public static partial class DlgPaiMaiStallViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPaiMaiStallViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPaiMaiStallViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
