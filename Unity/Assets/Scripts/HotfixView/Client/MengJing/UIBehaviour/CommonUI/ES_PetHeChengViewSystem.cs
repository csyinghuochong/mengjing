
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_PetHeCheng))]
	[FriendOfAttribute(typeof(ES_PetHeCheng))]
	public static partial class ES_PetHeChengSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_PetHeCheng self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_PetHeCheng self)
		{
			self.DestroyWidget();
		}
	}


}
