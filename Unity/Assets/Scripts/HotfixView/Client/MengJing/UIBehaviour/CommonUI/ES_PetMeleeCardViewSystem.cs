
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_PetMeleeCard))]
	[FriendOfAttribute(typeof(ES_PetMeleeCard))]
	public static partial class ES_PetMeleeCardSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_PetMeleeCard self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_PetMeleeCard self)
		{
			self.DestroyWidget();
		}
	}


}
