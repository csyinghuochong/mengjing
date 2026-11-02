
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_SockeRunetItem))]
	public static partial class Scroll_Item_SockeRunetItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_SockeRunetItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_SockeRunetItem self )
		{
			self.DestroyWidget();
		}
	}
}
