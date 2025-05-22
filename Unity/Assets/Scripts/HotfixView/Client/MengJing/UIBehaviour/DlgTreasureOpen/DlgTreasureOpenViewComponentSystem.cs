
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTreasureOpenViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgTreasureOpenViewComponent))]
	public static partial class DlgTreasureOpenViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTreasureOpenViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTreasureOpenViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
