
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgTrialViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgTrialViewComponent))]
	public static partial class DlgTrialViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgTrialViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgTrialViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
