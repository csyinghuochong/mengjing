
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_MapBigNpcItem))]
	public static partial class Scroll_Item_MapBigNpcItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_MapBigNpcItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_MapBigNpcItem self )
		{
			self.DestroyWidget();
		}
	}
}
