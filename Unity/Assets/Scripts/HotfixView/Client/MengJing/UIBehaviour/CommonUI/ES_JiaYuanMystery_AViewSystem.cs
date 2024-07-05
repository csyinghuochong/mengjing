
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_JiaYuanMystery_A))]
	[FriendOfAttribute(typeof(ES_JiaYuanMystery_A))]
	public static partial class ES_JiaYuanMystery_ASystem 
	{
		[EntitySystem]
		private static void Awake(this ES_JiaYuanMystery_A self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_JiaYuanMystery_A self)
		{
			self.DestroyWidget();
		}
	}


}
