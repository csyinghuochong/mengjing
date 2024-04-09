namespace ET.Server
{

    /// <summary>
    /// 持续性伤害。 this.CheckChiXuHurt()已经实现了持续性伤害功能，
    /// </summary>
    public class Skill_DurationDamage : SkillHandlerS
    {
        
        
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            skillS.BaseOnInit(skillS.SkillInfo, theUnitFrom);
            skillS.SkillTriggerLastTime = TimeHelper.ServerNow();
        }

        public override void OnExecute(SkillS skillS)
        {
            skillS.InitSelfBuff();
            this.OnUpdate(skillS, 0);
        }

        public override void OnUpdate(SkillS skillS, int updateMode)
        {
            //每间隔一段时间触发一次伤害
            long serverNow = TimeHelper.ServerNow();
            if (serverNow - skillS.SkillTriggerLastTime >= skillS.SkillConf.DamgeChiXuInterval)
            {
                skillS.SkillTriggerLastTime = TimeHelper.ServerNow();
                skillS.HurtIds.Clear();
                skillS.ExcuteSkillAction();
            }

            //技能存在时间
            if (serverNow > skillS.SkillEndTime)
            {
                skillS.SetSkillState(SkillState.Finished);
                return;
            }

            skillS.CheckChiXuHurt();
        }

        public override void OnFinished(SkillS skillS)
        {
            skillS.Clear();
        }
    }
}