
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgZhanQuViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgZhanQuViewComponent))]
	public static partial class DlgZhanQuViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgZhanQuViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgZhanQuViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
