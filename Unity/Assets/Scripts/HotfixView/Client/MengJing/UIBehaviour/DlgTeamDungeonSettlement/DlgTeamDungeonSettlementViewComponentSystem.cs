
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTeamDungeonSettlementViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgTeamDungeonSettlementViewComponent))]
	public static partial class DlgTeamDungeonSettlementViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTeamDungeonSettlementViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTeamDungeonSettlementViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
