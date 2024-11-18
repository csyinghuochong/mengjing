
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_PetBarItem))]
	[FriendOfAttribute(typeof(ES_PetBarItem))]
	public static partial class ES_PetBarItemSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_PetBarItem self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_PetBarItem self)
		{
			self.DestroyWidget();
		}
	}


}
