
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgCellChapterSelectViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgCellChapterSelectViewComponent))]
	public static partial class DlgCellChapterSelectViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgCellChapterSelectViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgCellChapterSelectViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
