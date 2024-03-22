
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_CostList))]
	[FriendOfAttribute(typeof(ES_CostList))]
	public static partial class ES_CostListSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_CostList self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_CostList self)
		{
			self.DestroyWidget();
		}
	}


}
