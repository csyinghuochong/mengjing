namespace ET.Client
{

    [EntitySystemOf(typeof(ES_MainSkill))]
    [FriendOfAttribute(typeof(ES_MainSkill))]
    public static partial class ES_MainSkillSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ES_MainSkill self, UnityEngine.Transform args2)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Client.ES_MainSkill self)
        {

        }
        
        
    }

}