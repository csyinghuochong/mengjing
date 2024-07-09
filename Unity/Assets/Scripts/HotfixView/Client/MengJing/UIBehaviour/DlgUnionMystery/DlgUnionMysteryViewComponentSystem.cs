
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgUnionMysteryViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgUnionMysteryViewComponent))]
	public static partial class DlgUnionMysteryViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgUnionMysteryViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgUnionMysteryViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
