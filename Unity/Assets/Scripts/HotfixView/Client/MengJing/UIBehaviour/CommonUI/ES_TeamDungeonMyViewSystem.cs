
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_TeamDungeonMy))]
	[FriendOfAttribute(typeof(ES_TeamDungeonMy))]
	public static partial class ES_TeamDungeonMySystem 
	{
		[EntitySystem]
		private static void Awake(this ES_TeamDungeonMy self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_TeamDungeonMy self)
		{
			self.DestroyWidget();
		}
	}


}
