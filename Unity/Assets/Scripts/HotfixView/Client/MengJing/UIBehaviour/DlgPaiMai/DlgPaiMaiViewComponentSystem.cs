
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPaiMaiViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPaiMaiViewComponent))]
	public static partial class DlgPaiMaiViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPaiMaiViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPaiMaiViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
