
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRoleXiLianExplainViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgRoleXiLianExplainViewComponent))]
	public static partial class DlgRoleXiLianExplainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRoleXiLianExplainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRoleXiLianExplainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
