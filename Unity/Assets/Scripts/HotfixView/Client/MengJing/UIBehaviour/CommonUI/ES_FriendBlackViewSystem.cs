
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_FriendBlack))]
	[FriendOfAttribute(typeof(ES_FriendBlack))]
	public static partial class ES_FriendBlackSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_FriendBlack self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_FriendBlack self)
		{
			self.DestroyWidget();
		}
	}


}
