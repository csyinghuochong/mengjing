
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_PetMeleeSet))]
	[FriendOfAttribute(typeof(ES_PetMeleeSet))]
	public static partial class ES_PetMeleeSetSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_PetMeleeSet self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_PetMeleeSet self)
		{
			self.DestroyWidget();
		}
	}


}
