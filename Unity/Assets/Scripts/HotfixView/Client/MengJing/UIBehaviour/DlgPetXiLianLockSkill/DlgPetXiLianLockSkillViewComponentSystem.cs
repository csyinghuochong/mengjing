
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetXiLianLockSkillViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetXiLianLockSkillViewComponent))]
	public static partial class DlgPetXiLianLockSkillViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetXiLianLockSkillViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetXiLianLockSkillViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
