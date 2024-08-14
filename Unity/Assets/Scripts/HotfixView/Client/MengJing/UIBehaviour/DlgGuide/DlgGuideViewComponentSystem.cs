
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgGuideViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgGuideViewComponent))]
	public static partial class DlgGuideViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgGuideViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgGuideViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
