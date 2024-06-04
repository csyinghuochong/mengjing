
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_TrialRank))]
	[FriendOfAttribute(typeof(ES_TrialRank))]
	public static partial class ES_TrialRankSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_TrialRank self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_TrialRank self)
		{
			self.DestroyWidget();
		}
	}


}
