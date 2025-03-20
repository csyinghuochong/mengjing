
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_UnionWish))]
	[FriendOfAttribute(typeof(ES_UnionWish))]
	public static partial class ES_UnionWishSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_UnionWish self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_UnionWish self)
		{
			self.DestroyWidget();
		}
	}


}
