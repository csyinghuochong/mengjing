
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgDragonDungeonSettlementViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgDragonDungeonSettlementViewComponent))]
	public static partial class DlgDragonDungeonSettlementViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgDragonDungeonSettlementViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgDragonDungeonSettlementViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
