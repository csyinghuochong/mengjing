
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgChouKaRewardViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgChouKaRewardViewComponent))]
	public static partial class DlgChouKaRewardViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgChouKaRewardViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgChouKaRewardViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
