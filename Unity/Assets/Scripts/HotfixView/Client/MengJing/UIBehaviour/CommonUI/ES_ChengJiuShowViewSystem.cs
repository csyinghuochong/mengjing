
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_ChengJiuShow))]
	[FriendOfAttribute(typeof(ES_ChengJiuShow))]
	public static partial class ES_ChengJiuShowSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_ChengJiuShow self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_ChengJiuShow self)
		{
			self.DestroyWidget();
		}
	}


}
