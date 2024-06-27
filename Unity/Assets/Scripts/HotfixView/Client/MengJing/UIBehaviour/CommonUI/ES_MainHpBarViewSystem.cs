using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_MainHpBar))]
    [FriendOfAttribute(typeof (ES_MainHpBar))]
    public static partial class ES_MainHpBarSystem
    {
        [EntitySystem]
        private static void Awake(this ES_MainHpBar self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_MainHpBar self)
        {
            self.DestroyWidget();
        }
    }
}