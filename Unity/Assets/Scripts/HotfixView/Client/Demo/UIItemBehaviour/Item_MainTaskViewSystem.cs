
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_MainTask))]
	public static partial class Scroll_Item_MainTaskSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_MainTask self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_MainTask self )
		{
			self.DestroyWidget();
		}
	}
}
