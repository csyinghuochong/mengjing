
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgBuffTipsViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgBuffTipsViewComponent))]
	public static partial class DlgBuffTipsViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgBuffTipsViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgBuffTipsViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
