
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgSettingSkillViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgSettingSkillViewComponent))]
	public static partial class DlgSettingSkillViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgSettingSkillViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgSettingSkillViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
