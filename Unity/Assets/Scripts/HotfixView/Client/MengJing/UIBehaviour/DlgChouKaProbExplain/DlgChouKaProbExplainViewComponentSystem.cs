
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgChouKaProbExplainViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgChouKaProbExplainViewComponent))]
	public static partial class DlgChouKaProbExplainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgChouKaProbExplainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgChouKaProbExplainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
