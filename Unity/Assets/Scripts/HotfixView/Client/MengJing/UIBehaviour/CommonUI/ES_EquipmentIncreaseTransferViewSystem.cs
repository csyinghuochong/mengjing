
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_EquipmentIncreaseTransfer))]
	[FriendOfAttribute(typeof(ES_EquipmentIncreaseTransfer))]
	public static partial class ES_EquipmentIncreaseTransferSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_EquipmentIncreaseTransfer self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_EquipmentIncreaseTransfer self)
		{
			self.DestroyWidget();
		}
	}


}
