
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_TaskType))]
	[FriendOfAttribute(typeof(ES_TaskType))]
	public static partial class ES_TaskTypeSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_TaskType self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_TaskType self)
		{
			self.DestroyWidget();
		}
	}


}
