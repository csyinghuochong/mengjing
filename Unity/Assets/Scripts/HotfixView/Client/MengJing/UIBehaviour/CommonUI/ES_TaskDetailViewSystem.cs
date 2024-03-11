
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_TaskDetail))]
	[FriendOfAttribute(typeof(ES_TaskDetail))]
	public static partial class ES_TaskDetailSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_TaskDetail self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_TaskDetail self)
		{
			self.DestroyWidget();
		}
	}


}
