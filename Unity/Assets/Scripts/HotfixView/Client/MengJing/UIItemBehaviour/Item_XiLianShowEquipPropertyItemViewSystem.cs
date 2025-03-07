
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_XiLianShowEquipPropertyItem))]
	public static partial class Scroll_Item_XiLianShowEquipPropertyItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_XiLianShowEquipPropertyItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_XiLianShowEquipPropertyItem self )
		{
			self.DestroyWidget();
		}
	}
}
