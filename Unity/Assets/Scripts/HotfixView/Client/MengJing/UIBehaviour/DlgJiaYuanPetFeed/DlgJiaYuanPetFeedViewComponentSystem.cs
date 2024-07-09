
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgJiaYuanPetFeedViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgJiaYuanPetFeedViewComponent))]
	public static partial class DlgJiaYuanPetFeedViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgJiaYuanPetFeedViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgJiaYuanPetFeedViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
