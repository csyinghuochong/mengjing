
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgChatViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgChatViewComponent))]
	public static partial class DlgChatViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgChatViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgChatViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
