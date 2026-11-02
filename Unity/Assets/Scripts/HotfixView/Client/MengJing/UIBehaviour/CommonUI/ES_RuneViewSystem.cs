using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_Rune))]
    [FriendOfAttribute(typeof(ES_Rune))]
    public static partial class ES_RuneSystem
    {
        [EntitySystem]
        private static void Awake(this ES_Rune self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_Rune self)
        {
            self.DestroyWidget();
        }
    }
}