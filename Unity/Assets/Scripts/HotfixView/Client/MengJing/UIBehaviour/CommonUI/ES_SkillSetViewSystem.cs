
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_SkillSet))]
	[FriendOfAttribute(typeof(ES_SkillSet))]
	public static partial class ES_SkillSetSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_SkillSet self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_SkillSet self)
		{
			self.DestroyWidget();
		}
	}


}
