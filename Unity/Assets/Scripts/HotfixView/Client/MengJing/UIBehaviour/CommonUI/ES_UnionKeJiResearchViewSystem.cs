using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_UnionKeJiResearch))]
    [FriendOfAttribute(typeof (ES_UnionKeJiResearch))]
    public static partial class ES_UnionKeJiResearchSystem
    {
        [EntitySystem]
        private static void Awake(this ES_UnionKeJiResearch self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_UnionKeJiResearch self)
        {
            self.DestroyWidget();
        }
    }
}