
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_TeamDungeonShop))]
	[FriendOfAttribute(typeof(ES_TeamDungeonShop))]
	public static partial class ES_TeamDungeonShopSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_TeamDungeonShop self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_TeamDungeonShop self)
		{
			self.DestroyWidget();
		}
	}


}
