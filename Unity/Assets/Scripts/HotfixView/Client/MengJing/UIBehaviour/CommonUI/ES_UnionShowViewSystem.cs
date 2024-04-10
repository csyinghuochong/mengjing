
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_UnionShow))]
	[FriendOfAttribute(typeof(ES_UnionShow))]
	public static partial class ES_UnionShowSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_UnionShow self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_UnionShow self)
		{
			self.DestroyWidget();
		}
	}


}
