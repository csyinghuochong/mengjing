
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_PetBarSet))]
	[FriendOfAttribute(typeof(ES_PetBarSet))]
	public static partial class ES_PetBarSetSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_PetBarSet self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_PetBarSet self)
		{
			self.DestroyWidget();
		}
	}


}
