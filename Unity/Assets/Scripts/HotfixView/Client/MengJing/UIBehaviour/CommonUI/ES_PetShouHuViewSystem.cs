
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_PetShouHu))]
	[FriendOfAttribute(typeof(ES_PetShouHu))]
	public static partial class ES_PetShouHuSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_PetShouHu self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_PetShouHu self)
		{
			self.DestroyWidget();
		}
	}


}
