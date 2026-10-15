
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_StoryItem))]
	public static partial class Scroll_Item_StoryItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_StoryItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_StoryItem self )
		{
			self.DestroyWidget();
		}
	}
}
