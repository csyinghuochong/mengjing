
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgCellChapterOpenViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgCellChapterOpenViewComponent))]
	public static partial class DlgCellChapterOpenViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgCellChapterOpenViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgCellChapterOpenViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
