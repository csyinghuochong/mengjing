using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_PetMining))]
    [FriendOfAttribute(typeof(ES_PetMining))]
    public static partial class ES_PetMiningSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ES_PetMining self, UnityEngine.Transform args2)
        {
            self.uiTransform = args2;
        }
        
        [EntitySystem]
        private static void Destroy(this ET.Client.ES_PetMining self)
        {
            self.DestroyWidget();
        }
    }

}