using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_PetBarSetItem))]
    [FriendOfAttribute(typeof(ES_PetBarSetItem))]
    public static partial class ES_PetBarSetItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetBarSetItem self, Transform transform)
        {
            self.uiTransform = transform;
            
        }

        [EntitySystem]
        private static void Destroy(this ES_PetBarSetItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInit(this ES_PetBarSetItem self, PetBarInfo petBarInfo)
        {
            self.PetBarInfo = petBarInfo;
        }
    }
}