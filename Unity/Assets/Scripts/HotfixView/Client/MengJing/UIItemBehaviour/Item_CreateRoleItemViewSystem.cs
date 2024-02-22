using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (Scroll_Item_CreateRoleItem))]
    public static partial class Scroll_Item_CreateRoleItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_CreateRoleItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_CreateRoleItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_CreateRoleItem self, CreateRoleInfo createRoleInfo)
        {
        }
    }
}