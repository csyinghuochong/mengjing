using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_RoleXiLianShow))]
    [FriendOfAttribute(typeof (ES_RoleXiLianShow))]
    public static partial class ES_RoleXiLianShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleXiLianShow self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleXiLianShow self)
        {
            self.DestroyWidget();
        }
    }
}