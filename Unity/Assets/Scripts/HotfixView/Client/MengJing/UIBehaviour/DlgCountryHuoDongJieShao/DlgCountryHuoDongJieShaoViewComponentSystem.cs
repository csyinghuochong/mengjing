
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgCountryHuoDongJieShaoViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgCountryHuoDongJieShaoViewComponent))]
	public static partial class DlgCountryHuoDongJieShaoViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgCountryHuoDongJieShaoViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgCountryHuoDongJieShaoViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
