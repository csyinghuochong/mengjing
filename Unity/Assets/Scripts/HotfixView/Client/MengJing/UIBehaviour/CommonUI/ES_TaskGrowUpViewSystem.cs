
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_TaskGrowUp))]
	[FriendOfAttribute(typeof(ES_TaskGrowUp))]
	public static partial class ES_TaskGrowUpSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_TaskGrowUp self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_TaskGrowUp self)
		{
			self.DestroyWidget();
		}
	}


}
