
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_PetUpgradeItem))]
	[FriendOfAttribute(typeof(ES_PetUpgradeItem))]
	public static partial class ES_PetUpgradeItemSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_PetUpgradeItem self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_PetUpgradeItem self)
		{
			self.DestroyWidget();
		}
	}


}
