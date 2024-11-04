
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgWelfareViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgWelfareViewComponent))]
	public static partial class DlgWelfareViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgWelfareViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgWelfareViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
