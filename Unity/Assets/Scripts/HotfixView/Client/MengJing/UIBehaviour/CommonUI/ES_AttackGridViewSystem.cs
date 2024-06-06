
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_AttackGrid))]
	[FriendOfAttribute(typeof(ES_AttackGrid))]
	public static partial class ES_AttackGridSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_AttackGrid self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_AttackGrid self)
		{
			self.DestroyWidget();
		}
	}


}
