
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_TowerDungeon))]
	[FriendOfAttribute(typeof(ES_TowerDungeon))]
	public static partial class ES_TowerDungeonSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_TowerDungeon self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_TowerDungeon self)
		{
			self.DestroyWidget();
		}
	}


}
