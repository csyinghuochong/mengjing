
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgBattleMainViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgBattleMainViewComponent))]
	public static partial class DlgBattleMainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgBattleMainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgBattleMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
