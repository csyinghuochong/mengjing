
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgActivityViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgActivityViewComponent))]
	public static partial class DlgActivityViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgActivityViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgActivityViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
