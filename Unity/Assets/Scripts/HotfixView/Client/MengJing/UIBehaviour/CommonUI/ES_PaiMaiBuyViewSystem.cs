
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_PaiMaiBuy))]
	[FriendOfAttribute(typeof(ES_PaiMaiBuy))]
	public static partial class ES_PaiMaiBuySystem 
	{
		[EntitySystem]
		private static void Awake(this ES_PaiMaiBuy self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_PaiMaiBuy self)
		{
			self.DestroyWidget();
		}
	}


}
