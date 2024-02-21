using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_ModelShow))]
    [FriendOf(typeof (ES_ModelShow))]
    public static partial class ES_ModelShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ModelShow self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_ModelShow self)
        {
            self.DestroyWidget();
        }
    }
}