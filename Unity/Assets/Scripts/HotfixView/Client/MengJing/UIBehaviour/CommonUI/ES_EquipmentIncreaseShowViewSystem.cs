using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_EquipmentIncreaseShow))]
    [FriendOfAttribute(typeof(ES_EquipmentIncreaseShow))]
    public static partial class ES_EquipmentIncreaseShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_EquipmentIncreaseShow self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_EquipmentIncreaseShow self)
        {
            self.DestroyWidget();
        }
    }
}