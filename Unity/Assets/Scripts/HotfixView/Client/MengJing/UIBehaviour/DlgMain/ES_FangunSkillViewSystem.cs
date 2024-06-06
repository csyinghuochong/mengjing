
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_FangunSkill))]
	[FriendOfAttribute(typeof(ES_FangunSkill))]
	public static partial class ES_FangunSkillSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_FangunSkill self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_FangunSkill self)
		{
			self.DestroyWidget();
		}
	}


}
