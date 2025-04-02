
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_PetMatch))]
	[FriendOfAttribute(typeof(ES_PetMatch))]
	public static partial class ES_PetMatchSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_PetMatch self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_PetMatch self)
		{
			self.DestroyWidget();
		}
	}


}
