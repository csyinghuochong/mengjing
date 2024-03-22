namespace ET.Server
{

    [FriendOf(typeof(SkillManagerComponent_S))]
    [EntitySystemOf(typeof(SkillManagerComponent_S))]
    public static partial class SkillComponentServerSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.SkillManagerComponent_S self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.SkillManagerComponent_S self)
        {

        }

        public static M2C_SkillCmd OnUseSkill(this SkillManagerComponent_S self, C2M_SkillCmd skillcmd, bool zhudong = true, bool checkDead = true)
        {
            return null;
        }

        public static void InterruptSkill(this SkillManagerComponent_S self, int skillId)
        {
            
        }

        public static bool IsSkillSecond(this SkillManagerComponent_S self, int skillId)
        {
            return self.SkillSecond.ContainsKey(skillId);
        }

        public static int SkillSecondBuffId(this SkillManagerComponent_S self, int skillId)
        {
            return self.SkillSecond[skillId];
        }
    }

}