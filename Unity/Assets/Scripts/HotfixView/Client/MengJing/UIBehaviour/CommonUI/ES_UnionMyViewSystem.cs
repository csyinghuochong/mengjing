
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_UnionMy))]
	[FriendOfAttribute(typeof(ES_UnionMy))]
	public static partial class ES_UnionMySystem 
	{
		[EntitySystem]
		private static void Awake(this ES_UnionMy self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_UnionMy self)
		{
			self.DestroyWidget();
		}
	}


}
