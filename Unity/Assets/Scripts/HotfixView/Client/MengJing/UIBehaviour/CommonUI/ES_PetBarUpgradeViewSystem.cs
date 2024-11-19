using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_PetBarUpgrade))]
    [FriendOfAttribute(typeof(ES_PetBarUpgrade))]
    public static partial class ES_PetBarUpgradeSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetBarUpgrade self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_PetBarUpgrade self)
        {
            self.DestroyWidget();
        }
    }
}