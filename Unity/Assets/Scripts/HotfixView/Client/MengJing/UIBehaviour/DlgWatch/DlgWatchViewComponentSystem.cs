
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgWatchViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgWatchViewComponent))]
	public static partial class DlgWatchViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgWatchViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgWatchViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
