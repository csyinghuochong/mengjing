
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgBaoXiangRewardViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgBaoXiangRewardViewComponent))]
	public static partial class DlgBaoXiangRewardViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgBaoXiangRewardViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgBaoXiangRewardViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
