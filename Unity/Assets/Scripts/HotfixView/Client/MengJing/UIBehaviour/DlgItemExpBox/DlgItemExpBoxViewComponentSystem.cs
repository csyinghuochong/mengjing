
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgItemExpBoxViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgItemExpBoxViewComponent))]
	public static partial class DlgItemExpBoxViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgItemExpBoxViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgItemExpBoxViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
