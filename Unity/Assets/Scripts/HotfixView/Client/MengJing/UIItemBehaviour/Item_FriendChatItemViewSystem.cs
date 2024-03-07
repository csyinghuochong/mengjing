
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[EntitySystemOf(typeof(Scroll_Item_FriendChatItem))]
	public static partial class Scroll_Item_FriendChatItemSystem 
	{
		[EntitySystem]
		private static void Awake(this Scroll_Item_FriendChatItem self )
		{
		}

		[EntitySystem]
		private static void Destroy(this Scroll_Item_FriendChatItem self )
		{
			self.DestroyWidget();
		}
	}
}
