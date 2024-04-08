
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_ChengJiuJingling))]
	[FriendOfAttribute(typeof(ES_ChengJiuJingling))]
	public static partial class ES_ChengJiuJinglingSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_ChengJiuJingling self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_ChengJiuJingling self)
		{
			self.DestroyWidget();
		}
	}


}
