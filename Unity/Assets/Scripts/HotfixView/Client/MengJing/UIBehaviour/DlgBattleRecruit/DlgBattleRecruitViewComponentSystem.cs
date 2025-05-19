
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgBattleRecruitViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgBattleRecruitViewComponent))]
	public static partial class DlgBattleRecruitViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgBattleRecruitViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgBattleRecruitViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
