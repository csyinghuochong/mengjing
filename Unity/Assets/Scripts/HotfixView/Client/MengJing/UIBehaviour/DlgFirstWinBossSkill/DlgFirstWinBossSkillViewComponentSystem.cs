
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgFirstWinBossSkillViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgFirstWinBossSkillViewComponent))]
	public static partial class DlgFirstWinBossSkillViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgFirstWinBossSkillViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgFirstWinBossSkillViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
