
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgOccTwoShowViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgOccTwoShowViewComponent))]
	public static partial class DlgOccTwoShowViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgOccTwoShowViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgOccTwoShowViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
