
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_RuneBagItem))]
	public static partial class Scroll_Item_RuneBagItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_RuneBagItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_RuneBagItem self )
		{
			self.DestroyWidget();
		}
	}
}
