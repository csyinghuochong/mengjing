
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_Story))]
	[FriendOfAttribute(typeof(ES_Story))]
	public static partial class ES_StorySystem 
	{
		[EntitySystem]
		private static void Awake(this ES_Story self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_Story self)
		{
			self.DestroyWidget();
		}
	}


}
