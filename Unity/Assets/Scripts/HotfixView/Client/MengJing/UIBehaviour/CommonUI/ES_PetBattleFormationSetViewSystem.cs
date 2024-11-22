
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_PetBattleFormationSet))]
	[FriendOfAttribute(typeof(ES_PetBattleFormationSet))]
	public static partial class ES_PetBattleFormationSetSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_PetBattleFormationSet self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_PetBattleFormationSet self)
		{
			self.DestroyWidget();
		}
	}


}
