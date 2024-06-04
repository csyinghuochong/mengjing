
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_TrialDungeon))]
	[FriendOfAttribute(typeof(ES_TrialDungeon))]
	public static partial class ES_TrialDungeonSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_TrialDungeon self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_TrialDungeon self)
		{
			self.DestroyWidget();
		}
	}


}
