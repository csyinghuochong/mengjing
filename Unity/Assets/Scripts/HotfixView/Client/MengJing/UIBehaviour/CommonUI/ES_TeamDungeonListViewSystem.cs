
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_TeamDungeonList))]
	[FriendOfAttribute(typeof(ES_TeamDungeonList))]
	public static partial class ES_TeamDungeonListSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_TeamDungeonList self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_TeamDungeonList self)
		{
			self.DestroyWidget();
		}
	}


}
