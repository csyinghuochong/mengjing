
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_ChatView))]
	[FriendOfAttribute(typeof(ES_ChatView))]
	public static partial class ES_ChatViewSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_ChatView self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_ChatView self)
		{
			self.DestroyWidget();
		}
	}


}
