using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_RankShow))]
    [FriendOfAttribute(typeof (ES_RankShow))]
    public static partial class ES_RankShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RankShow self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_RankShow self)
        {
            self.DestroyWidget();
        }
    }
}