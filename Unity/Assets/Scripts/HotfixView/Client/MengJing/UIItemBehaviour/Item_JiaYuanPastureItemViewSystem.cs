﻿
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_JiaYuanPastureItem))]
	public static partial class Scroll_Item_JiaYuanPastureItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_JiaYuanPastureItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_JiaYuanPastureItem self )
		{
			self.DestroyWidget();
		}
	}
}
