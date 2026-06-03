
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_LevelPack))]
	[FriendOfAttribute(typeof(ES_LevelPack))]
	public static partial class ES_LevelPackSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_LevelPack self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_LevelPack self)
		{
			self.DestroyWidget();
		}
	}


}
