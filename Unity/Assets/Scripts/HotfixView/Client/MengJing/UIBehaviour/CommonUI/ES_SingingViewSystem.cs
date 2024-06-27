
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_Singing))]
	[FriendOfAttribute(typeof(ES_Singing))]
	public static partial class ES_SingingSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_Singing self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_Singing self)
		{
			self.DestroyWidget();
		}
	}


}
