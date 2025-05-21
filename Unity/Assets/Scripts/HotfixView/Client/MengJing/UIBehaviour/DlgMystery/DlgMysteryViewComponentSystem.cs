
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgMysteryViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgMysteryViewComponent))]
	public static partial class DlgMysteryViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgMysteryViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgMysteryViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
