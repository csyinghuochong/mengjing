
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgRolePetBagViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgRolePetBagViewComponent))]
	public static partial class DlgRolePetBagViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgRolePetBagViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgRolePetBagViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
