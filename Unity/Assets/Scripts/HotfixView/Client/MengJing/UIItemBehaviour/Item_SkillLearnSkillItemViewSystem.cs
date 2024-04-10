
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_SkillLearnSkillItem))]
	public static partial class Scroll_Item_SkillLearnSkillItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_SkillLearnSkillItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_SkillLearnSkillItem self )
		{
			self.DestroyWidget();
		}
	}
}
