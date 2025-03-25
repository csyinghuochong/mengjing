
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_PetEchoSkillItem))]
	public static partial class Scroll_Item_PetEchoSkillItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_PetEchoSkillItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_PetEchoSkillItem self )
		{
			self.DestroyWidget();
		}
	}
}
