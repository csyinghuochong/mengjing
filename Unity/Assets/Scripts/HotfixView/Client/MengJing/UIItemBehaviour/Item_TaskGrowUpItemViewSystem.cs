
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_TaskGrowUpItem))]
	public static partial class Scroll_Item_TaskGrowUpItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_TaskGrowUpItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_TaskGrowUpItem self )
		{
			self.DestroyWidget();
		}
	}
}
