
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_RankItem))]
	public static partial class Scroll_Item_RankItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_RankItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_RankItem self )
		{
			self.DestroyWidget();
		}
	}
}
