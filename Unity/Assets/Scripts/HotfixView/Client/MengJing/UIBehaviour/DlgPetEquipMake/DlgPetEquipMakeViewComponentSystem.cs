
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgPetEquipMakeViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgPetEquipMakeViewComponent))]
	public static partial class DlgPetEquipMakeViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgPetEquipMakeViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgPetEquipMakeViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
