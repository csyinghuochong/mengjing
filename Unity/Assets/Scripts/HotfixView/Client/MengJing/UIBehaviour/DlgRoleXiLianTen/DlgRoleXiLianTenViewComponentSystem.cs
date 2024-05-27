
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRoleXiLianTenViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgRoleXiLianTenViewComponent))]
	public static partial class DlgRoleXiLianTenViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRoleXiLianTenViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRoleXiLianTenViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
