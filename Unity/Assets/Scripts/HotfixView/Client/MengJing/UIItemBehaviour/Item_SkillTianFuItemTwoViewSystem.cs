using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(Scroll_Item_SkillTianFuItemTwo))]
    public static partial class Scroll_Item_SkillTianFuItemTwoSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_SkillTianFuItemTwo self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_SkillTianFuItemTwo self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_SkillTianFuItemTwo self, int id)
        {
        }

        public static void Refresh(this Scroll_Item_SkillTianFuItemTwo self)
        {
        }
    }
}