
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_WarehouseGem))]
	[FriendOfAttribute(typeof(ES_WarehouseGem))]
	public static partial class ES_WarehouseGemSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_WarehouseGem self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_WarehouseGem self)
		{
			self.DestroyWidget();
		}
	}


}
