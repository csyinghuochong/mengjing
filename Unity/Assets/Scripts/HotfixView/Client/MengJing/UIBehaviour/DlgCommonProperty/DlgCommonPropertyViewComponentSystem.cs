
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgCommonPropertyViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgCommonPropertyViewComponent))]
	public static partial class DlgCommonPropertyViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgCommonPropertyViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgCommonPropertyViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
