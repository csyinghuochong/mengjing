
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRoleXiLianNumRewardViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgRoleXiLianNumRewardViewComponent))]
	public static partial class DlgRoleXiLianNumRewardViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRoleXiLianNumRewardViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRoleXiLianNumRewardViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
