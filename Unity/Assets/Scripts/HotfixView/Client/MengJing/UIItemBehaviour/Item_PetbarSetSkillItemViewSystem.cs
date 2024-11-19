using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetbarSetSkillItem))]
    [EntitySystemOf(typeof(Scroll_Item_PetbarSetSkillItem))]
    public static partial class Scroll_Item_PetbarSetSkillItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetbarSetSkillItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetbarSetSkillItem self)
        {
            self.DestroyWidget();
        }
    }
}