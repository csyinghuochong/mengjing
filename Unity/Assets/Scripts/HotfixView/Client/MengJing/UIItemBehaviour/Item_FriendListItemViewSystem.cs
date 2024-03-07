using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (Scroll_Item_FriendListItem))]
    public static partial class Scroll_Item_FriendListItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_FriendListItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_FriendListItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_FriendListItem self, FriendInfo friendInfo)
        {
        }
    }
}