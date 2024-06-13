using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{

    [EntitySystemOf(typeof(ES_PetChallenge))]
    [FriendOfAttribute(typeof(ES_PetChallenge))]
    public static partial class ES_PetChallengeSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ES_PetChallenge self, UnityEngine.Transform transform)
        {
            self.uiTransform = transform;
        }
        
        [EntitySystem]
        private static void Destroy(this ET.Client.ES_PetChallenge self)
        {
            self.DestroyWidget();
        }

    }

}