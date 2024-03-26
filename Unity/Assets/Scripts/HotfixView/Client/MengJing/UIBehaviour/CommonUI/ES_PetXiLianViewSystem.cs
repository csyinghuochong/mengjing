
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_PetXiLian))]
	[FriendOfAttribute(typeof(ES_PetXiLian))]
	public static partial class ES_PetXiLianSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_PetXiLian self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_PetXiLian self)
		{
			self.DestroyWidget();
		}
	}


}
