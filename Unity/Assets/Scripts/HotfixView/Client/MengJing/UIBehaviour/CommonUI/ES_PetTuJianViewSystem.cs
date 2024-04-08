
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_PetTuJian))]
	[FriendOfAttribute(typeof(ES_PetTuJian))]
	public static partial class ES_PetTuJianSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_PetTuJian self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_PetTuJian self)
		{
			self.DestroyWidget();
		}
	}


}
