namespace ET.Server
{

    /// <summary>
    /// 持续性伤害。 this.CheckChiXuHurt()已经实现了持续性伤害功能，
    /// </summary>
    public class Skill_DurationDamage : SkillHandlerS
    {
        
        
        public override void OnInit(SkillS skillS, Unit theUnitFrom)
        {
            this.BaseOnInit(skillId, theUnitFrom);
            this.SkillTriggerLastTime = TimeHelper.ServerNow();
        }

        public override void OnExecute(SkillS skillS)
        {
            this.InitSelfBuff();
            this.OnUpdate();
        }

        public override void OnUpdate(SkillS skillS)
        {
            //每间隔一段时间触发一次伤害
            long serverNow = TimeHelper.ServerNow();
            if (serverNow - this.SkillTriggerLastTime >= this.SkillConf.DamgeChiXuInterval)
            {
                SkillTriggerLastTime = TimeHelper.ServerNow();
                HurtIds.Clear();
                this.ExcuteSkillAction();
            }

            //技能存在时间
            if (serverNow > this.SkillEndTime)
            {
                this.SetSkillState(SkillState.Finished);
                return;
            }

            this.CheckChiXuHurt();
        }

        public override void OnFinished(SkillS skillS)
        {
            this.Clear();
        }
    }
}