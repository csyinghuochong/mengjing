
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_UnionXiuLianItem))]
	[FriendOfAttribute(typeof(ES_UnionXiuLianItem))]
	public static partial class ES_UnionXiuLianItemSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_UnionXiuLianItem self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_UnionXiuLianItem self)
		{
			self.DestroyWidget();
		}
	}


}
