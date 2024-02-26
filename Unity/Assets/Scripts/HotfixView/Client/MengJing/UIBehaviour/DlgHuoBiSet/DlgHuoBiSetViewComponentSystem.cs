
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgHuoBiSetViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgHuoBiSetViewComponent))]
	public static partial class DlgHuoBiSetViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgHuoBiSetViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgHuoBiSetViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
