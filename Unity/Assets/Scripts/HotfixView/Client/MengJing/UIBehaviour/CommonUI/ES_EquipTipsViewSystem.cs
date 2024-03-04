
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_EquipTips))]
	[FriendOfAttribute(typeof(ES_EquipTips))]
	public static partial class ES_EquipTipsSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_EquipTips self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_EquipTips self)
		{
			self.DestroyWidget();
		}
	}


}
