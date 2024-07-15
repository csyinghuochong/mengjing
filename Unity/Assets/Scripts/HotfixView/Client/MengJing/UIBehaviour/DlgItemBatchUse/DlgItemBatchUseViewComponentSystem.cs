
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgItemBatchUseViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgItemBatchUseViewComponent))]
	public static partial class DlgItemBatchUseViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgItemBatchUseViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgItemBatchUseViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
