using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{


    [FriendOf(typeof(Scroll_Item_PetChallengeItem))]
    [EntitySystemOf(typeof(Scroll_Item_PetChallengeItem))]
    public static partial class Scroll_Item_PetChallengeItemSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.Scroll_Item_PetChallengeItem self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Client.Scroll_Item_PetChallengeItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this Scroll_Item_PetChallengeItem self, PetFubenConfig activityConfig)
        {
            
            
        }
        
        public static void SetAction(this Scroll_Item_PetChallengeItem self, Action<int> action)
        {
        }
    }

}