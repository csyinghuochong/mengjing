
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_SeasonTask))]
	[FriendOfAttribute(typeof(ES_SeasonTask))]
	public static partial class ES_SeasonTaskSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_SeasonTask self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_SeasonTask self)
		{
			self.DestroyWidget();
		}
	}


}
