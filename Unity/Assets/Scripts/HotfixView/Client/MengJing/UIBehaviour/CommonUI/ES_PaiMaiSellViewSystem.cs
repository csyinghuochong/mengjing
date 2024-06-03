using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_PaiMaiSell))]
    [FriendOfAttribute(typeof (ES_PaiMaiSell))]
    public static partial class ES_PaiMaiSellSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PaiMaiSell self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_PaiMaiSell self)
        {
            self.DestroyWidget();
        }
    }
}