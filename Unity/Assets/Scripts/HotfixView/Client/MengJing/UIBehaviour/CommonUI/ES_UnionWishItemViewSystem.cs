
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_UnionWishItem))]
	[FriendOfAttribute(typeof(ES_UnionWishItem))]
	public static partial class ES_UnionWishItemSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_UnionWishItem self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_UnionWishItem self)
		{
			self.DestroyWidget();
		}
	}


}
