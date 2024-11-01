
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(DlgEquipmentIncreaseViewComponent))]
	[FriendOfAttribute(typeof(ET.Client.DlgEquipmentIncreaseViewComponent))]
	public static partial class DlgEquipmentIncreaseViewComponentSystem
	{
		[EntitySystem]
		private static void Awake(this DlgEquipmentIncreaseViewComponent self)
		{
			self.uiTransform = self.Parent.GetParent<UIBaseWindow>().uiTransform;
		}


		[EntitySystem]
		private static void Destroy(this DlgEquipmentIncreaseViewComponent self)
		{
			self.DestroyWidget();
		}
	}


}
