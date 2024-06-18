
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgSeasonTowerRewardViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgSeasonTowerRewardViewComponent))]
	public static partial class DlgSeasonTowerRewardViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgSeasonTowerRewardViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgSeasonTowerRewardViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
