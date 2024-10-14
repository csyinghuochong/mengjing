
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_SettlementReward))]
	[FriendOfAttribute(typeof(ES_SettlementReward))]
	public static partial class ES_SettlementRewardSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_SettlementReward self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_SettlementReward self)
		{
			self.DestroyWidget();
		}
	}


}
