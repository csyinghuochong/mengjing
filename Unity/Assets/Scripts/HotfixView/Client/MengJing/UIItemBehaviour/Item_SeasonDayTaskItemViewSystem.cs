
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_SeasonDayTaskItem))]
	public static partial class Scroll_Item_SeasonDayTaskItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_SeasonDayTaskItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_SeasonDayTaskItem self )
		{
			self.DestroyWidget();
		}
	}
}
