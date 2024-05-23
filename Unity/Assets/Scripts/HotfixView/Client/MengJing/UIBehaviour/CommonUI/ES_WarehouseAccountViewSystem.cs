
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_WarehouseAccount))]
	[FriendOfAttribute(typeof(ES_WarehouseAccount))]
	public static partial class ES_WarehouseAccountSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_WarehouseAccount self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_WarehouseAccount self)
		{
			self.DestroyWidget();
		}
	}


}
