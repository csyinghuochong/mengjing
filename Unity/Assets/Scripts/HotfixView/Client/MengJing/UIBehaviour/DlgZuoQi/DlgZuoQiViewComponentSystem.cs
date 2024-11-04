
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgZuoQiViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgZuoQiViewComponent))]
	public static partial class DlgZuoQiViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgZuoQiViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgZuoQiViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
