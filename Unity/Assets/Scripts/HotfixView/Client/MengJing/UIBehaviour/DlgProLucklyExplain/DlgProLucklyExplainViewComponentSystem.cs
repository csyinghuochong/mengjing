
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgProLucklyExplainViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgProLucklyExplainViewComponent))]
	public static partial class DlgProLucklyExplainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgProLucklyExplainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgProLucklyExplainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
