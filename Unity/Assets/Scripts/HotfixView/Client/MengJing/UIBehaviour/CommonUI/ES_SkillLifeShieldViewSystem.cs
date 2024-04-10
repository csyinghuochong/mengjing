
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_SkillLifeShield))]
	[FriendOfAttribute(typeof(ES_SkillLifeShield))]
	public static partial class ES_SkillLifeShieldSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_SkillLifeShield self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_SkillLifeShield self)
		{
			self.DestroyWidget();
		}
	}


}
