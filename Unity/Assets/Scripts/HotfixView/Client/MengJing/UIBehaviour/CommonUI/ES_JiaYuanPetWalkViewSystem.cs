
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_JiaYuanPetWalk))]
	[FriendOfAttribute(typeof(ES_JiaYuanPetWalk))]
	public static partial class ES_JiaYuanPetWalkSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_JiaYuanPetWalk self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_JiaYuanPetWalk self)
		{
			self.DestroyWidget();
		}
	}


}
