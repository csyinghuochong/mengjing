using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(Scroll_Item_PetMeleeItem))]
    public static partial class Scroll_Item_PetMeleeItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetMeleeItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetMeleeItem self)
        {
            self.DestroyWidget();
        }
    }
}