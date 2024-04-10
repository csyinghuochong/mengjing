
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_SkillLearn))]
	[FriendOfAttribute(typeof(ES_SkillLearn))]
	public static partial class ES_SkillLearnSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_SkillLearn self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_SkillLearn self)
		{
			self.DestroyWidget();
		}
	}


}
