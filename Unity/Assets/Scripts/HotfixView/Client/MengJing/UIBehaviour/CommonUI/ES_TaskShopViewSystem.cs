
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_TaskShop))]
	[FriendOfAttribute(typeof(ES_TaskShop))]
	public static partial class ES_TaskShopSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_TaskShop self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_TaskShop self)
		{
			self.DestroyWidget();
		}
	}


}
