
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_StoryChoiceItem))]
	public static partial class Scroll_Item_StoryChoiceItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_StoryChoiceItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_StoryChoiceItem self )
		{
			self.DestroyWidget();
		}
	}
}
