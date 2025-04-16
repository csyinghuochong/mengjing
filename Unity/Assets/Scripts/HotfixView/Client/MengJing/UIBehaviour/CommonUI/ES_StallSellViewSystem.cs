
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_StallSell))]
	[FriendOfAttribute(typeof(ES_StallSell))]
	public static partial class ES_StallSellSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_StallSell self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_StallSell self)
		{
			self.DestroyWidget();
		}
	}


}
