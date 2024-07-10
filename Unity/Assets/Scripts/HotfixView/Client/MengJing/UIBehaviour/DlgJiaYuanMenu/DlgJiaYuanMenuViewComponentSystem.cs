
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgJiaYuanMenuViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgJiaYuanMenuViewComponent))]
	public static partial class DlgJiaYuanMenuViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgJiaYuanMenuViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgJiaYuanMenuViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
