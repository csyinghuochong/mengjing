
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTowerFightRewardViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgTowerFightRewardViewComponent))]
	public static partial class DlgTowerFightRewardViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTowerFightRewardViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTowerFightRewardViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
