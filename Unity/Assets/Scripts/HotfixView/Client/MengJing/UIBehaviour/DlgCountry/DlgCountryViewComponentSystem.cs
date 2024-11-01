
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgCountryViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgCountryViewComponent))]
	public static partial class DlgCountryViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgCountryViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgCountryViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
