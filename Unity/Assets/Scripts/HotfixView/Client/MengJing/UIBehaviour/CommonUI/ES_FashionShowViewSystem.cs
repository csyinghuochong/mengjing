using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_FashionShow))]
    [FriendOfAttribute(typeof (ES_FashionShow))]
    public static partial class ES_FashionShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_FashionShow self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_FashionShow self)
        {
            self.DestroyWidget();
        }
    }
}