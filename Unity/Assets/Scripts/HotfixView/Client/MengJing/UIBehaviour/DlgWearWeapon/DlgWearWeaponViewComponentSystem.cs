
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgWearWeaponViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgWearWeaponViewComponent))]
	public static partial class DlgWearWeaponViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgWearWeaponViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgWearWeaponViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
