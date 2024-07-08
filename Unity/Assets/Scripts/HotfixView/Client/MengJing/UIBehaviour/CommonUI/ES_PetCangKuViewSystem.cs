
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_PetCangKu))]
	[FriendOfAttribute(typeof(ES_PetCangKu))]
	public static partial class ES_PetCangKuSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_PetCangKu self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_PetCangKu self)
		{
			self.DestroyWidget();
		}
	}


}
