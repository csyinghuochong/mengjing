namespace ET.Client
{


    [EntitySystemOf(typeof(ES_MainTeam))]
    [FriendOfAttribute(typeof(ES_MainTeam))]
    public static partial class ES_MainTeamSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ES_MainTeam self, UnityEngine.Transform args2)
        {
            self.UITransform = args2;
        }
        [EntitySystem]
        private static void Destroy(this ET.Client.ES_MainTeam self)
        {
            self.DestroyWidget();
        }
        
        public static void ResetUI(this ES_MainTeam self)
        {
            
        }
    }

}