
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_ActivitySingInVIP))]
	[FriendOfAttribute(typeof(ES_ActivitySingInVIP))]
	public static partial class ES_ActivitySingInVIPSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_ActivitySingInVIP self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_ActivitySingInVIP self)
		{
			self.DestroyWidget();
		}
	}


}
