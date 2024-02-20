
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_CommonItem))]
	[FriendOfAttribute(typeof(ES_CommonItem))]
	public static partial class ES_CommonItemSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_CommonItem self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_CommonItem self)
		{
			self.DestroyWidget();
		}
	}


}
