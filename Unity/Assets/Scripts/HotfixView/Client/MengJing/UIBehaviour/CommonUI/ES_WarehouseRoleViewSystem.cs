
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_WarehouseRole))]
	[FriendOfAttribute(typeof(ES_WarehouseRole))]
	public static partial class ES_WarehouseRoleSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_WarehouseRole self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_WarehouseRole self)
		{
			self.DestroyWidget();
		}
	}


}
