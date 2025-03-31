
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_SeasonBoss))]
	[FriendOfAttribute(typeof(ES_SeasonBoss))]
	public static partial class ES_SeasonBossSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_SeasonBoss self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_SeasonBoss self)
		{
			self.DestroyWidget();
		}


		public static async ETTask OnInitUI(this ES_SeasonBoss self)
		{
			A2C_CommonSeasonBossInfoResponse infoResponse = await ActivityNetHelper.GetCommonSeasonBossInfo(self.Root());

			await ETTask.CompletedTask;
		}

    }


}
