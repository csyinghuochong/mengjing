
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_SkillTianFu))]
	[FriendOfAttribute(typeof(ES_SkillTianFu))]
	public static partial class ES_SkillTianFuSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_SkillTianFu self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_SkillTianFu self)
		{
			self.DestroyWidget();
		}
	}


}
