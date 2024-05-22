using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_WatchEquip))]
    [FriendOfAttribute(typeof (ES_WatchEquip))]
    public static partial class ES_WatchEquipSystem
    {
        [EntitySystem]
        private static void Awake(this ES_WatchEquip self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_WatchEquip self)
        {
            self.DestroyWidget();
        }
    }
}