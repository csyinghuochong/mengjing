using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_NewYearCollectionWord))]
    [FriendOfAttribute(typeof (ES_NewYearCollectionWord))]
    public static partial class ES_NewYearCollectionWordSystem
    {
        [EntitySystem]
        private static void Awake(this ES_NewYearCollectionWord self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_NewYearCollectionWord self)
        {
            self.DestroyWidget();
        }
    }
}