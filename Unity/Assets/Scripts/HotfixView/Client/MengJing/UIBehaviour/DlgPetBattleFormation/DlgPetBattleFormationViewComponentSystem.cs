
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetBattleFormationViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetBattleFormationViewComponent))]
	public static partial class DlgPetBattleFormationViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetBattleFormationViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetBattleFormationViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
