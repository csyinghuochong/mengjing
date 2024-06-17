
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_SeasonTaskItem))]
	public static partial class Scroll_Item_SeasonTaskItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_SeasonTaskItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_SeasonTaskItem self )
		{
			self.DestroyWidget();
		}
	}
}
