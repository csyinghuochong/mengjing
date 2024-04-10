
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_SkillLearnItem))]
	public static partial class Scroll_Item_SkillLearnItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_SkillLearnItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_SkillLearnItem self )
		{
			self.DestroyWidget();
		}
	}
}
