using UnityEngine;

namespace ET.Client
{


    [EntitySystemOf(typeof(ES_MainTeam))]
    [FriendOfAttribute(typeof(ES_MainTeam))]
    public static partial class ES_MainTeamSystem
    {
        [EntitySystem]
        private static void Awake(this ES_MainTeam self, Transform args2)
        {
            self.UITransform = args2;
        }
        [EntitySystem]
        private static void Destroy(this ES_MainTeam self)
        {
            self.DestroyWidget();
        }
        
        public static void ResetUI(this ES_MainTeam self)
        {
            
        }
    }

}