
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgJiaYuanPetViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgJiaYuanPetViewComponent))]
	public static partial class DlgJiaYuanPetViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgJiaYuanPetViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgJiaYuanPetViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
