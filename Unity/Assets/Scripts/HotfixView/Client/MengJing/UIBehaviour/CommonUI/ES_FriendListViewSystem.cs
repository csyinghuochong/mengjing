using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_FriendList))]
    [FriendOfAttribute(typeof (ES_FriendList))]
    public static partial class ES_FriendListSystem
    {
        [EntitySystem]
        private static void Awake(this ES_FriendList self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_FriendList self)
        {
            self.DestroyWidget();
        }
    }
}