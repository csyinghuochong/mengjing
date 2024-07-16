using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(Scroll_Item_PetQuickFightItem))]
    public static partial class Scroll_Item_PetQuickFightItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetQuickFightItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetQuickFightItem self)
        {
            self.DestroyWidget();
        }
    }
}