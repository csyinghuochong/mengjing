
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgSettingViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgSettingViewComponent))]
	public static partial class DlgSettingViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgSettingViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgSettingViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
