
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgHongBaoViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgHongBaoViewComponent))]
	public static partial class DlgHongBaoViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgHongBaoViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgHongBaoViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
