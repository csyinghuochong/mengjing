namespace ET.Server
{

    [FriendOf(typeof(SkillManagerComponentS))]
    [EntitySystemOf(typeof(SkillManagerComponentS))]
    public static partial class SkillComponentServerSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.SkillManagerComponentS self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.SkillManagerComponentS self)
        {

        }

        public static M2C_SkillCmd OnUseSkill(this SkillManagerComponentS self, C2M_SkillCmd skillcmd, bool zhudong = true, bool checkDead = true)
        {
            return null;
        }

        public static void InterruptSkill(this SkillManagerComponentS self, int skillId)
        {
            
        }

        public static bool IsSkillSecond(this SkillManagerComponentS self, int skillId)
        {
            return self.SkillSecond.ContainsKey(skillId);
        }

        public static int SkillSecondBuffId(this SkillManagerComponentS self, int skillId)
        {
            return self.SkillSecond[skillId];
        }
    }

}