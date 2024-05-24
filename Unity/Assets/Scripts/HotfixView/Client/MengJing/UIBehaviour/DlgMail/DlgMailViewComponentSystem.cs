
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgMailViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgMailViewComponent))]
	public static partial class DlgMailViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgMailViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgMailViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
