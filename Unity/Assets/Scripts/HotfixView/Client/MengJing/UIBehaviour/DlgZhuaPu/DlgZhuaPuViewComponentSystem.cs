
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgZhuaPuViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgZhuaPuViewComponent))]
	public static partial class DlgZhuaPuViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgZhuaPuViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgZhuaPuViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
