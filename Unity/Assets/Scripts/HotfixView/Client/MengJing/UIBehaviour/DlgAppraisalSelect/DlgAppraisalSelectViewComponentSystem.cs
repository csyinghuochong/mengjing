
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgAppraisalSelectViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgAppraisalSelectViewComponent))]
	public static partial class DlgAppraisalSelectViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgAppraisalSelectViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgAppraisalSelectViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
