using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_JiaYuanCooking))]
    [FriendOfAttribute(typeof (ES_JiaYuanCooking))]
    public static partial class ES_JiaYuanCookingSystem
    {
        [EntitySystem]
        private static void Awake(this ES_JiaYuanCooking self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_JiaYuanCooking self)
        {
            self.DestroyWidget();
        }
    }
}