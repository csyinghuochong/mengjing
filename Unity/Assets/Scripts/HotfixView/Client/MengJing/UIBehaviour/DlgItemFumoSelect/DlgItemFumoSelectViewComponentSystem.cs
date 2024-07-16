
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgItemFumoSelectViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgItemFumoSelectViewComponent))]
	public static partial class DlgItemFumoSelectViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgItemFumoSelectViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgItemFumoSelectViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
