
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_FriendApply))]
	[FriendOfAttribute(typeof(ES_FriendApply))]
	public static partial class ES_FriendApplySystem 
	{
		[EntitySystem]
		private static void Awake(this ES_FriendApply self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_FriendApply self)
		{
			self.DestroyWidget();
		}
	}


}
