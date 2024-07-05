
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_JiaYuanMystery_B))]
	[FriendOfAttribute(typeof(ES_JiaYuanMystery_B))]
	public static partial class ES_JiaYuanMystery_BSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_JiaYuanMystery_B self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_JiaYuanMystery_B self)
		{
			self.DestroyWidget();
		}
	}


}
