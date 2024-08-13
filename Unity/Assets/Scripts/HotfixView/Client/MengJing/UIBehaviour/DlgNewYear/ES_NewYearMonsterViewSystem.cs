using UnityEngine;

namespace ET.Client
{
	[EntitySystemOf(typeof(ES_NewYearMonster))]
	[FriendOfAttribute(typeof(ES_NewYearMonster))]
	public static partial class ES_NewYearMonsterSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_NewYearMonster self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_NewYearMonster self)
		{
			self.DestroyWidget();
		}
	}


}
