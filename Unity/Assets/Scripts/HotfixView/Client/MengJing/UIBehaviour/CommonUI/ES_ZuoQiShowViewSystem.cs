
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_ZuoQiShow))]
	[FriendOfAttribute(typeof(ES_ZuoQiShow))]
	public static partial class ES_ZuoQiShowSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_ZuoQiShow self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_ZuoQiShow self)
		{
			self.DestroyWidget();
		}
	}


}
