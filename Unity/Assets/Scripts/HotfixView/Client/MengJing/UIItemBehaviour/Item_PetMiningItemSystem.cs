using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{

    [FriendOf(typeof(Scroll_Item_PetMiningItem))]
    [EntitySystemOf(typeof(Scroll_Item_PetMiningItem))]
    public static partial class Item_PetMiningItemSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.Scroll_Item_PetMiningItem self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Client.Scroll_Item_PetMiningItem self)
        {

        }
    }

}