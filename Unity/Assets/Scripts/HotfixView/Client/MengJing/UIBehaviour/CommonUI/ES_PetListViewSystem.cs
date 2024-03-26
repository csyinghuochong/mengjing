
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_PetList))]
	[FriendOfAttribute(typeof(ES_PetList))]
	public static partial class ES_PetListSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_PetList self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_PetList self)
		{
			self.DestroyWidget();
		}
	}


}
