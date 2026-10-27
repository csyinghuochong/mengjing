
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_GemTalent))]
	[FriendOfAttribute(typeof(ES_GemTalent))]
	public static partial class ES_GemTalentSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_GemTalent self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_GemTalent self)
		{
			self.DestroyWidget();
		}
	}


}
