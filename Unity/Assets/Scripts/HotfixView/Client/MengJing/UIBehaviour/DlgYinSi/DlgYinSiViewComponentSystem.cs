
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgYinSiViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgYinSiViewComponent))]
	public static partial class DlgYinSiViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgYinSiViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgYinSiViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
