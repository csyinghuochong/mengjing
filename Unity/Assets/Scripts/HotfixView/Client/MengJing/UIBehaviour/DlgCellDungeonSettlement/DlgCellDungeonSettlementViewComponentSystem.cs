
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgCellDungeonSettlementViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgCellDungeonSettlementViewComponent))]
	public static partial class DlgCellDungeonSettlementViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgCellDungeonSettlementViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgCellDungeonSettlementViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
