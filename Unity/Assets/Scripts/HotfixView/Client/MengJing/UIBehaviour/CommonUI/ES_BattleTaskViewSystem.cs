
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_BattleTask))]
	[FriendOfAttribute(typeof(ES_BattleTask))]
	public static partial class ES_BattleTaskSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_BattleTask self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_BattleTask self)
		{
			self.DestroyWidget();
		}
	}


}
