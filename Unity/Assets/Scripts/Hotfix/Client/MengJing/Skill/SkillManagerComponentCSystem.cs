namespace ET.Client
{

    [EntitySystemOf(typeof(SkillManagerComponentC))]
    [FriendOf(typeof(SkillManagerComponentC))]
    public static partial class SkillManagerComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.SkillManagerComponentC self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Client.SkillManagerComponentC self)
        {

        }

        public static void InitSkill(this ET.Client.SkillManagerComponentC self)
        {
            
        }
    }

}