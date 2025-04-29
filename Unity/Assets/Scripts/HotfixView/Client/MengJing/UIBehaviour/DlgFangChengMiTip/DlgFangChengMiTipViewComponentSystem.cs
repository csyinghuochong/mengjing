
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgFangChengMiTipViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgFangChengMiTipViewComponent))]
	public static partial class DlgFangChengMiTipViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgFangChengMiTipViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgFangChengMiTipViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
