
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_MailItem))]
	public static partial class Scroll_Item_MailItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_MailItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_MailItem self )
		{
			self.DestroyWidget();
		}
	}
}
