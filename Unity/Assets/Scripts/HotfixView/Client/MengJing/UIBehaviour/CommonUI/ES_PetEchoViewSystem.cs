
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_PetEcho))]
	[FriendOfAttribute(typeof(ES_PetEcho))]
	public static partial class ES_PetEchoSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_PetEcho self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_PetEcho self)
		{
			self.DestroyWidget();
		}
	}


}
