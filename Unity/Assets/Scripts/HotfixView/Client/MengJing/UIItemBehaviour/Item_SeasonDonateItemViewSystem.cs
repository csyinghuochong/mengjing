
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_SeasonDonateItem))]
	public static partial class Scroll_Item_SeasonDonateItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_SeasonDonateItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_SeasonDonateItem self )
		{
			self.DestroyWidget();
		}
	}
}
