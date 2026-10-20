
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_SkillLongYin))]
	[FriendOfAttribute(typeof(ES_SkillLongYin))]
	public static partial class ES_SkillLongYinSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_SkillLongYin self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_SkillLongYin self)
		{
			self.DestroyWidget();
		}
	}


}
