
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(ES_SkillGrid))]
	[FriendOfAttribute(typeof(ES_SkillGrid))]
	public static partial class ES_SkillGridSystem 
	{
		[EntitySystem]
		private static void Awake(this ES_SkillGrid self,Transform transform)
		{
			self.uiTransform = transform;
		}

		[EntitySystem]
		private static void Destroy(this ES_SkillGrid self)
		{
			self.DestroyWidget();
		}
	}


}
