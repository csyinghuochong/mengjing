
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_ActivitySingleRecharge))]
	[FriendOfAttribute(typeof(ES_ActivitySingleRecharge))]
	public static partial class ES_ActivitySingleRechargeSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_ActivitySingleRecharge self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_ActivitySingleRecharge self)
		{
			self.DestroyWidget();
		}
	}


}
