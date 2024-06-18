
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_ActivityToken))]
	[FriendOfAttribute(typeof(ES_ActivityToken))]
	public static partial class ES_ActivityTokenSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_ActivityToken self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_ActivityToken self)
		{
			self.DestroyWidget();
		}
	}


}
