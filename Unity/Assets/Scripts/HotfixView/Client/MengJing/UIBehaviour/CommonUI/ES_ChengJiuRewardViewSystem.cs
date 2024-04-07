
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_ChengJiuReward))]
	[FriendOfAttribute(typeof(ES_ChengJiuReward))]
	public static partial class ES_ChengJiuRewardSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_ChengJiuReward self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_ChengJiuReward self)
		{
			self.DestroyWidget();
		}
	}


}
