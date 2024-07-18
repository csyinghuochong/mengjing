
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgJueXingViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgJueXingViewComponent))]
	public static partial class DlgJueXingViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgJueXingViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgJueXingViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
