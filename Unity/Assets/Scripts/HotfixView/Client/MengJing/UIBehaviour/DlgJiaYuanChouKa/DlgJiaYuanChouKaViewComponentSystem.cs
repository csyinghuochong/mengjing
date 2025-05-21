
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgJiaYuanChouKaViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgJiaYuanChouKaViewComponent))]
	public static partial class DlgJiaYuanChouKaViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgJiaYuanChouKaViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgJiaYuanChouKaViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
