
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_RuneBag))]
	[FriendOfAttribute(typeof(ES_RuneBag))]
	public static partial class ES_RuneBagSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_RuneBag self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_RuneBag self)
		{
			self.DestroyWidget();
		}
	}


}
