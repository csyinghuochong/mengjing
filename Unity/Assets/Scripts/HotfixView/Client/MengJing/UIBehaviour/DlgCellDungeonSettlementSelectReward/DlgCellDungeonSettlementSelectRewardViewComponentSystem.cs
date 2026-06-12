
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgCellDungeonSettlementSelectRewardViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgCellDungeonSettlementSelectRewardViewComponent))]
	public static partial class DlgCellDungeonSettlementSelectRewardViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgCellDungeonSettlementSelectRewardViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgCellDungeonSettlementSelectRewardViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
