
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgChouKaViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgChouKaViewComponent))]
	public static partial class DlgChouKaViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgChouKaViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgChouKaViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
