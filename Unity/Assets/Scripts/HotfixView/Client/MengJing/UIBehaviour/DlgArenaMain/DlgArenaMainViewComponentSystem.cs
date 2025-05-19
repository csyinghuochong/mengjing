
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgArenaMainViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgArenaMainViewComponent))]
	public static partial class DlgArenaMainViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgArenaMainViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgArenaMainViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
