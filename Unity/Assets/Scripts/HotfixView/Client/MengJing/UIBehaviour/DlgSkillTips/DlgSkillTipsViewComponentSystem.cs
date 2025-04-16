
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgSkillTipsViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgSkillTipsViewComponent))]
	public static partial class DlgSkillTipsViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgSkillTipsViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgSkillTipsViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
