namespace ET.Server
{

    [FriendOf(typeof(SkillComponentServer))]
    [EntitySystemOf(typeof(SkillComponentServer))]
    public static partial class SkillComponentServerSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.SkillComponentServer self)
        {

        }
        [EntitySystem]
        private static void Destroy(this ET.Server.SkillComponentServer self)
        {

        }

        public static M2C_SkillCmd OnUseSkill(this SkillComponentServer self, C2M_SkillCmd skillcmd, bool zhudong = true, bool checkDead = true)
        {
            return null;
        }

        public static bool IsSkillSecond(this SkillComponentServer self, int skillId)
        {
            return self.SkillSecond.ContainsKey(skillId);
        }

        public static int SkillSecondBuffId(this SkillComponentServer self, int skillId)
        {
            return self.SkillSecond[skillId];
        }
    }

}