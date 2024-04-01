using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_PetInfoShow))]
    [FriendOfAttribute(typeof (ES_PetInfoShow))]
    public static partial class ES_PetInfoShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetInfoShow self, Transform transform)
        {
            self.uiTransform = transform;
        }

        [EntitySystem]
        private static void Destroy(this ES_PetInfoShow self)
        {
            self.DestroyWidget();
        }
    }
}