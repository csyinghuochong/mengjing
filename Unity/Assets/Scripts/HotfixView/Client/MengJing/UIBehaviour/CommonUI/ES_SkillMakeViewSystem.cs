
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_SkillMake))]
	[FriendOfAttribute(typeof(ES_SkillMake))]
	public static partial class ES_SkillMakeSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_SkillMake self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_SkillMake self)
		{
			self.DestroyWidget();
		}
	}


}
